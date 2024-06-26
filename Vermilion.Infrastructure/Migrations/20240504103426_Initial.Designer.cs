﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vermilion.Infrastructure;

#nullable disable

namespace Vermilion.Infrastructure.Migrations
{
    [DbContext(typeof(VermilionDbContext))]
    [Migration("20240504103426_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CateringCuisine", b =>
                {
                    b.Property<Guid>("CateringId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CuisinesId")
                        .HasColumnType("uuid");

                    b.HasKey("CateringId", "CuisinesId");

                    b.HasIndex("CuisinesId");

                    b.ToTable("CateringCuisine");
                });

            modelBuilder.Entity("CateringFeature", b =>
                {
                    b.Property<Guid>("CateringId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FeaturesId")
                        .HasColumnType("uuid");

                    b.HasKey("CateringId", "FeaturesId");

                    b.HasIndex("FeaturesId");

                    b.ToTable("CateringFeature");
                });

            modelBuilder.Entity("Vermilion.Domain.Common.DomainEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CateringId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CuisineId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("FeatureId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ReviewId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WorkScheduleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CateringId");

                    b.HasIndex("CuisineId");

                    b.HasIndex("FeatureId");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkScheduleId");

                    b.ToTable("DomainEvent");
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.Catering", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<double>("AverageRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.ComplexProperty<Dictionary<string, object>>("ContactInfo", "Vermilion.Domain.Entities.Catering.ContactInfo#ContactInfo", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Email")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("Email");

                            b1.Property<string>("PhoneNumber")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("Phone");

                            b1.Property<string>("WebSiteUrl")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("WebSiteUrl");
                        });

                    b.HasKey("Id");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Caterings");
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.Cuisine", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Cuisines");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f5a98d5-4ec8-46df-b112-28b964802e0c"),
                            Name = "Type1"
                        });
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6dbae7d8-a56f-4456-b380-23806f014cc2"),
                            Name = "Type1"
                        });
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CateringId")
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CateringId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("51886939-d863-4454-a05a-a8fb556d0bf4"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "email.com",
                            FirstName = "alex",
                            LastName = "the terrible",
                            Phone = "79797",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.WorkSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CateringId")
                        .HasColumnType("uuid");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval");

                    b.Property<bool>("IsDayOff")
                        .HasColumnType("boolean");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("CateringId");

                    b.HasIndex("DayOfWeek")
                        .IsUnique();

                    b.ToTable("WorkSchedules");
                });

            modelBuilder.Entity("CateringCuisine", b =>
                {
                    b.HasOne("Vermilion.Domain.Entities.Catering", null)
                        .WithMany()
                        .HasForeignKey("CateringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vermilion.Domain.Entities.Cuisine", null)
                        .WithMany()
                        .HasForeignKey("CuisinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CateringFeature", b =>
                {
                    b.HasOne("Vermilion.Domain.Entities.Catering", null)
                        .WithMany()
                        .HasForeignKey("CateringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vermilion.Domain.Entities.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vermilion.Domain.Common.DomainEvent", b =>
                {
                    b.HasOne("Vermilion.Domain.Entities.Catering", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("CateringId");

                    b.HasOne("Vermilion.Domain.Entities.Cuisine", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("CuisineId");

                    b.HasOne("Vermilion.Domain.Entities.Feature", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("FeatureId");

                    b.HasOne("Vermilion.Domain.Entities.Review", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("ReviewId");

                    b.HasOne("Vermilion.Domain.Entities.User", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("UserId");

                    b.HasOne("Vermilion.Domain.Entities.WorkSchedule", null)
                        .WithMany("DomainEvents")
                        .HasForeignKey("WorkScheduleId");
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.Review", b =>
                {
                    b.HasOne("Vermilion.Domain.Entities.Catering", null)
                        .WithMany("Reviews")
                        .HasForeignKey("CateringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vermilion.Domain.Entities.User", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.WorkSchedule", b =>
                {
                    b.HasOne("Vermilion.Domain.Entities.Catering", null)
                        .WithMany("WorkSchedules")
                        .HasForeignKey("CateringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.Catering", b =>
                {
                    b.Navigation("DomainEvents");

                    b.Navigation("Reviews");

                    b.Navigation("WorkSchedules");
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.Cuisine", b =>
                {
                    b.Navigation("DomainEvents");
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.Feature", b =>
                {
                    b.Navigation("DomainEvents");
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.Review", b =>
                {
                    b.Navigation("DomainEvents");
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.User", b =>
                {
                    b.Navigation("DomainEvents");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Vermilion.Domain.Entities.WorkSchedule", b =>
                {
                    b.Navigation("DomainEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
