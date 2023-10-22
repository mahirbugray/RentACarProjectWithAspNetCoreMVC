using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using BAU_Project_RentACarPortal.App.Service.Services;
using BAU_Project_RentACarPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    public class ArabalarController : Controller
    {
        private readonly IArabaService _arabaService;
        private readonly IArabaDetayService _arabaDetayService;
        private readonly IKategoriService _kategoriService;
        private readonly IFirmaService _firmaService;
        private readonly ISigortaService _sigortaService;
        private readonly IKiralamaService _kiralamaService;
        private readonly IDegerlendirmeService _degerlendirmeService;
        private readonly IAccountService _accountService;


        public ArabalarController(IArabaService arabaService, IArabaDetayService arabaDetayService, IKategoriService kategoriService, IFirmaService firmaService, ISigortaService sigortaService, IKiralamaService kiralamaService, IDegerlendirmeService degerlendirmeService, IAccountService accountService)
        {
            _arabaService = arabaService;
            _arabaDetayService = arabaDetayService;
            _kategoriService = kategoriService;
            _firmaService = firmaService;
            _sigortaService = sigortaService;
            _kiralamaService = kiralamaService;
            _degerlendirmeService = degerlendirmeService;
            _accountService = accountService;
        }
        public async Task<IActionResult> Index(int id)
        {
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            ArabaIndexViewModel model = new();
            ViewBag.Kategoriler = await _kategoriService.GetAllKategoriAsync();
            if (id == 0)
            {
                var arabaIndex = _arabaService.GetAllDetay();
                var arabaDetayIndex = _arabaDetayService.GetAllDetay();
                model.ArabaIndex = arabaIndex;
                model.ArabaDetayIndex = arabaDetayIndex;
            }
            else if(id != 0)
            {
                var arabaIndex = await _arabaService.GetAllArabaWithFilterKategori(id);
                var arabaDetayIndex = await _arabaDetayService.GetByArabaFiltre(id);
                model.ArabaDetayIndex = arabaDetayIndex;
                model.ArabaIndex = (List<ArabaViewModel>)arabaIndex;
            }

            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Degerlendirmeler = await _degerlendirmeService.GetAllArabaId(id);
            var araba = await _arabaService.GetById(id);
            var arabaDetay = _arabaDetayService.GetById(id);
            ArabaDetailsViewModel model = new()
            {
                Araba = araba,
                ArabaDetay = arabaDetay
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminIndex()
        {
            var list = await _arabaService.GetAllWithFiltered(null, x => x.ArabaKategori, x => x.Firma, x => x.Sigorta);
            return View(list);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var kategoriler = await _kategoriService.GetAllKategoriAsync();
            var firma = await _firmaService.GetAllFirmaAsync();
            var sigorta = await _sigortaService.GetAllSigortaAsync();
            ViewBag.Kategori = new SelectList(kategoriler, "Id", "KategoriAdi"); 
            ViewBag.Firma = new SelectList(firma, "Id", "FirmaAdi"); 
            ViewBag.Sigorta = new SelectList(sigorta, "Id", "SigortaAdi"); 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ArabaViewModel araba, IFormFile formFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", formFile.FileName);
            var stream = new FileStream(path, FileMode.Create);
            formFile.CopyTo(stream);
            araba.Resim = "/images/" + formFile.FileName;    //Yüklenen resim isimlerinde çakışma olmaması için ismin sonuna uniq id bilgisini ekliyoruz.
            await _arabaService.Add(araba);
            return RedirectToAction("CreateDetails", "Arabalar");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var sigorta = await _sigortaService.GetAllSigortaAsync();
            ViewBag.Sigorta = new SelectList(sigorta, "Id", "SigortaAdi");
            var araba = await _arabaService.GetById(id);
            return View(araba);
        }
        [HttpPost]
        public IActionResult Edit(ArabaViewModel araba, IFormFile formFile)
        {
            if(formFile != null) {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", formFile.FileName);
            var stream = new FileStream(path, FileMode.Create);
            formFile.CopyTo(stream);
            araba.Resim = "/images/" + formFile.FileName; //Yüklenen resim isimlerinde çakışma olmaması için ismin sonuna uniq id bilgisini ekliyoruz.
            }
            _arabaService.Update(araba);
            return RedirectToAction("AdminIndex", "Arabalar");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _arabaService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateDetails()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDetails(ArabaDetayViewModel model)
        {
            model.ArabaId = await _arabaService.LastCar();
            await _arabaDetayService.Add(model);
            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateDegerlendirme (int id, string message)
        {
            var user = await _accountService.FindAsync(User.Identity.Name);
            DegerlendirmeViewModel model = new DegerlendirmeViewModel
            {
                ArabaId = id,
                Yorum = message,
                MusteriId = user.Id,
                MusteriAdi = user.Name,
                YorumTarihi = DateTime.Now
            };
            await _degerlendirmeService.Add(model);
            return RedirectToAction("Index");
        }
    }
}
