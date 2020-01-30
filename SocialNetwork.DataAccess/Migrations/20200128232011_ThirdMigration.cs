using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Posts",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 1, 28, 17, 17, 1, 416, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Chats",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 1, 28, 17, 17, 1, 441, DateTimeKind.Local).AddTicks(8627));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 28, 17, 17, 1, 416, DateTimeKind.Local).AddTicks(1991),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Chats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 28, 17, 17, 1, 441, DateTimeKind.Local).AddTicks(8627),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
