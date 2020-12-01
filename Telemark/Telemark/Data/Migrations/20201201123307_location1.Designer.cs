﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Telemark.Data;

namespace Telemark.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201201123307_location1")]
    partial class location1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "f5e2f4e8-d911-4a37-908e-5d3934eddd59",
                            ConcurrencyStamp = "f0d46fae-25e4-4e52-9615-e1913284a897",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "d53271aa-a7aa-4e0b-8eae-c9c1ed75543f",
                            ConcurrencyStamp = "ea115caa-af29-43f2-a496-33da9a8f2146",
                            Name = "Director",
                            NormalizedName = "DIRECTOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Telemark.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10, 8)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<string>("RSU_API_Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RSU_API_Secret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Telemark.Models.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("age_calc_base_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("distance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("end_time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("event_id")
                        .HasColumnType("int");

                    b.Property<string>("event_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("giveaway")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("race_event_days_id")
                        .HasColumnType("int");

                    b.Property<int>("race_id")
                        .HasColumnType("int");

                    b.Property<int?>("raceid")
                        .HasColumnType("int");

                    b.Property<string>("registration_opens")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("require_dob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("require_phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("start_time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("volunteer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("raceid");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Telemark.Models.InfoMessage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("keyword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("race_id")
                        .HasColumnType("int");

                    b.Property<int?>("raceid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("raceid");

                    b.ToTable("Info");
                });

            modelBuilder.Entity("Telemark.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keyword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10, 8)");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.Property<int>("race_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("race_id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Telemark.Models.Participant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("age")
                        .HasColumnType("int");

                    b.Property<int?>("bib_num")
                        .HasColumnType("int");

                    b.Property<string>("chip_num")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("event_id")
                        .HasColumnType("int");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("last_modified")
                        .HasColumnType("int");

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("race_id")
                        .HasColumnType("int");

                    b.Property<int?>("raceid")
                        .HasColumnType("int");

                    b.Property<string>("registration_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("registration_id")
                        .HasColumnType("int");

                    b.Property<string>("team_bib_num")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("team_gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("team_id")
                        .HasColumnType("int");

                    b.Property<string>("team_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("team_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("team_type_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("event_id");

                    b.HasIndex("raceid");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Telemark.Models.Race", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Keyword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("director_id")
                        .HasColumnType("int");

                    b.Property<string>("external_race_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("external_results_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("fb_event_id")
                        .HasColumnType("bigint");

                    b.Property<string>("fb_page_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("is_draft_race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("is_private_race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("is_registration_open")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_end_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_modified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logo_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("next_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("next_end_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("race_id")
                        .HasColumnType("int");

                    b.Property<string>("real_time_notifications_enabled")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("timezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("director_id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Telemark.Models.RaceAddress", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10, 8)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("race_id")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("race_id")
                        .IsUnique();

                    b.ToTable("RaceAddresses");
                });

            modelBuilder.Entity("Telemark.Models.SmsMessage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Recevied")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Telemark.Models.Subscription", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("race_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Telemark.Models.TextUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("current_race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_participant")
                        .HasColumnType("bit");

                    b.Property<string>("last_request")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("last_request_time")
                        .HasColumnType("datetime2");

                    b.Property<int>("participant_id")
                        .HasColumnType("int");

                    b.Property<int>("race_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("TextUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Telemark.Models.Director", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Telemark.Models.Event", b =>
                {
                    b.HasOne("Telemark.Models.Race", "race")
                        .WithMany()
                        .HasForeignKey("raceid");
                });

            modelBuilder.Entity("Telemark.Models.InfoMessage", b =>
                {
                    b.HasOne("Telemark.Models.Race", "race")
                        .WithMany()
                        .HasForeignKey("raceid");
                });

            modelBuilder.Entity("Telemark.Models.Location", b =>
                {
                    b.HasOne("Telemark.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("race_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Telemark.Models.Participant", b =>
                {
                    b.HasOne("Telemark.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("event_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Telemark.Models.Race", "race")
                        .WithMany()
                        .HasForeignKey("raceid");
                });

            modelBuilder.Entity("Telemark.Models.Race", b =>
                {
                    b.HasOne("Telemark.Models.Director", "Director")
                        .WithMany()
                        .HasForeignKey("director_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Telemark.Models.RaceAddress", b =>
                {
                    b.HasOne("Telemark.Models.Race", "Race")
                        .WithOne("address")
                        .HasForeignKey("Telemark.Models.RaceAddress", "race_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Telemark.Models.Subscription", b =>
                {
                    b.HasOne("Telemark.Models.TextUser", "TextUser")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
