using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AracKiralama.Models;
using Microsoft.AspNetCore.Identity;

namespace AracKiralama.Controllers
{
    [Authorize]
    public class KiralamaController : Controller
    {
        private readonly AracKiralamaContext _context;
        private readonly UserManager<Uyg_kullanici> _userManager;

        public KiralamaController(AracKiralamaContext context, UserManager<Uyg_kullanici> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index(int id)
        {
            if (!User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Login", "Hesap", new { returnUrl = Url.Action("Index", "Kiralama", new { id }) });
            }

            var arac = _context.Araclar.FirstOrDefault(a => a.Id == id);
            if (arac == null) return NotFound();

            var kiralama = new Kiralama
            {
                AracId = arac.Id,
                Arac = arac,
                BaslangicTarihi = DateTime.Now,
                BitisTarihi = DateTime.Now.AddDays(1)
            };

            return View(kiralama);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Kiralama model)
        {
            try
            {
                var arac = await _context.Araclar.FindAsync(model.AracId);
                if (arac == null)
                {
                    TempData["Error"] = "Seçilen araç bulunamadı!";
                    return View(model);
                }

                if (model.BaslangicTarihi >= model.BitisTarihi)
                {
                    TempData["Error"] = "Başlangıç tarihi bitiş tarihinden sonra olamaz!";
                    return View(model);
                }

                // Aracın müsait olup olmadığını kontrol et
                var varOlanKiralama = await _context.Kiralamalar
                    .AnyAsync(k => k.AracId == model.AracId 
                        && k.Durum != KiralamaDurumu.Reddedildi
                        && ((model.BaslangicTarihi >= k.BaslangicTarihi && model.BaslangicTarihi <= k.BitisTarihi)
                        || (model.BitisTarihi >= k.BaslangicTarihi && model.BitisTarihi <= k.BitisTarihi)));

                if (varOlanKiralama)
                {
                    TempData["Error"] = "Bu araç seçilen tarihler arasında başka bir müşteri tarafından kiralanmış!";
                    return View(model);
                }

                // Yeni kiralama oluştur
                var kiralama = new Kiralama
                {
                    AracId = model.AracId,
                    BaslangicTarihi = model.BaslangicTarihi,
                    BitisTarihi = model.BitisTarihi,
                    OlusturulmaTarihi = DateTime.Now,
                    ToplamTutar = (model.BitisTarihi - model.BaslangicTarihi).Days * arac.GunlukUcret + 3000, // 3000 TL depozito
                    Durum = KiralamaDurumu.Beklemede
                };

                _context.Kiralamalar.Add(kiralama);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Kiralama talebiniz alındı. En kısa sürede size dönüş yapılacaktır.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Kiralama işlemi sırasında bir hata oluştu: " + ex.Message;
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Onayla()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Hesap");

            var sepetItems = await _context.Sepet
                .Include(s => s.Arac)
                .Where(s => s.UserId == user.Id)
                .ToListAsync();

            foreach (var item in sepetItems)
            {
                var kiralama = new Kiralama
                {
                    AracId = item.AracId,
                    BaslangicTarihi = item.BaslangicTarihi,
                    BitisTarihi = item.BitisTarihi,
                    OlusturulmaTarihi = DateTime.Now,
                    ToplamTutar = item.ToplamUcret,
                    Durum = KiralamaDurumu.Beklemede
                };

                _context.Kiralamalar.Add(kiralama);
                _context.Sepet.Remove(item);
            }

            await _context.SaveChangesAsync();
            TempData["Success"] ="Kiralama işleminiz başarıyla tamamlandı!";
            return RedirectToAction("Index", "Home");
 }
}
}