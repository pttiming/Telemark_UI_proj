var onready = function () {

    let hubRoute = "/resultshub";
    console.log('Hub Route:' + hubRoute);

    const connection = new signalR.HubConnectionBuilder()
        .withUrl(hubRoute)
        .withAutomaticReconnect([0, 1000, 1000, 2000, 2000, 3000, 3000, 5000, 5000, 5000, 5000, 5000, 10000, 10000, 10000, 10000, 10000, 10000, 10000, 20000, 20000, 20000, 20000, 20000, 20000, 30000, 30000, 60000, 60000, 60000, 60000, 60000, 60000, 60000, null])
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.start()
        .then(function () {
            console.log("Connected successfully");
            connection.invoke('joinGroup', mid);
        })
        .catch(function (err) {
            console.log("ERROR: " + err);
        });

    connection.on('getResult', data => {
        console.log(data);

        let html = "";
        html += "<div>";
        html += data;
        html += "</div>";

        document.getElementById("log").innerHTML = html + document.getElementById("log").innerHTML;

    });

    document.getElementById("sendButton").addEventListener("click", function (event) {
        let message = document.getElementById("message").value;
        connection.invoke("SendResult", mid, message).catch(function (error) {
            return console.log(error.toString());
        });
        event.preventDefault();
    });


}

document.addEventListener("DOMContentLoaded", onready);