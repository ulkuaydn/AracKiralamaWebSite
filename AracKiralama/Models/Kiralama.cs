using System.ComponentModel.DataAnnotations;

namespace AracKiralama.Models
{
    public enum KiralamaDurumu
    {
        Beklemede,
        Onaylandi,
        Reddedildi,
        Tamamlandi
    }

    public class Kiralama
    {
        public int Id { get; set; }
        public int AracId { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public KiralamaDurumu Durum { get; set; }
        
        public virtual Arac? Arac { get;set;}
}
}