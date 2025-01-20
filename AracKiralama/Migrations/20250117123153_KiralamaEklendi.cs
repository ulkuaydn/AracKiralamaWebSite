using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracKiralama.Migrations
{
    /// <inheritdoc />
    public partial class KiralamaEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kiralama_AspNetUsers_MusteriId",
                table: "Kiralama");

            migrationBuilder.DropIndex(
                name: "IX_Kiralama_MusteriId",
                table: "Kiralama");

            migrationBuilder.DropColumn(
                name: "MusteriId",
                table: "Kiralama");

            migrationBuilder.RenameColumn(
                name: "ToplamUcret",
                table: "Kiralama",
                newName: "ToplamTutar");

            migrationBuilder.RenameColumn(
                name: "Durumu",
                table: "Kiralama",
                newName: "Durum");

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarihi",
                table: "Kiralama",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OlusturulmaTarihi",
                table: "Kiralama");

            migrationBuilder.RenameColumn(
                name: "ToplamTutar",
                table: "Kiralama",
                newName: "ToplamUcret");

            migrationBuilder.RenameColumn(
                name: "Durum",
                table: "Kiralama",
                newName: "Durumu");

            migrationBuilder.AddColumn<string>(
                name: "MusteriId",
                table: "Kiralama",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Kiralama_MusteriId",
                table: "Kiralama",
                column: "MusteriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kiralama_AspNetUsers_MusteriId",
                table: "Kiralama",
                column: "MusteriId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
