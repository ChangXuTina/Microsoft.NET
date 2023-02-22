using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRM.WebMVCApp.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleServiceAsync userRoleServiceAsync;
        private readonly IRoleServiceAsync roleServiceAsync;
        private readonly IUserServiceAsync userServiceAsync;

        public UserRoleController(
            IUserRoleServiceAsync _userRoleServiceAsync,
            IRoleServiceAsync _roleServiceAsync,
            IUserServiceAsync _userServiceAsync)
        {
            userRoleServiceAsync = _userRoleServiceAsync;
            roleServiceAsync = _roleServiceAsync;
            userServiceAsync = _userServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var userRoleCollection = await userRoleServiceAsync.GetAllUserRolesAsync();
            return View(userRoleCollection);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.RoleList = new SelectList(await roleServiceAsync.GetAllRolesAsync(), "Id", "Name");
            ViewBag.UserList = new SelectList(await userServiceAsync.GetAllUsersAsync(), "Id", "Username");
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
            ViewBag.RoleList = new SelectList(await roleServiceAsync.GetAllRolesAsync(), "Id", "Name");
            ViewBag.UserList = new SelectList(await userServiceAsync.GetAllUsersAsync(), "Id", "Username");
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

