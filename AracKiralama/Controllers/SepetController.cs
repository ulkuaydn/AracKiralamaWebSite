using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AracKiralama.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AracKiralama.Controllers
{
    public class SepetController : Controller
    {
        private readonly AracKiralamaContext _context;
        private readonly UserManager<Uyg_kullanici> _userManager;

        public SepetController(AracKiralamaContext context, UserManager<Uyg_kullanici> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Hesap");

            var sepetItems = await _context.Sepet
                .Include(s => s.Arac)
                .Where(s => s.UserId == user.Id)
                .OrderByDescending(s => s.EklenmeTarihi)
                .ToListAsync();

            return View(sepetItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SepeteEkle(int aracId, DateTime baslangic, DateTime bitis)
        {
            try 
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null) 
                {
                    return RedirectToAction("Login", "Hesap");
                }

                var arac = await _context.Araclar.FindAsync(aracId);
                if (arac == null) 
                {
                    return NotFound();
                }
                var gunSayisi = (bitis - baslangic).Days;
                var toplamUcret = (arac.GunlukUcret * gunSayisi) + 3000;

                var sepetItem = new Sepet
                {
                    UserId = user.Id,
                    AracId = aracId,
                    BaslangicTarihi = baslangic,
                    BitisTarihi = bitis,
                    ToplamUcret = toplamUcret,
                    EklenmeTarihi = DateTime.Now
                };

                _context.Sepet.Add(sepetItem);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Hesap");

            var sepetItem = await _context.Sepet
                .FirstOrDefaultAsync(s => s.Id == id && s.UserId == user.Id);

            if (sepetItem == null) return NotFound();

            _context.Sepet.Remove(sepetItem);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Ürün sepetten çıkarıldı!";
            return RedirectToAction("Index");
        }
 }
}