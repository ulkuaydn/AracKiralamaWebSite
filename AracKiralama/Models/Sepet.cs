using System;
using System.ComponentModel.DataAnnotations;

namespace AracKiralama.Models
{
    public class Sepet
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int AracId { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public decimal ToplamUcret { get; set; }
        public string? PaketTipi { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        
        // Navigation properties
        public virtual Arac? Arac { get; set; }
        public virtual Uyg_kullanici? User { get;set;}
}
}