using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RRListener
{

    public class RaceResultData
    {
        public int bib;
        public string time;
    }

    public class AsyncEchoServer
    {
        private int _meetID;
        private int _listeningPort;
        private string _server;
        private TcpListener _listener;
        BlockingCollection<string> dataItems = new BlockingCollection<string>(10000);
        private static HubConnection _connection;
        ConcurrentDictionary<int, RaceResultData> clockStatuses = new ConcurrentDictionary<int, RaceResultData>();
        private static readonly HttpClient Client = new HttpClient();
        private static CancellationTokenSource _cts;
        private bool _reset;

        public AsyncEchoServer()
        {
            _cts = new CancellationTokenSource();
            _reset = false;
        }
        ///
        /// Start listening for connection
        /// </summary>
        public async Task Start()
        {

            IPAddress ipAddre = IPAddress.Any;
            Console.Write("Override");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Meet ID");
            Console.ResetColor();
            Console.WriteLine(" - enter 0 to keep LSS value (1):");
            string meetID = Console.ReadLine();
            _meetID = String.IsNullOrEmpty(meetID) ? 1 : Convert.ToInt32(meetID);


            Console.Write("Enter port number to listen for");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" CLOCK");
            Console.ResetColor();
            Console.WriteLine(" on (11001):");
            string port = Console.ReadLine();
            _listeningPort = String.IsNullOrEmpty(port) ? 11001 : Convert.ToInt32(port);

           

            Console.Write("Processor ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" IP Address");
            Console.ResetColor();
            Console.WriteLine(" [LOCALHOST]:");
            string server = Console.ReadLine();
            _server = String.IsNullOrEmpty(server) ? "localhost" : server;

           
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            _listener = new TcpListener(ipAddre, _listeningPort);
            _listener.Start();
            LogMessage("Listening on port " + _listeningPort + " for clock");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Starting SignalR Connection...");
            await StartHubConnectionAsync();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CONNECTED");
            Console.ResetColor();


            AcceptClients(_listener, "clock", _cts.Token);
        }


        
        private async void AcceptClients(TcpListener listener, string streamType, CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    var tcpClient = await listener.AcceptTcpClientAsync();
                    if (streamType == "clock")
                        HandleConnectionAsync(tcpClient);
                   
                }
                catch (Exception exp)
                {
                    LogMessage(exp.ToString());
                }

            }
        }

        ///
        /// Process Individual client
        /// </summary>
        ///
        private async void HandleConnectionAsync(TcpClient tcpClient)
        {
            string clientInfo = tcpClient.Client.RemoteEndPoint.ToString();
            LogMessage(string.Format("Got connection request from {0}", clientInfo));
            try
            {
                using (var networkStream = tcpClient.GetStream())
                using (var reader = new StreamReader(networkStream, Encoding.ASCII, false, 1024, false))
                //using (var writer = new StreamWriter(networkStream))
                {

                    while (true)
                    {
                        var dataFromServer = await reader.ReadLineAsync();
                        if (string.IsNullOrEmpty(dataFromServer))
                        {
                            break;
                        }

                        //RaceResultData rrMsg = JsonConvert.DeserializeObject<RaceResultData>(dataFromServer);

                        await _connection.InvokeAsync("SendResult", _meetID.ToString(), dataFromServer);
                        
                    }
                }
            }
            catch (Exception exp)
            {
                LogMessage(exp.Message);
            }
            finally
            {
                LogMessage(string.Format("Closing the client connection - {0}",
                            clientInfo));
                tcpClient.Close();
            }

        }

        
        public async Task StartHubConnectionAsync()
        {
            _connection = new HubConnectionBuilder()
                 .WithUrl("https://" + _server + ":5001/resultshub")
                 .Build();

            _connection.Closed += async (error) =>
            {
                await ReconnectHubConnectionAsync();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("SignalR Reconnected");
                Console.ResetColor();
            };

            await _connection.StartAsync();
        }

        public async Task ReconnectHubConnectionAsync()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("SinalR Disconnected. Attempting Reconnection...");
            await Task.Delay(new Random().Next(3000));
            _reset = true;
            try
            {
                await _connection.StartAsync();
            }
            catch
            {
                await ReconnectHubConnectionAsync();
            }
            _reset = true;

        }

       
        private void LogMessage(string message,
                        [CallerMemberName] string callername = "")
        {
            Console.WriteLine("[{0}] - Thread-{1}- {2}",
                    callername, Thread.CurrentThread.ManagedThreadId, message);
        }


       

    }

    class Program
    {
        static void Main(string[] args)
        {
            AsyncEchoServer trackSocket = new AsyncEchoServer();
            trackSocket.Start().Wait();

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
