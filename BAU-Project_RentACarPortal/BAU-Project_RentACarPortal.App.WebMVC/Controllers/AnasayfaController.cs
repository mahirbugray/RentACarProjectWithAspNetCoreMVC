using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using BAU_Project_RentACarPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
	public class AnasayfaController : Controller
	{
		private readonly IKiralamaService _kiralamaService;
        private readonly IArabaService _arabaService;
        private readonly IAccountService _accountService;
        private readonly IFirmaService _firmaService;
        private readonly IDegerlendirmeService _degerlendirmeService;

        public AnasayfaController(IKiralamaService kiralamaService, IAccountService accountService, IArabaService arabaService, IFirmaService firmaService, IDegerlendirmeService degerlendirmeService)
        {
            _kiralamaService = kiralamaService;
            _accountService = accountService;
            _arabaService = arabaService;
            _firmaService = firmaService;
            _degerlendirmeService = degerlendirmeService;
        }

        public async Task<IActionResult> Index()
		{
            var arabalar = await _arabaService.GetAll();
            ViewBag.Arabalar = arabalar.Count();
            var musteriler = await _accountService.GetAllUsersAsync();
            ViewBag.Musteriler = musteriler.Count();    
            var firmalar = await _firmaService.GetAllFirmaAsync();
            ViewBag.Firmalar = firmalar.Count();
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            return View();
		}
		public IActionResult Iletisim()
		{
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            return View();
		}
		public IActionResult Kurumsal()
		{
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            return View();
		}
		public IActionResult IKPolitika()
		{
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            return View();
		}
		public IActionResult Vizyon()
		{
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            return View();
		}
		public IActionResult Hakkimizda()
		{
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            return View();
		}
	}
}
