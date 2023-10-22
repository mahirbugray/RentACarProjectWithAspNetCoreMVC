using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using BAU_Project_RentACarPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    public class SepetController : Controller
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IKiralamaDetayService _kiralamaDetayService;
        private readonly IKiralamaService _kiralamaService;
        private readonly IArabaService _arabaService;
        private readonly ISepetDetayService _sepetDetayService;

        public SepetController(IUnitOfWorks unitOfWorks, IKiralamaDetayService kiralamaDetayService, IKiralamaService kiralamaService, IArabaService arabaService, ISepetDetayService sepetDetayService)
        {
            _unitOfWorks = unitOfWorks;
            _kiralamaDetayService = kiralamaDetayService;
            _kiralamaService = kiralamaService;
            _arabaService = arabaService;
            _sepetDetayService = sepetDetayService;
        }
        List<SepetDetayViewModel> sepet;
        SepetDetayViewModel siparis = new SepetDetayViewModel();
        public IActionResult Index()
        {
            sepet = SepetAl();
            TempData["ToplamAdet"] = _sepetDetayService.ToplamAdet(sepet).ToString();
            TempData["ToplamTutar"] = _sepetDetayService.ToplamTutar(sepet).ToString();
            return View(sepet);
        }
        public async Task<IActionResult> Ekle(int Id, int Adet)
        {
            var araba = await _arabaService.GetById(Id);
            sepet = SepetAl();
            //SepetDetay siparis = new SepetDetay();
            siparis.ArabaId = araba.Id;
            siparis.ArabaMarka = araba.Marka;
            siparis.ArabaAdet = 1;
            siparis.ArabaUcret = araba.SaatlikUcret;
            sepet = _sepetDetayService.SepeteEkle(sepet, siparis);
            SepetKaydet(sepet);
            TempData["ToplamAdet"] = _sepetDetayService.ToplamAdet(sepet).ToString();
            TempData["ToplamTutar"] = _sepetDetayService.ToplamTutar(sepet).ToString();
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            sepet = SepetAl();
            sepet = _sepetDetayService.SepettenSil(sepet, id);
            SepetKaydet(sepet);
            return RedirectToAction("Index");
        }
        public List<SepetDetayViewModel> SepetAl()
        {
            var sepet = HttpContext.Session.GetJson<List<SepetDetayViewModel>>("sepet") ?? new List<SepetDetayViewModel>();
            return sepet;
        }
        public void SepetKaydet(List<SepetDetayViewModel> sepet)
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
