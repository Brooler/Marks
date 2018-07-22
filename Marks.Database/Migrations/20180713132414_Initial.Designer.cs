﻿// <auto-generated />
using Marks.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Marks.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180713132414_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Marks.Core.Models.Mark", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("PeopleId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("PeopleId")
                        .IsUnique();

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("Marks.Core.Models.People", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("Marks.Core.Models.Mark", b =>
                {
                    b.HasOne("Marks.Core.Models.People", "People")
                        .WithOne("Mark")
                        .HasForeignKey("Marks.Core.Models.Mark", "PeopleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
