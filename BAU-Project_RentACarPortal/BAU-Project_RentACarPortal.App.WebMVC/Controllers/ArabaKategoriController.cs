using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArabaKategoriController : Controller
    {
        private readonly IKategoriService _kategoriService;
        private readonly IUnitOfWorks _uow;

        public ArabaKategoriController(IUnitOfWorks uow, IKategoriService kategoriService)
        {
            _uow = uow;
            _kategoriService = kategoriService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _kategoriService.GetAllKategoriAsync();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KategoriViewModel model)
        {
            await _kategoriService.Add(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kategori = _kategoriService.GetById(id);
            return View(kategori);
        }
        [HttpPost]
        public IActionResult Edit(KategoriViewModel model)
        {
            _kategoriService.Edit(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _kategoriService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
