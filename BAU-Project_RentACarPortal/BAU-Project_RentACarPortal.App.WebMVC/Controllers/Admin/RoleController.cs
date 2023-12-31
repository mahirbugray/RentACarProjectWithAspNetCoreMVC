﻿using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAU_Project_RentACarPortal.App.WebMVC.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IAccountService _accountService;

        public RoleController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _accountService.GetRoles();
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            string msg = await _accountService.CreateRoleAsync(model);

            if (msg == "OK")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", msg);
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var model = await _accountService.GetAllUsersByRole(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            string msg = await _accountService.EditRoleListAsync(model);
            if (msg != "OK")
            {
                ModelState.AddModelError("", msg);
                return View(model);
            }
            return RedirectToAction("Edit", "Role", new { id = model.RoleId });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountService.DeleteRoleAsync(id);
            return RedirectToAction("Index", "Role");
        }
    }
}

