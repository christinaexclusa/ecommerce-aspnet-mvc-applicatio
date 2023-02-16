﻿// <auto-generated />
using System;
using ConcertAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConcertAPI.Migrations
{
    [DbContext(typeof(ConcertContext))]
    partial class ConcertContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BandModelMusicianModel", b =>
                {
                    b.Property<int>("BandsId")
                        .HasColumnType("int");

                    b.Property<int>("MusiciansId")
                        .HasColumnType("int");

                    b.HasKey("BandsId", "MusiciansId");

                    b.HasIndex("MusiciansId");

                    b.ToTable("BandModelMusicianModel");
                });

            modelBuilder.Entity("ConcertData.DataModels.BandModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PreformerCategory")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Bands");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Bio = "Great band, been together for years.",
                            FullName = "Barenaked Ladies",
                            PreformerCategory = 1,
                            ProfilePictureUrl = "https://www.barenakedladies.com/wp-content/uploads/2015/05/large.scyd5regTuwzFP5b4C-t66Qz7O_ftON3oFMxT1lWFUg-300x300.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Bio = "Good solid music, for a simple evening.",
                            FullName = "Two Friends",
                            PreformerCategory = 2,
                            ProfilePictureUrl = "https://cdn.shopify.com/s/files/1/0015/2708/7192/products/DMYourCrush_1_2186932c-3e15-481b-9849-a2fb91b2def2_800x.png?v=1664902157"
                        },
                        new
                        {
                            Id = 7,
                            Bio = "Great Punck Rock Band",
                            FullName = "Hippo Campusip",
                            PreformerCategory = 4,
                            ProfilePictureUrl = "https://cdn.shopify.com/s/files/1/0219/6940/products/CD_MOCK_square_1024x1024.jpg?v=1623341625"
                        });
                });

            modelBuilder.Entity("ConcertData.DataModels.ConcertModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ConcertDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConcertGenre")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Concerts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcertDate = new DateTime(2023, 7, 4, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            ConcertGenre = 2,
                            Description = "This is a good ole boys concert",
                            ImageURL = "https://images.pexels.com/photos/1105666/pexels-photo-1105666.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Big Concert at the River",
                            Price = 10.0,
                            VenueId = 1
                        },
                        new
                        {
                            Id = 2,
                            ConcertDate = new DateTime(2023, 7, 8, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            ConcertGenre = 1,
                            Description = "This is a good ole boys concert",
                            ImageURL = "https://images.pexels.com/photos/1190297/pexels-photo-1190297.jpeg",
                            Name = "Concert at the Beach",
                            Price = 10.0,
                            VenueId = 2
                        },
                        new
                        {
                            Id = 3,
                            ConcertDate = new DateTime(2023, 8, 1, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            ConcertGenre = 1,
                            Description = "This is a good ole boys concert",
                            ImageURL = "https://images.pexels.com/photos/995301/pexels-photo-995301.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            Name = "Concert at the Beach",
                            Price = 10.0,
                            VenueId = 3
                        });
                });

            modelBuilder.Entity("ConcertData.DataModels.MusicianModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PreformerCategory")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Musicians");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Punk musician played with Hippo Campusip in concerts",
                            FullName = "Gus Dapperton",
                            PreformerCategory = 4,
                            ProfilePictureUrl = "https://www.gusdapperton.com/sites/g/files/g2000015461/files/2022-10/artwork-440x440.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Punk musician",
                            FullName = "Hippo Smith",
                            PreformerCategory = 4,
                            ProfilePictureUrl = "https://www.gusdapperton.com/sites/g/files/g2000015461/files/2022-10/artwork-440x440.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Great country singer",
                            FullName = "Johnny Cash",
                            PreformerCategory = 2,
                            ProfilePictureUrl = "https://books.google.com/books/content?id=yL6MRZfrWjkC&pg=PP1&img=1&zoom=3&hl=en&bul=1&sig=ACfU3U02TmfmNvXIpXhrD026A0Nktcb3zw&w=1280"
                        },
                        new
                        {
                            Id = 4,
                            Bio = "Great country singer",
                            FullName = "Jimmy Buffett",
                            PreformerCategory = 2,
                            ProfilePictureUrl = "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcQD84Z5E5op_ZJJNwOl4W-YSizPPEAE9mZc7aTI8CNnfCA3Mzbi_DI_H7NxT-b8A6CiAai85Fla0ud_ZM4"
                        });
                });

            modelBuilder.Entity("ConcertData.DataModels.VenueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LogoURL")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Venues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LogoURL = "https://lh3.googleusercontent.com/p/AF1QipOCzZhPE1I7VOx6sqrXTbaaE9DZm2lYkrHYPzCF=s680-w680-h510",
                            Name = "KEMBA Live!"
                        },
                        new
                        {
                            Id = 2,
                            LogoURL = "https://lh3.googleusercontent.com/p/AF1QipOC8C3lLf-X-4yMGvg-GTNrg3bWMXDLWdj1LOnx=s680-w680-h510",
                            Name = "Newport Music Hall"
                        },
                        new
                        {
                            Id = 3,
                            LogoURL = "https://lh3.googleusercontent.com/p/AF1QipOC8C3lLf-X-4yMGvg-GTNrg3bWMXDLWdj1LOnx=s680-w680-h510",
                            Name = "Blossom Music Center"
                        });
                });

            modelBuilder.Entity("BandModelMusicianModel", b =>
                {
                    b.HasOne("ConcertData.DataModels.BandModel", null)
                        .WithMany()
                        .HasForeignKey("BandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConcertData.DataModels.MusicianModel", null)
                        .WithMany()
                        .HasForeignKey("MusiciansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConcertData.DataModels.ConcertModel", b =>
                {
                    b.HasOne("ConcertData.DataModels.VenueModel", "Venue")
                        .WithMany("Concerts")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("ConcertData.DataModels.VenueModel", b =>
                {
                    b.Navigation("Concerts");
                });
#pragma warning restore 612, 618
        }
    }
}
