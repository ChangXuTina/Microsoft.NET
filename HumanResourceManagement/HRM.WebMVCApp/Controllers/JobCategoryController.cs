using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Repository;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRM.WebMVCApp.Controllers
{
    public class JobCategoryController : Controller
    {
        private readonly IJobCategoryServiceAsync jobCategoryServiceAsync;

        public JobCategoryController(IJobCategoryServiceAsync _jobCategoryServiceAsync)
        {
            jobCategoryServiceAsync = _jobCategoryServiceAsync;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var jobCategoryCollection = await jobCategoryServiceAsync.GetAllJobCategoriesAsync();
            return View(jobCategoryCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobCategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobCategoryServiceAsync.AddJobCategoryAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await jobCategoryServiceAsync.GetJobCategoryByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(JobCategoryRequestModel model)
        {
            try
            {
                await jobCategoryServiceAsync.UpdateJobCategoryAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await jobCategoryServiceAsync.GetJobCategoryByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobCategoryResponseModel model)
        {
            await jobCategoryServiceAsync.DeleteJobCategoryAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

