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
    public class EmployeeRoleController : Controller
    {
        private readonly IEmployeeRoleServiceAsync employeeRoleServiceAsync;

        public EmployeeRoleController(IEmployeeRoleServiceAsync _employeeRoleServiceAsync)
        {
            employeeRoleServiceAsync = _employeeRoleServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var candidateCollection = await employeeRoleServiceAsync.GetAllEmployeeRolesAsync();
            return View(candidateCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeRoleServiceAsync.AddEmployeeRoleAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await employeeRoleServiceAsync.GetEmployeeRoleByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeRoleRequestModel model)
        {
            try
            {
                await employeeRoleServiceAsync.UpdateEmployeeRoleAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeRoleServiceAsync.GetEmployeeRoleByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeRoleResponseModel model)
        {
            await employeeRoleServiceAsync.DeleteEmployeeRoleAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

