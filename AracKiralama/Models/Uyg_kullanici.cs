using Microsoft.AspNetCore.Identity;

namespace AracKiralama.Models
{
    public class Uyg_kullanici : IdentityUser
    {
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
    }
} 