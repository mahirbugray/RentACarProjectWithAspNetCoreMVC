using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using BAU_Project_RentACarPortal.App.Service.Services;
using BAU_Project_RentACarPortal.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    public class ProfilController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IKiralamaService _kiralamaService;
        private readonly IArabaDetayService _arabaDetayService;
        private readonly IKiralamaDetayService _kiralamaDetayService;
        private readonly IDevirService _devirService;
        private readonly IArabaService _arabaService;


        public ProfilController(IAccountService accountService, IKiralamaService kiralamaService, IArabaDetayService arabaDetayService, IKiralamaDetayService kiralamaDetayService, IDevirService devirService, IArabaService arabaService)
        {
            _accountService = accountService;
            _kiralamaService = kiralamaService;
            _arabaDetayService = arabaDetayService;
            _kiralamaDetayService = kiralamaDetayService;
            _devirService = devirService;
            _arabaService = arabaService;
        }

        public async Task<IActionResult> Index()
        {
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            var user = await _accountService.FindAsync(User.Identity.Name);
            ViewBag.Kiralama = await _kiralamaService.FindKiralamaAsync(user.Id);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> ProfilBilgiGuncelle()
        {
            var kullanici = await _accountService.FindAsync(User.Identity.Name);
            var model = new UserViewModel
            {
                Id = kullanici.Id,
                Name = kullanici.Name,
                Surname = kullanici.Surname,
                Username = kullanici.Username,
                PhoneNumber = kullanici.PhoneNumber,
                TCKNo = kullanici.TCKNo,
                Cinsiyet = kullanici.Cinsiyet,
                DogumYili = kullanici.DogumYili,
                Adres = kullanici.Adres,
                Email = kullanici.Email
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ProfilBilgiGuncelle(UserViewModel model, string SuankiSifre)
        {
            var kullanici = await _accountService.UpdateUserInformation(model, SuankiSifre);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Devret(int faturaNo)
        {
            var fatura = await _kiralamaDetayService.GetKiralamaDetayAsync(faturaNo);
            DevirViewModel devirViewModel = new DevirViewModel()
            {
                FaturaNo = faturaNo,
                ArabaId = fatura.ArabaId
            };
            return View(devirViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Devret(DevirViewModel model)
        {
            model.Tarih = DateTime.Now;
            await _devirService.Add(model);
            return RedirectToAction("Index");
        }
    }
}
