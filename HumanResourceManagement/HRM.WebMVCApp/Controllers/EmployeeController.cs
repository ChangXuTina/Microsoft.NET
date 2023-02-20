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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync _employeeServiceAsync)
        {
            employeeServiceAsync = _employeeServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var candidateCollection = await employeeServiceAsync.GetAllEmployeesAsync();
            return View(candidateCollection);
        }
        public IActionResult Create()
        {
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

