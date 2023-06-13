﻿// <auto-generated />
using System;
using GW.Api.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GW.Api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230613165150_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("GW.Api.Data.Models.MusicModel", b =>
                {
                    b.Property<int>("MusicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MusicName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TrackLink")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MusicId");

                    b.ToTable("MusicModel");
                });

            modelBuilder.Entity("GW.Api.Data.Models.PlayListModel", b =>
                {
                    b.Property<int>("PlayListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserModelUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayListId");

                    b.HasIndex("UserModelUserId");

                    b.ToTable("PlayListModel");
                });

            modelBuilder.Entity("GW.Api.Data.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlayListFavoritaPlayListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("PlayListFavoritaPlayListId");

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("MusicModelPlayListModel", b =>
                {
                    b.Property<int>("MusicsMusicId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlaylistsPlayListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MusicsMusicId", "PlaylistsPlayListId");

                    b.HasIndex("PlaylistsPlayListId");

                    b.ToTable("MusicModelPlayListModel");
                });

            modelBuilder.Entity("GW.Api.Data.Models.PlayListModel", b =>
                {
                    b.HasOne("GW.Api.Data.Models.UserModel", null)
                        .WithMany("PlayLists")
                        .HasForeignKey("UserModelUserId");
                });

            modelBuilder.Entity("GW.Api.Data.Models.UserModel", b =>
                {
                    b.HasOne("GW.Api.Data.Models.PlayListModel", "PlayListFavorita")
                        .WithMany()
                        .HasForeignKey("PlayListFavoritaPlayListId");

                    b.Navigation("PlayListFavorita");
                });

            modelBuilder.Entity("MusicModelPlayListModel", b =>
                {
                    b.HasOne("GW.Api.Data.Models.MusicModel", null)
                        .WithMany()
                        .HasForeignKey("MusicsMusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GW.Api.Data.Models.PlayListModel", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsPlayListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GW.Api.Data.Models.UserModel", b =>
                {
                    b.Navigation("PlayLists");
                });
#pragma warning restore 612, 618
        }
    }
}
