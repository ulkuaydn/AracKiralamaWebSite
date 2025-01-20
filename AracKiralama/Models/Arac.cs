using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace AracKiralama.Models
{
    public class Arac
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Marka alanı zorunludur")]
        public string? Marka { get; set; }
        
        [Required(ErrorMessage = "Model alanı zorunludur")]
        public string? Model { get; set; }
        
        [Required(ErrorMessage = "Yıl alanı zorunludur")]
        public int Yil { get; set; }
        
        public string? YakitTipi { get; set; }
        public string? Vites { get; set; }
        public string? ResimUrl { get; set; }
        public bool Musait { get; set; }
        
        [Required(ErrorMessage = "Günlük ücret zorunludur")]
        [Range(0, double.MaxValue, ErrorMessage = "Geçerli bir ücret giriniz")]
        public decimal GunlukUcret { get; set; }
        
        public string? Resim { get; set; }
    }
}