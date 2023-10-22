
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var yas = DateTime.Now.Year - model.DogumYili.Year;
            if (yas < 18)
            {
                ModelState.AddModelError("", "Yaşınız 18'den küçük olduğu için kayıt yapamazsınız!");
                return View(model);
            }
            string msg = await _service.CreateUserAsync(model);
            if (msg == "OK")
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", msg);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var msg = await _service.FindByNameAsync(model);

            if (msg == "user not found")
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(model);
            }
            else if (msg == "OK")
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index", "Anasayfa");
        }
        [HttpGet]
        public async Task<IActionResult> PasswordResetControl()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordResetControl(PasswordResetViewModel model)
        {
            PasswordResetViewModel user = await _service.FindUser(model);
            if (user.Token != null)
            {
                TempData["Token"] = user.Token;
                return RedirectToAction("PasswordReset", "Account", new { id = user.Id });
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı");
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> PasswordReset(int id)
        {
            PasswordResetViewModel model = new PasswordResetViewModel()
            {
                Id = id,
                Token = TempData["Token"].ToString()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> PasswordReset(PasswordResetViewModel model)
        {
            await _service.UpdatePassword(model);
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
