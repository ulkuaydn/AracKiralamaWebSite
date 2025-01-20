using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AracKiralama.Models
{
    public class AracKiralamaContext : IdentityDbContext<Uyg_kullanici>
    {
        public AracKiralamaContext(DbContextOptions<AracKiralamaContext> options)
            : base(options)
        {
        }

        public required DbSet<Arac> Araclar { get; set; }
        public required DbSet<Kiralama> Kiralamalar { get; set; }
        public required DbSet<Sepet> Sepet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Arac>(entity =>
            {
                entity.ToTable("Arac");
                entity.Property(e => e.GunlukUcret).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Kiralama>(entity =>
            {
                entity.ToTable("Kiralama");
                entity.Property(e => e.ToplamTutar).HasPrecision(10, 2);

                entity.HasOne(k => k.Arac)
                    .WithMany()
                    .HasForeignKey(k => k.AracId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Sepet>(entity =>
            {
                entity.HasOne(s => s.Arac)
                    .WithMany()
                    .HasForeignKey(s => s.AracId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.User)
                    .WithMany()
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
 }
}
}