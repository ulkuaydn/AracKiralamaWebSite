using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracKiralama.Migrations
{
    /// <inheritdoc />
    public partial class SepetEkleGüncel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaketTipi",
                table: "Sepet",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaketTipi",
                table: "Sepet");
        }
    }
}
