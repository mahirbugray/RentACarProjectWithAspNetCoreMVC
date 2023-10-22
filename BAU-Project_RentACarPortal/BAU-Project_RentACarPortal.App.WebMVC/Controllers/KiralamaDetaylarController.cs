using BAU_Project_RentACarPortal.App.Entity.Services;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    public class KiralamaDetaylarController : Controller
    {
        private readonly IKiralamaDetayService _kiralamaDetaylarService;

        public KiralamaDetaylarController(IKiralamaDetayService kiralamaDetaylarService)
        {
            _kiralamaDetaylarService = kiralamaDetaylarService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _kiralamaDetaylarService.GetAllKiralamaDetayAsync();
            return View(list);
        }
    }
}
