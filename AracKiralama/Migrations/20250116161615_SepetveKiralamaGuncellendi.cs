using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracKiralama.Migrations
{
    /// <inheritdoc />
    public partial class SepetveKiralamaGuncellendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kiralama_Arac_AracId",
                table: "Kiralama");

            migrationBuilder.DropForeignKey(
                name: "FK_Kiralama_AspNetUsers_MusteriId",
                table: "Kiralama");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepet_Arac_AracId",
                table: "Sepet");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepet_AspNetUsers_UserId",
                table: "Sepet");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sepet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MusteriId",
                table: "Kiralama",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kiralama_Arac_AracId",
                table: "Kiralama",
                column: "AracId",
                principalTable: "Arac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kiralama_AspNetUsers_MusteriId",
                table: "Kiralama",
                column: "MusteriId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sepet_Arac_AracId",
                table: "Sepet",
                column: "AracId",
                principalTable: "Arac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sepet_AspNetUsers_UserId",
                table: "Sepet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kiralama_Arac_AracId",
                table: "Kiralama");

            migrationBuilder.DropForeignKey(
                name: "FK_Kiralama_AspNetUsers_MusteriId",
                table: "Kiralama");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepet_Arac_AracId",
                table: "Sepet");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepet_AspNetUsers_UserId",
                table: "Sepet");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sepet",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MusteriId",
                table: "Kiralama",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Kiralama_Arac_AracId",
                table: "Kiralama",
                column: "AracId",
                principalTable: "Arac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kiralama_AspNetUsers_MusteriId",
                table: "Kiralama",
                column: "MusteriId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sepet_Arac_AracId",
                table: "Sepet",
                column: "AracId",
                principalTable: "Arac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sepet_AspNetUsers_UserId",
                table: "Sepet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
