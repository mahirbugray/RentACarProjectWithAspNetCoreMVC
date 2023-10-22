using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using BAU_Project_RentACarPortal.App.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SigortaController : Controller
    {
        private readonly IUnitOfWorks _uow;
        private readonly ISigortaService _sigortaService;

        public SigortaController(IUnitOfWorks uow, ISigortaService sigortaService)
        {
            _uow = uow;
            _sigortaService = sigortaService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sigortaService.GetAllSigortaAsync();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SigortaViewModel model)
        {   
            if (model.SigortaBitis < model.SigortaBaslangic)
            {
                ModelState.AddModelError("", "Bitiş tarihini hatalı seçtiniz.");
                return View(model);
            }
            await _sigortaService.Add(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sigorta = _sigortaService.GetById(id);
            return View(sigorta);
        }
        [HttpPost]
        public IActionResult Edit(SigortaViewModel model)
        {
            _sigortaService.Edit(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _sigortaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
