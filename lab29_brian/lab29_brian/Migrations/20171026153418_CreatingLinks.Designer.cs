﻿// <auto-generated />
using lab29_brian.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace lab29_brian.Migrations
{
    [DbContext(typeof(lab29_brianContext))]
    [Migration("20171026153418_CreatingLinks")]
    partial class CreatingLinks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab29_brian.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("lab29_brian.Models.MapPost", b =>
                {
                    b.Property<int>("userID");

                    b.Property<int>("userpostID");

                    b.HasKey("userID", "userpostID");

                    b.HasIndex("userpostID");

                    b.ToTable("MapPost");
                });

            modelBuilder.Entity("lab29_brian.Models.UserPost", b =>
                {
                    b.Property<int>("UserPostID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GeoLocation");

                    b.Property<string>("Picture");

                    b.Property<string>("PostContent");

                    b.HasKey("UserPostID");

                    b.ToTable("UserPost");
                });

            modelBuilder.Entity("lab29_brian.Models.MapPost", b =>
                {
                    b.HasOne("lab29_brian.Models.UserPost", "UserPost")
                        .WithMany()
                        .HasForeignKey("userpostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
