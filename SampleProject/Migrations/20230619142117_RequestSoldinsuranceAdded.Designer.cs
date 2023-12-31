﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleProject.Data;

#nullable disable

namespace SampleProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230619142117_RequestSoldinsuranceAdded")]
    partial class RequestSoldinsuranceAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("SampleProject.Models.Requests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("BillTotal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CapitalSum")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("SampleProject.Models.Services", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("MaxCapital")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MinCapital")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Rate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("SampleProject.Models.SoldInsurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("ServiceId");

                    b.ToTable("SoldInsurances");
                });

            modelBuilder.Entity("SampleProject.Models.SoldInsurance", b =>
                {
                    b.HasOne("SampleProject.Models.Requests", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleProject.Models.Services", "service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("service");
                });
#pragma warning restore 612, 618
        }
    }
}
