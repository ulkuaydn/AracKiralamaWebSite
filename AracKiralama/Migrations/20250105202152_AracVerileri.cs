using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracKiralama.Migrations
{
    /// <inheritdoc />
    public partial class AracVerileri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Arac",
                columns: new[] { "Id", "Marka", "Model", "Yil", "YakitTipi", "Vites", "ResimUrl", "Musait", "GunlukUcret" },
                values: new object[,]
                {
                    { 1, "BMW", "M5", 2023, "Benzin", "Otomatik", "/images/bmw.jpg", true, 2500.00m },
                    { 2, "Mercedes", "S-Class", 2023, "Benzin", "Otomatik", "/images/mercedes.jpg", true, 3000.00m },
                    { 3, "Audi", "RS7", 2023, "Benzin", "Otomatik", "/images/audi.jpg", true, 2800.00m },
                    { 4, "Volvo", "XC90", 2023, "Dizel", "Otomatik", "/images/volvo.jpg", true, 2200.00m },
                    { 5, "Tesla", "Model S", 2023, "Elektrik", "Otomatik", "/images/tesla.jpg", true, 2700.00m },
                    { 6, "Porsche", "911", 2023, "Benzin", "Otomatik", "/images/porsche.jpg", true, 3500.00m },
                    { 7, "Range Rover", "Sport", 2023, "Dizel", "Otomatik", "/images/range-rover.jpg", true, 2900.00m },
                    { 8, "Maserati", "Ghibli", 2023, "Benzin", "Otomatik", "/images/maserati.jpg", true, 3200.00m },
                    { 9, "Bentley", "Continental GT", 2023, "Benzin", "Otomatik", "/images/bentley.jpg", true, 4000.00m },
                    { 10,"Rolls-Royce", "Ghost", 2023, "Benzin", "Otomatik", "/images/rolls.jpg", true, 6000.00m },
                    { 11, "Ford Ranger","Jeep",2023,"Dizel","Otomatik","/images/ford_jeep.jpeg",true,1000.00m},
                    { 12, "Dacia", "Duster", 2023, "Benzin", "Otomatik", "/images/araba_7.webp", true, 5200.00m },
                    { 13, "Mini", "Cooper", 2022, "Dizel", "Otomatik", "/images/araba_10.jpg", true, 1050.00m },
                    { 14, "Lexus", "LC500", 2023, "Benzin", "Otomatik", "/images/lexus.jpg", true, 2800.00m },
                    { 15, "Jaguar", "F-Type", 2023, "Benzin", "Otomatik", "/images/jaguar.jpg", true, 2900.00m },
                    { 16, "Maserati", "Ghibli", 2022, "Benzin", "Otomatik", "/images/araba_6.jpeg", true, 900.00m },
                    { 17, "Lotus", "Emira", 2023, "Benzin", "Otomatik", "/images/lotus.jpg", true, 3100.00m },
                    { 18, "Peugeot", "208", 2022, "Benzin", "Manuel", "/images/araba_1.jpeg", true, 1000.00m },
                    { 19, "Chery", "Tiggo", 2022, "Benzin", "Otomatik", "/images/araba_3.jpg", true, 1200.00m },
                    { 20, "Alfa Romeo", "Giulia", 2023, "Benzin", "Otomatik", "/images/alfa.jpg", true, 2400.00m },
                    { 21, "Aston Martin", "DB11", 2022, "Dizel", "Otomatik", "/images/araba_8.jpeg", true, 1100.00m },
                    { 22, "Jeep", "Cherokee", 2022, "Benzin", "Manuel", "/images/araba_9.jpeg", true, 950.00m },
                    { 23, "Lamborghini", "Huracan", 2023, "Benzin", "Otomatik", "/images/lambo.jpg", true, 5000.00m },
                    { 24, "Ferrari", "F8", 2023, "Benzin", "Otomatik", "/images/ferrari.jpg", true, 5500.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Arac",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23,24 });
        }
    }
}
