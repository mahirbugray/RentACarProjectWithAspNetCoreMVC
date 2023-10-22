using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IKiralamaService _kiralamaService;
        private readonly IArabaService _arabaService;
        private readonly IAccountService _accountService;
        private readonly IFirmaService _firmaService;
        public AdminController(IKiralamaService kiralamaService, IArabaService arabaService, IAccountService accountService, IFirmaService firmaService)
        {
            _kiralamaService = kiralamaService;
            _arabaService = arabaService;
            _accountService = accountService;
            _firmaService = firmaService;
        }

        public async Task<IActionResult> Index()
        {
            var total = await _kiralamaService.GetAllKiralama();
            ViewBag.ToplamHasılat = total.Sum(x => x.ToplamTutar);
            var araba = await _arabaService.GetAll();
            ViewBag.arabalar = araba.Count();
            var musteri = await _accountService.GetAllUsersAsync();
            ViewBag.Musteriler = musteri.Count();
            var firma = await _firmaService.GetAllFirmaAsync();
            ViewBag.Firmalar = firma.Count();
            var arabaGuncellenecekler = await _arabaService.GetAllArabaAdmin();
            ViewBag.Guncellenecekler = arabaGuncellenecekler.Count();
            return View();
        }
        public async Task<IActionResult> ArabaListele()
        {
            var arabalar = await _arabaService.GetAllArabaAdmin();
            return View(arabalar);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int HasarDurumu, int Id)
        {
            await _arabaService.UpdateAdmin(HasarDurumu, Id);
            return RedirectToAction("AdminIndex", "Arabalar");
        }
    }
}
