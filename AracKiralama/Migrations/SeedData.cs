using Microsoft.EntityFrameworkCore.Migrations;

public class SeedData : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Arac",
            columns: new[] { "Id", "Marka", "Model", "Yil", "YakitTipi", "Vites", "GunlukUcret", "ResimUrl", "Musait" },
            values: new object[] { 1, "Renault", "Clio", 2022, "Benzin", "Manuel", 500M, "/images/clio.jpg", true }
        );
        // Daha fazla örnek veri ekleyebilirsiniz
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "Arac",
            keyColumns: new[] { "Id" },
            keyValues: new object[] { 1 }
        );
        // Daha fazla örnek veri ekleyebilirsiniz
    }
} 