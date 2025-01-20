using Microsoft.EntityFrameworkCore.Migrations;

public partial class KullaniciAdSoyadEklendi : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Ad",
            table: "AspNetUsers",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Soyad",
            table: "AspNetUsers",
            type: "nvarchar(max)",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Ad",
            table: "AspNetUsers");

        migrationBuilder.DropColumn(
            name: "Soyad",
            table: "AspNetUsers");
    }
} 