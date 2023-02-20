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
    public class SubmissionController : Controller
    {
        private readonly ISubmissionServiceAsync submissionServiceAsync;

        public SubmissionController(ISubmissionServiceAsync _submissionServiceAsync)
        {
            submissionServiceAsync = _submissionServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var submissionCollection = await submissionServiceAsync.GetAllSubmissionsAsync();
            return View(submissionCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await submissionServiceAsync.AddSubmissiontAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await submissionServiceAsync.GetSubmissionByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SubmissionRequestModel model)
        {
            try
            {
                await submissionServiceAsync.UpdateSubmissionAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await submissionServiceAsync.GetSubmissionByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SubmissionResponseModel model)
        {
            await submissionServiceAsync.DeleteSubmissionAsync(model.id);
            return RedirectToAction("Index");
        }
    }
}

