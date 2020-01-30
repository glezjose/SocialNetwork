using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 28, 17, 17, 1, 416, DateTimeKind.Local).AddTicks(1991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "Friends",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Chats",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 28, 17, 17, 1, 441, DateTimeKind.Local).AddTicks(8627),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 1, 28, 17, 17, 1, 416, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.AlterColumn<bool>(
                name: "IsAccepted",
                table: "Friends",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Chats",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 1, 28, 17, 17, 1, 441, DateTimeKind.Local).AddTicks(8627));
        }
    }
}
