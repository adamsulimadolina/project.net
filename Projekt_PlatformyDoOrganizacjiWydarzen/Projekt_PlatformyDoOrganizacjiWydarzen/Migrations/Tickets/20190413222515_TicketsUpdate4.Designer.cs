﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_PlatformyDoOrganizacjiWydarzen.Models;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Migrations.Tickets
{
    [DbContext(typeof(TicketsContext))]
    [Migration("20190413222515_TicketsUpdate4")]
    partial class TicketsUpdate4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projekt_PlatformyDoOrganizacjiWydarzen.Models.TicketsModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NIP");

                    b.Property<int>("event_id");

                    b.Property<string>("hour");

                    b.Property<string>("name");

                    b.Property<string>("place");

                    b.Property<string>("user_mail");

                    b.Property<string>("user_name");

                    b.Property<string>("user_surname");

                    b.HasKey("id");

                    b.ToTable("TicketsModel");
                });
#pragma warning restore 612, 618
        }
    }
}
