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
    public class UserController : Controller
    {
        private readonly IUserServiceAsync userServiceAsync;

        public UserController(IUserServiceAsync _userServiceAsync)
        {
            userServiceAsync = _userServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var userCollection = await userServiceAsync.GetAllUsersAsync();
            return View(userCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await userServiceAsync.AddUserAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await userServiceAsync.GetUserByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserRequestModel model)
        {
            try
            {
                await userServiceAsync.UpdateUserAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await userServiceAsync.GetUserByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserResponseModel model)
        {
            await userServiceAsync.DeleteUserAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

