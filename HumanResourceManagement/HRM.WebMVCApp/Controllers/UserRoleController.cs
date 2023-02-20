using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRM.WebMVCApp.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleServiceAsync userRoleServiceAsync;

        public UserRoleController(IUserRoleServiceAsync _userRoleServiceAsync)
        {
            userRoleServiceAsync = _userRoleServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var userRoleCollection = await userRoleServiceAsync.GetAllUserRolesAsync();
            return View(userRoleCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await userRoleServiceAsync.AddUserRoleAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await userRoleServiceAsync.GetUserRoleByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserRoleRequestModel model)
        {
            try
            {
                await userRoleServiceAsync.UpdateUserRoleAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await userRoleServiceAsync.GetUserRoleByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserRoleResponseModel model)
        {
            await userRoleServiceAsync.DeleteUserRoleAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

