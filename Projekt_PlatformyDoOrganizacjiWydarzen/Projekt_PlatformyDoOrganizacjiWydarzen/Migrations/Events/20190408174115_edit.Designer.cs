﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_PlatformyDoOrganizacjiWydarzen.Models;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Migrations.Events
{
    [DbContext(typeof(EventsContext))]
    [Migration("20190408174115_edit")]
    partial class edit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projekt_PlatformyDoOrganizacjiWydarzen.Models.EventsModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("event_type");

                    b.Property<DateTime>("hour");

                    b.Property<string>("name");

                    b.Property<string>("organisator");

                    b.Property<string>("place");

                    b.Property<int>("tickets");

                    b.Property<int>("tickets_per_person");

                    b.HasKey("id");

                    b.ToTable("EventsModel");
                });
#pragma warning restore 612, 618
        }
    }
}
