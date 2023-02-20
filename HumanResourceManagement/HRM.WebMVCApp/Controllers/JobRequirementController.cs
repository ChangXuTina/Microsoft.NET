using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRM.WebMVCApp.Controllers
{
    public class JobRequirementController : Controller
    {
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;

        public JobRequirementController(IJobRequirementServiceAsync _jobRequirementServiceAsync)
        {
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var jobRequirementCollection = await jobRequirementServiceAsync.GetAllJobRequirementsAsync();
            return View(jobRequirementCollection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobRequirementRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobRequirementServiceAsync.AddJobRequirementAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobRequirementRequestModel model)
        {
            try
            {
                await jobRequirementServiceAsync.UpdateJobRequirementAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobRequirementResponseModel model)
        {
            await jobRequirementServiceAsync.DeleteJobRequirementAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

