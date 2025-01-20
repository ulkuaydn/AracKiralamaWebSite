using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AracKiralama.Models;
using Microsoft.AspNetCore.Identity;

namespace AracKiralama.Controllers
{
    public class HesapController : Controller
    {
        private readonly UserManager<Uyg_kullanici> _userManager;
        private readonly SignInManager<Uyg_kullanici> _signInManager;

        public HesapController(UserManager<Uyg_kullanici> userManager, SignInManager<Uyg_kullanici> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid && model.Email != null && model.Sifre != null)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Sifre, 
                    model.BeniHatirla, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
            }
            return View(model);
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        [Route("Hesap/Kayit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Kayit(KayitViewModel model)
        {
            if (ModelState.IsValid && model.Email != null && model.Sifre != null)
            {
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Bu e-posta adresi zaten kullanılıyor.");
                    return View(model);
                }

                var user = new Uyg_kullanici
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Ad = model.Ad,
                    Soyad = model.Soyad
                };

                var result = await _userManager.CreateAsync(user, model.Sifre);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    var turkceHata = error.Code switch
                    {
                        "DuplicateUserName" => "Bu kullanıcı adı zaten kullanılıyor.",
                        "DuplicateEmail" => "Bu e-posta adresi zaten kullanılıyor.",
                        "InvalidUserName" => "Geçersiz kullanıcı adı.",
                        "InvalidEmail" => "Geçersiz e-posta adresi.",
                        "PasswordTooShort" => "Şifre çok kısa.",
                        _ => "Bir hata oluştu."
                    };
                    ModelState.AddModelError("", turkceHata);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
{
    await _signInManager.SignOutAsync();  // Kullanıcıyı çıkart
    return RedirectToAction("Index", "Home");  // Çıkış yaptıktan sonra Home sayfasına yönlendir
}
    }
} 