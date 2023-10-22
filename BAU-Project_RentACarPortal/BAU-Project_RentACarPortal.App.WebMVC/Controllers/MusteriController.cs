using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers
{
    public class MusteriController : Controller
    {
        private readonly IUnitOfWorks _uow;
        private readonly IAccountService _accountService;

        public MusteriController(IUnitOfWorks uow, IAccountService accountService)
        {
            _uow = uow;
            _accountService = accountService;
        }
        public async Task<IActionResult> Index() 
        {
            var users = await _accountService.GetAllUsersAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string msg = await _accountService.DeleteUserByIdAsync(id.ToString());
            if (msg == "OK")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", msg);
            }
            return RedirectToAction("Index");
        }

    }
}
