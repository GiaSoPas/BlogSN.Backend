﻿// <auto-generated />
using System;
using Identity.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlogSN.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Спорт (англ. sport, сокращение от первоначального старофранц. desport — «игра», «развлечение») — организованная по определённым правилам деятельность людей (спортсменов), состоящая в сопоставлении их физических и/или интеллектуальных способностей. ",
                            Name = "Спорт"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ки́берспо́рт (также известен как «компью́терный спорт» или «электро́нный спорт», англ. esports) — командное или индивидуальное соревнование на основе компьютерных видеоигр. В России признан официальным видом спорта.",
                            Name = "Киберспорт"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Аниме́  — японская мультипликация. В отличие от мультфильмов других стран, предназначенных в основном для просмотра детьми, бо́льшая часть выпускаемого аниме рассчитана на подростковую и имеет высокую популярность в мире. ",
                            Name = "Аниме"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Ну, тут очевидно про кино и сериалы, да?",
                            Name = "Кино и сериалы"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Всем небезразличным к шаурме посвящается",
                            Name = "Шаурма и друзья"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Путеше́ствие — передвижение по какой-либо территории или акватории с целью их изучения, а также с общеобразовательными, познавательными, спортивными и другими целями.",
                            Name = "Путешествия"
                        },
                        new
                        {
                            Id = 7,
                            Description = "этот вид «отражает действительность и воздействует на человека посредством осмысленных и особым образом организованных по высоте и во времени звуковых последований",
                            Name = "Музыка"
                        },
                        new
                        {
                            Id = 8,
                            Description = "одна из наиболее общих категорий эстетики, искусствознания и художественной практики",
                            Name = "Арт"
                        },
                        new
                        {
                            Id = 9,
                            Description = "единица значимой для культуры информации.",
                            Name = "Мемы"
                        },
                        new
                        {
                            Id = 10,
                            Description = "под культурой понимают человеческую деятельность в её самых разных проявлениях, включая все формы и способы человеческого самовыражения и самопознания",
                            Name = "Культура"
                        },
                        new
                        {
                            Id = 11,
                            Description = "форма деятельности в условных ситуациях, направленная на воссоздание и усвоение общественного опыта, фиксированного в социально закрепленных способах осуществления предметных действий, в предметах науки и культуры.",
                            Name = "Игры"
                        });
                });

            modelBuilder.Entity("BlogSN.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("CommentsCount")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("RatingCount")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Post");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            CategoryId = 1,
                            CommentsCount = 0,
                            Content = "Про спорт и все такое",
                            DateCreated = new DateTime(2022, 5, 18, 14, 57, 20, 156, DateTimeKind.Utc).AddTicks(6087),
                            Description = "Описание спорта",
                            RatingCount = 0,
                            Title = "Спорт"
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            CategoryId = 2,
                            CommentsCount = 0,
                            Content = "Про киберспорт и все такое",
                            DateCreated = new DateTime(2022, 5, 18, 14, 57, 20, 156, DateTimeKind.Utc).AddTicks(6092),
                            Description = "Описание киберспорта",
                            RatingCount = 0,
                            Title = "Киберспорт"
                        },
                        new
                        {
                            Id = 3,
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            CategoryId = 2,
                            CommentsCount = 0,
                            Content = "Про киберспорт и все такое",
                            DateCreated = new DateTime(2022, 5, 18, 14, 57, 20, 156, DateTimeKind.Utc).AddTicks(6093),
                            Description = "Описание киберспорта",
                            RatingCount = 0,
                            Title = "Киберспорт"
                        },
                        new
                        {
                            Id = 4,
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            CategoryId = 3,
                            CommentsCount = 0,
                            Content = "Про спортмашины и все такое",
                            DateCreated = new DateTime(2022, 5, 18, 14, 57, 20, 156, DateTimeKind.Utc).AddTicks(6094),
                            Description = "Описание спортмашины",
                            RatingCount = 0,
                            Title = "Cпортмашины"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Models.ModelsBlogSN.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            Content = "Норм тема",
                            CreatedDate = new DateTime(2022, 5, 18, 14, 57, 20, 156, DateTimeKind.Utc).AddTicks(6126),
                            PostId = 1
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            Content = "Норм тема",
                            CreatedDate = new DateTime(2022, 5, 18, 14, 57, 20, 156, DateTimeKind.Utc).AddTicks(6128),
                            PostId = 1
                        },
                        new
                        {
                            Id = 3,
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            Content = "Норм тема",
                            CreatedDate = new DateTime(2022, 5, 18, 14, 57, 20, 156, DateTimeKind.Utc).AddTicks(6129),
                            PostId = 2
                        },
                        new
                        {
                            Id = 4,
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            Content = "Норм тема",
                            CreatedDate = new DateTime(2022, 5, 18, 14, 57, 20, 156, DateTimeKind.Utc).AddTicks(6129),
                            PostId = 2
                        });
                });

            modelBuilder.Entity("Models.ModelsBlogSN.Rating", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LikeStatus")
                        .HasColumnType("boolean");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Rating");

                    b.HasData(
                        new
                        {
                            Id = "188aec81d-b5b0-45f3-8721-8d41560b02f7",
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            LikeStatus = true,
                            PostId = 1
                        },
                        new
                        {
                            Id = "288aec81d-b5b0-45f3-8721-8d41560b02f7",
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            LikeStatus = true,
                            PostId = 1
                        },
                        new
                        {
                            Id = "388aec81d-b5b0-45f3-8721-8d41560b02f7",
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            LikeStatus = false,
                            PostId = 2
                        },
                        new
                        {
                            Id = "488aec81d-b5b0-45f3-8721-8d41560b02f7",
                            ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            LikeStatus = false,
                            PostId = 2
                        });
                });

            modelBuilder.Entity("Models.ModelsIdentity.IdentityAuth.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("PostsCount")
                        .HasColumnType("integer");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "78ea9b2c-694f-4379-8f61-2e9c9cdc3384",
                            Email = "1@mail.ru",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "EtoHash",
                            PhoneNumberConfirmed = false,
                            PostsCount = 0,
                            SecurityStamp = "eab4f21e-3495-4be4-9f39-2f476b475c21",
                            TwoFactorEnabled = false,
                            UserName = "Vanya"
                        });
                });

            modelBuilder.Entity("BlogSN.Models.Post", b =>
                {
                    b.HasOne("Models.ModelsIdentity.IdentityAuth.ApplicationUser", "ApplicationUser")
                        .WithMany("Posts")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("BlogSN.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Models.ModelsIdentity.IdentityAuth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Models.ModelsIdentity.IdentityAuth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.ModelsIdentity.IdentityAuth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Models.ModelsIdentity.IdentityAuth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.ModelsBlogSN.Comment", b =>
                {
                    b.HasOne("Models.ModelsIdentity.IdentityAuth.ApplicationUser", "ApplicationUser")
                        .WithMany("Comments")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("BlogSN.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Models.ModelsBlogSN.Rating", b =>
                {
                    b.HasOne("BlogSN.Models.Post", null)
                        .WithMany("Rating")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogSN.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BlogSN.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("Models.ModelsIdentity.IdentityAuth.ApplicationUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
