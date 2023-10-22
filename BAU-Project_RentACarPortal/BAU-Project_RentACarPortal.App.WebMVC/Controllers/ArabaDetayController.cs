using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using BAU_Project_RentACarPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    public class ArabaDetayController : Controller
    {
        private readonly IArabaDetayService _arabaDetayService;
        private readonly IArabaService _arabaService;
        private readonly IKiralamaService _kiralamaService;

        public ArabaDetayController(IArabaDetayService arabaDetayService, IArabaService arabaService, IKiralamaService kiralamaService)
        {
            _arabaDetayService = arabaDetayService;
            _arabaService = arabaService;
            _kiralamaService = kiralamaService;
        }

        public async Task<IActionResult> Index(int id)  //id = arabanın id si
        {
            var sepet = HttpContext.Session.GetJson<List<KiralamaDetayViewModel>>("sepet") ?? new List<KiralamaDetayViewModel>();
            TempData["ToplamAdet"] = _kiralamaService.ToplamAdet(sepet).ToString();
            ArabaDetailsViewModel model = new ArabaDetailsViewModel();
            model.ArabaDetay = _arabaDetayService.GetById(id);
            model.Araba = await _arabaService.GetById(id);
            return View(model);
        }
    }
}
