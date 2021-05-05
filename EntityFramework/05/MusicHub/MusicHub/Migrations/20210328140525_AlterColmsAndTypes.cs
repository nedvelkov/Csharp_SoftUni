using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicHub.Migrations
{
    public partial class AlterColmsAndTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Producers_ProducerId",
                table: "Albums");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "Songs",
                type: "TimeSpan",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "TIMESTAMP");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Albums",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Producers_ProducerId",
                table: "Albums",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Producers_ProducerId",
                table: "Albums");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Duration",
                table: "Songs",
                type: "TIMESTAMP",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TimeSpan");

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "Albums",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Producers_ProducerId",
                table: "Albums",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
