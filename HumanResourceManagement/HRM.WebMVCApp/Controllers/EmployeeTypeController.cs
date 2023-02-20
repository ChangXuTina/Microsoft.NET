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
    public class EmployeeTypeController : Controller
    {
        private readonly IEmployeeTypeServiceAsync employeeTypeServiceAsync;

        public EmployeeTypeController(IEmployeeTypeServiceAsync _employeeTypeServiceAsync)
        {
            employeeTypeServiceAsync = _employeeTypeServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var candidateCollection = await employeeTypeServiceAsync.GetAllEmployeeTypesAsync();
            return View(candidateCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeTypeServiceAsync.AddEmployeeTypeAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await employeeTypeServiceAsync.GetEmployeeTypeByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeTypeRequestModel model)
        {
            try
            {
                await employeeTypeServiceAsync.UpdateEmployeeTypeAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeTypeServiceAsync.GetEmployeeTypeByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeTypeResponseModel model)
        {
            await employeeTypeServiceAsync.DeleteEmployeeTypeAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

