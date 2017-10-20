﻿// <auto-generated />
using DnDManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DnDManager.Migrations
{
    [DbContext(typeof(DnDManagerContext))]
    partial class DnDManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DnDManager.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Class")
                        .IsRequired();

                    b.Property<string>("Gender");

                    b.Property<bool>("IsAlive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhysicalDescription");

                    b.Property<string>("Race")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Character");
                });
#pragma warning restore 612, 618
        }
    }
}
