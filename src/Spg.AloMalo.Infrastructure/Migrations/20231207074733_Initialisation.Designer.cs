﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spg.AloMalo.Infrastructure;

#nullable disable

namespace Spg.AloMalo.Infrastructure.Migrations
{
    [DbContext(typeof(PhotoContext))]
    [Migration("20231207074733_Initialisation")]
    partial class Initialisation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreationTimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Private")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.AlbumPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<int>("AlbumNavigationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PhotoNavigationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlbumNavigationId");

                    b.HasIndex("PhotoNavigationId");

                    b.ToTable("AlbumPhoto");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<bool>("AiGenerated")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationTimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ImageType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Orientation")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PhotographerNavigationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PhotographerNavigationId");

                    b.ToTable("EntityList");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photographer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Photographers");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Album", b =>
                {
                    b.HasOne("Spg.AloMalo.DomainModel.Model.Photographer", "Owner")
                        .WithMany("Albums")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.AlbumPhoto", b =>
                {
                    b.HasOne("Spg.AloMalo.DomainModel.Model.Album", "AlbumNavigation")
                        .WithMany("AlbumPhotos")
                        .HasForeignKey("AlbumNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spg.AloMalo.DomainModel.Model.Photo", "PhotoNavigation")
                        .WithMany("AlbumPhotos")
                        .HasForeignKey("PhotoNavigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlbumNavigation");

                    b.Navigation("PhotoNavigation");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Person", b =>
                {
                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.EMail", "Username", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("PersonId");

                            b1.ToTable("Persons");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("Username")
                        .IsRequired();
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photo", b =>
                {
                    b.HasOne("Spg.AloMalo.DomainModel.Model.Photographer", "PhotographerNavigation")
                        .WithMany("EntityList")
                        .HasForeignKey("PhotographerNavigationId");

                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.Location", "Location", b1 =>
                        {
                            b1.Property<int>("PhotoId")
                                .HasColumnType("INTEGER");

                            b1.Property<double>("Latitude")
                                .HasColumnType("REAL");

                            b1.Property<double>("Longitude")
                                .HasColumnType("REAL");

                            b1.HasKey("PhotoId");

                            b1.ToTable("EntityList");

                            b1.WithOwner()
                                .HasForeignKey("PhotoId");
                        });

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("PhotographerNavigation");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photographer", b =>
                {
                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.Address", "StudioAddress", b1 =>
                        {
                            b1.Property<int>("PhotographerId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("PhotographerId");

                            b1.ToTable("Photographers");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");

                            b1.OwnsOne("Spg.AloMalo.DomainModel.Model.State", "State", b2 =>
                                {
                                    b2.Property<int>("AddressPhotographerId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("TEXT")
                                        .HasColumnName("StateName");

                                    b2.HasKey("AddressPhotographerId");

                                    b2.ToTable("Photographers");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressPhotographerId");
                                });

                            b1.Navigation("State")
                                .IsRequired();
                        });

                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.PhoneNumber", "BusinessPhoneNumber", b1 =>
                        {
                            b1.Property<int>("PhotographerId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("AreaCode")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("CountryCode")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("SerialNumber")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("PhotographerId");

                            b1.ToTable("Photographers");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");
                        });

                    b.OwnsMany("Spg.AloMalo.DomainModel.Model.EMail", "EMails", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("PhotographerId")
                                .HasColumnType("INTEGER");

                            b1.HasKey("Id");

                            b1.HasIndex("PhotographerId");

                            b1.ToTable("Photographers_EMails");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");
                        });

                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.PhoneNumber", "MobilePhoneNumber", b1 =>
                        {
                            b1.Property<int>("PhotographerId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("AreaCode")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("CountryCode")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("SerialNumber")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("PhotographerId");

                            b1.ToTable("Photographers");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");
                        });

                    b.OwnsOne("Spg.AloMalo.DomainModel.Model.EMail", "Username", b1 =>
                        {
                            b1.Property<int>("PhotographerId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("PhotographerId");

                            b1.ToTable("Photographers");

                            b1.WithOwner()
                                .HasForeignKey("PhotographerId");
                        });

                    b.Navigation("BusinessPhoneNumber")
                        .IsRequired();

                    b.Navigation("EMails");

                    b.Navigation("MobilePhoneNumber")
                        .IsRequired();

                    b.Navigation("StudioAddress")
                        .IsRequired();

                    b.Navigation("Username")
                        .IsRequired();
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Album", b =>
                {
                    b.Navigation("AlbumPhotos");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photo", b =>
                {
                    b.Navigation("AlbumPhotos");
                });

            modelBuilder.Entity("Spg.AloMalo.DomainModel.Model.Photographer", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("EntityList");
                });
#pragma warning restore 612, 618
        }
    }
}
