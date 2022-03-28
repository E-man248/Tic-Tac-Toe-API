﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacToeAPI.Data;

#nullable disable

namespace Tic_Tac_Toe_API.Migrations
{
    [DbContext(typeof(GameDatabaseContext))]
    [Migration("20220328084031_movePlayerIDNotNull")]
    partial class movePlayerIDNotNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("TicTacToeAPI.Models.Game", b =>
                {
                    b.Property<int>("gameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("player1ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("player2ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("gameID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TicTacToeAPI.Models.Move", b =>
                {
                    b.Property<int>("moveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("column")
                        .HasColumnType("INTEGER");

                    b.Property<int>("row")
                        .HasColumnType("INTEGER");

                    b.HasKey("moveID");

                    b.HasIndex("GameID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("TicTacToeAPI.Models.Player", b =>
                {
                    b.Property<int>("playerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("playerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TicTacToeAPI.Models.Move", b =>
                {
                    b.HasOne("TicTacToeAPI.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicTacToeAPI.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
