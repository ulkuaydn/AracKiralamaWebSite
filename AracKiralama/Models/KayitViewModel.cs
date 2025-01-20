using System.ComponentModel.DataAnnotations;

namespace AracKiralama.Models
{
    public class KayitViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        public string? Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        public string? Soyad { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
        public string? Sifre { get; set; }
    }
} 