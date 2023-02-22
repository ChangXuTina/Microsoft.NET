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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;
        private readonly IEmployeeRoleServiceAsync employeeRoleServiceAsync;
        private readonly IEmployeeTypeServiceAsync employeeTypeServiceAsync;
        private readonly IEmployeeStatusServiceAsync employeeStatusServiceAsync;

        public EmployeeController(
            IEmployeeServiceAsync _employeeServiceAsync,
            IEmployeeRoleServiceAsync _employeeRoleServiceAsync,
            IEmployeeTypeServiceAsync _employeeTypeServiceAsync,
            IEmployeeStatusServiceAsync _employeeStatusServiceAsync
            )
        {
            employeeServiceAsync = _employeeServiceAsync;
            employeeRoleServiceAsync = _employeeRoleServiceAsync;
            employeeTypeServiceAsync = _employeeTypeServiceAsync;
            employeeStatusServiceAsync = _employeeStatusServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var candidateCollection = await employeeServiceAsync.GetAllEmployeesAsync();
            return View(candidateCollection);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.EmployeeRoleList = new SelectList(await employeeRoleServiceAsync.GetAllEmployeeRolesAsync(), "Id", "Title");
            ViewBag.EmployeeTypeList = new SelectList(await employeeTypeServiceAsync.GetAllEmployeeTypesAsync(), "Id", "Title");
            ViewBag.EmployeeStatusList = new SelectList(await employeeStatusServiceAsync.GetAllEmployeeStatusAsync(), "Id", "Title");
            ViewBag.ManagerList = new SelectList(await employeeServiceAsync.GetAllEmployeesAsync(), "Id", "FirstName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeServiceAsync.AddEmployeeAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.EmployeeRoleList = new SelectList(await employeeRoleServiceAsync.GetAllEmployeeRolesAsync(), "Id", "Title");
            ViewBag.EmployeeTypeList = new SelectList(await employeeTypeServiceAsync.GetAllEmployeeTypesAsync(), "Id", "Title");
            ViewBag.EmployeeStatusList = new SelectList(await employeeStatusServiceAsync.GetAllEmployeeStatusAsync(), "Id", "Title");
            ViewBag.ManagerList = new SelectList(await employeeServiceAsync.GetAllEmployeesAsync(), "Id", "FirstName");
            var result = await employeeServiceAsync.GetEmployeeByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeRequestModel model)
        {
            try
            {
                await employeeServiceAsync.UpdateEmployeeAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeServiceAsync.GetEmployeeByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeResponseModel model)
        {
            await employeeServiceAsync.DeleteEmployeeAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

