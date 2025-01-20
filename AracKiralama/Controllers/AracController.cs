using Microsoft.AspNetCore.Mvc;
using AracKiralama.Models;
using Microsoft.EntityFrameworkCore;

namespace AracKiralama.Controllers
{
    public class AracController : Controller
    {
        private readonly AracKiralamaContext _context;

        public AracController(AracKiralamaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var araclar = await _context.Araclar.ToListAsync();
            return View(araclar);
        }
    
        [HttpPost]
        public IActionResult KiralamayaBasla(int id)
        {
            return RedirectToAction("SepeteEkle", "Sepet", new { aracId = id, 
                baslangic = DateTime.Now, 
                bitis = DateTime.Now.AddDays(1) });
        }

        public async Task<IActionResult> Detay(int id)
        {
            var arac = await _context.Araclar.FindAsync(id);
            if (arac == null) return NotFound();

            var kiralama = new Kiralama
            {
                AracId = arac.Id,
                Arac = arac,
                BaslangicTarihi = DateTime.Now,
                BitisTarihi = DateTime.Now.AddDays(1),
                OlusturulmaTarihi = DateTime.Now,
                Durum = KiralamaDurumu.Beklemede
            };

            return View(kiralama);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kiralama kiralama)
        {
            if (ModelState.IsValid)
            {
                var arac = await _context.Araclar.FindAsync(kiralama.AracId);
                if (arac != null)
                {
                    kiralama.ToplamTutar = await HesaplaToplamTutar(kiralama);
                    _context.Kiralamalar.Add(kiralama);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(kiralama);
        }

        private async Task<decimal> HesaplaToplamTutar(Kiralama kiralama)
        {
            var arac = await _context.Araclar.FindAsync(kiralama.AracId);
            if (arac == null) return 0;
            
            var gunSayisi = (kiralama.BitisTarihi - kiralama.BaslangicTarihi).Days;
            return (arac.GunlukUcret * gunSayisi) + 3000; // 3000 TL depozito
 }
}
}