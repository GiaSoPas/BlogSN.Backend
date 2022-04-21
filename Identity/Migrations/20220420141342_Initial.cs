using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
<<<<<<<< HEAD:Identity/Migrations/20220420222338_Intial.cs
                    RatingCount = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
========
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
>>>>>>>> master:Identity/Migrations/20220420141342_Initial.cs
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
<<<<<<<< HEAD:Identity/Migrations/20220420222338_Intial.cs
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LikeStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "88aec81d-b5b0-45f3-8721-8d41560b02f7", 0, "72ff1838-e5f0-4ab9-8d10-648ee9bed81d", "1@mail.ru", false, false, null, null, null, "EtoHash", null, false, "286d60b3-dd9a-4b8a-951b-819985c5c1a8", false, "Vanya" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Спорт" },
                    { 2, null, "Киберспорт" },
                    { 3, null, "Cпортмашины" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Content", "DateCreated", "Description", "RatingCount", "Title" },
                values: new object[,]
                {
                    { 1, "88aec81d-b5b0-45f3-8721-8d41560b02f7", 1, "Про спорт и все такое", new DateTime(2022, 4, 20, 22, 23, 38, 680, DateTimeKind.Utc).AddTicks(6654), "Описание спорта", 0, "Спорт" },
                    { 2, "88aec81d-b5b0-45f3-8721-8d41560b02f7", 2, "Про киберспорт и все такое", new DateTime(2022, 4, 20, 22, 23, 38, 680, DateTimeKind.Utc).AddTicks(6658), "Описание киберспорта", 0, "Киберспорт" },
                    { 3, "88aec81d-b5b0-45f3-8721-8d41560b02f7", 2, "Про киберспорт и все такое", new DateTime(2022, 4, 20, 22, 23, 38, 680, DateTimeKind.Utc).AddTicks(6660), "Описание киберспорта", 0, "Киберспорт" },
                    { 4, "88aec81d-b5b0-45f3-8721-8d41560b02f7", 3, "Про спортмашины и все такое", new DateTime(2022, 4, 20, 22, 23, 38, 680, DateTimeKind.Utc).AddTicks(6661), "Описание спортмашины", 0, "Cпортмашины" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ApplicationUserId", "Content", "CreatedDate", "PostId" },
                values: new object[,]
                {
                    { 1, "88aec81d-b5b0-45f3-8721-8d41560b02f7", "Норм тема", new DateTime(2022, 4, 20, 22, 23, 38, 680, DateTimeKind.Utc).AddTicks(6683), 1 },
                    { 2, "88aec81d-b5b0-45f3-8721-8d41560b02f7", "Норм тема", new DateTime(2022, 4, 20, 22, 23, 38, 680, DateTimeKind.Utc).AddTicks(6684), 1 },
                    { 3, "88aec81d-b5b0-45f3-8721-8d41560b02f7", "Норм тема", new DateTime(2022, 4, 20, 22, 23, 38, 680, DateTimeKind.Utc).AddTicks(6686), 2 },
                    { 4, "88aec81d-b5b0-45f3-8721-8d41560b02f7", "Норм тема", new DateTime(2022, 4, 20, 22, 23, 38, 680, DateTimeKind.Utc).AddTicks(6687), 2 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "ApplicationUserId", "LikeStatus", "PostId" },
                values: new object[,]
                {
                    { 1, "88aec81d-b5b0-45f3-8721-8d41560b02f7", true, 1 },
                    { 2, "88aec81d-b5b0-45f3-8721-8d41560b02f7", true, 1 },
                    { 3, "88aec81d-b5b0-45f3-8721-8d41560b02f7", false, 2 },
                    { 4, "88aec81d-b5b0-45f3-8721-8d41560b02f7", false, 2 }
========
                        principalColumn: "Id");
>>>>>>>> master:Identity/Migrations/20220420141342_Initial.cs
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ApplicationUserId",
                table: "Post",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_PostId",
                table: "Rating",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
