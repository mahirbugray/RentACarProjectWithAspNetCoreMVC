using BAU_Project_RentACarPortal.App.Entity.Entities;
using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FirmaController : Controller
    {
        private readonly IFirmaService _firmaService;
        private readonly IUnitOfWorks _uow;

        public FirmaController(IFirmaService firmaService, IUnitOfWorks uow)
        {
            _firmaService = firmaService;
            _uow = uow;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _firmaService.GetAllFirmaAsync();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FirmaViewModel model)
        {
            await _firmaService.Add(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var firma = _firmaService.GetById(id);
            return View(firma);
        }
        [HttpPost]
        public IActionResult Edit(FirmaViewModel model)
        {
            _firmaService.Edit(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _firmaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
