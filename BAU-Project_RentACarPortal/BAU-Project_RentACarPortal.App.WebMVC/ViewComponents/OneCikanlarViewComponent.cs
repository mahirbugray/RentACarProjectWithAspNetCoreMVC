using BAU_Project_RentACarPortal.App.Entity.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace BAU_Project_RentACarPortal.App.WebMVC.ViewComponents
{
    public class OneCikanlarViewComponent : ViewComponent
    {
        private readonly IArabaService _arabaService;

        public OneCikanlarViewComponent(IArabaService arabaService)
        {
            _arabaService = arabaService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list =await _arabaService.GetAll();
            return View(list.TakeLast(4).ToList());
        }
    }
}
