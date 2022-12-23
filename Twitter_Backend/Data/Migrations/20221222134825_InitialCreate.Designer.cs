﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Twitter_Backend.Data;

#nullable disable

namespace TwitterBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221222134825_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Twitter_Backend.Models.Like", b =>
                {
                    b.Property<int>("tweetLikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tweetLikeId"));

                    b.Property<bool>("tweetBoolean")
                        .HasColumnType("bit");

                    b.Property<int>("tweetid")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tweetLikeId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Twitter_Backend.Models.Retweet", b =>
                {
                    b.Property<int>("retweetid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("retweetid"));

                    b.Property<string>("reTweet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("reTweetTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("tweetid")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("retweetid");

                    b.ToTable("Retweets");
                });

            modelBuilder.Entity("Twitter_Backend.Models.TweetPost", b =>
                {
                    b.Property<int>("tweetid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tweetid"));

                    b.Property<int>("likeCount")
                        .HasColumnType("int");

                    b.Property<string>("tweet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("tweetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tweetid");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("Twitter_Backend.Models.User", b =>
                {
                    b.Property<string>("userName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("contactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userName");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}