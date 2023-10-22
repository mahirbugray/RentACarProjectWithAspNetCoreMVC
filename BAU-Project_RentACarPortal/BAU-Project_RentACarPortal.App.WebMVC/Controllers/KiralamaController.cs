using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using BAU_Project_RentACarPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    public class KiralamaController : Controller
    {
        private readonly IKiralamaService _kiralamaService;
        private readonly IArabaService _arabaService;
        private readonly IAccountService _accountService;
        private readonly IArabaDetayService _arabaDetayService;
        private readonly IKiralamaDetayService _kiralamaDetayService;
        private readonly ITeslimService _teslimService;

        public KiralamaController(IKiralamaService kiralamaService, IArabaService arabaService, IAccountService accountService, IKiralamaDetayService kiralamaDetayService, ITeslimService teslimService, IArabaDetayService arabaDetayService)
        {
            _kiralamaService = kiralamaService;
            _arabaService = arabaService;
            _accountService = accountService;
            _kiralamaDetayService = kiralamaDetayService;
            _teslimService = teslimService;
            _arabaDetayService = arabaDetayService;
        }
        List<KiralamaDetayViewModel> sepet;
        KiralamaDetay siparis = new KiralamaDetay();
        [Authorize]
        public IActionResult Index()
        {
            sepet = SepetAl();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            TempData["ToplamTutar"] = _kiralamaService.ToplamTutar(sepet).ToString();
            return View(sepet);
        }
        public async Task<IActionResult> Ekle(ArabaDetailsViewModel model, int Gun)
        {
            var araba = await _arabaService.GetById(model.Araba.Id);
            sepet = SepetAl();
            KiralamaDetayViewModel detay = new KiralamaDetayViewModel();
            detay.ArabaId = model.Araba.Id;
            detay.ArabaIsmi = araba.Marka + " " + araba.Model;
            detay.GunlukUcret = araba.SaatlikUcret;
            detay.ToplamAdet = Gun;
            detay.BaslangicTarihi = DateTime.Now;
            sepet = await _kiralamaService.SepeteEkle(sepet, detay);
            SepetKaydet(sepet);
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            TempData["ToplamTutar"] = _kiralamaService.ToplamTutar(sepet).ToString();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Odeme()
        {
            sepet = SepetAl();
            ViewBag.ToplamTutar = _kiralamaService.ToplamTutar(sepet).ToString();
            var musteri = await _accountService.FindAsync(User.Identity.Name);
            return View(musteri);
        }
        public async Task<IActionResult> OdemeOnay()
        {
            sepet = SepetAl();
            Random rnd = new Random();
            var random = rnd.Next(0, 10008);
            var musteri = await _accountService.FindAsync(User.Identity.Name);
            Kiralama kiralama = new Kiralama()
            {
                MusteriId = musteri.Id,
                KiralamaTarihi = DateTime.Now,
                ToplamTutar = _kiralamaService.ToplamTutar(sepet),
                FaturaNo = 0
            };
            var kiralamaId = _kiralamaService.Add(kiralama);
            var kiralamaFaturaNo = await _kiralamaService.FindAsyncKiralama(kiralamaId);
            kiralamaFaturaNo.FaturaNo = kiralamaId;
            _kiralamaService.Update(kiralamaFaturaNo);
            foreach (var item in sepet)
            {
                KiralamaDetay kiralamaDetay = new KiralamaDetay()
                {
                    FaturaNo = kiralamaId,
                    ArabaId = item.ArabaId,
                    KiralamaId = kiralamaId,
                    GunlukUcret = item.GunlukUcret,
                    BaslangicTarihi = DateTime.Now,
                    ToplamAdet = item.ToplamAdet
                };
                var detayId = _kiralamaDetayService.Add(kiralamaDetay);
                var araba = await _arabaService.Get(item.ArabaId);
                var arabadetay = _arabaDetayService.GetById(araba.Id);
                Teslim teslim = new Teslim()
                {
                    ArabaId = araba.Id,
                    Km = Convert.ToInt32(arabadetay.Km),
                    Tarih = DateTime.Now,
                    FaturaNo = detayId
                };
                _teslimService.Add(teslim);
                araba.IsAvailable = false;
                _arabaService.Edit(araba);
                SepetSil();
            }
            return RedirectToAction("Index", "Anasayfa");
        }
        public IActionResult Sil(int id)
        {
            sepet = SepetAl();
            sepet = _kiralamaService.SepettenSil(sepet, id);
            SepetKaydet(sepet);
            return RedirectToAction("Index");
        }
        public List<KiralamaDetayViewModel> SepetAl()
        {
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            return sepet;
        }
        public void SepetKaydet(List<KiralamaDetayViewModel> sepet)
        {
            HttpContext.Session.SetJson("sepet", sepet);
        }
        public IActionResult SepetSil()
        {
            HttpContext.Session.Clear();    //Oturumda bulunan tüm session'ları siler.
            //HttpContext.Session.Remove("sepet"); sadece ismi belirtilen session'ı siler.
            return RedirectToAction("Index");
        }
    }
}
