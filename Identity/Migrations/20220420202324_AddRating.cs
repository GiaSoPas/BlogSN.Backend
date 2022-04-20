using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Migrations
{
    public partial class AddRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Post",
                newName: "RatingCount");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b40844d9-293d-40e3-b747-f3ac68383d5c", "91c4cdb8-2edf-4d42-8663-f19e8bbb404c" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 20, 20, 23, 24, 262, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 20, 20, 23, 24, 262, DateTimeKind.Utc).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 20, 20, 23, 24, 262, DateTimeKind.Utc).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 20, 20, 23, 24, 262, DateTimeKind.Utc).AddTicks(8723));

            migrationBuilder.CreateIndex(
                name: "IX_Rating_PostId",
                table: "Rating",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.RenameColumn(
                name: "RatingCount",
                table: "Post",
                newName: "Rating");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88aec81d-b5b0-45f3-8721-8d41560b02f7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "44c7c30d-edc0-4062-bacb-7d40d30eb01c", "40384223-7acd-4d8a-984f-3468638d32d1" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 4, 20, 16, 55, 41, 932, DateTimeKind.Utc).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 4, 20, 16, 55, 41, 932, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 4, 20, 16, 55, 41, 932, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 4, 20, 16, 55, 41, 932, DateTimeKind.Utc).AddTicks(4887));
        }
    }
}
