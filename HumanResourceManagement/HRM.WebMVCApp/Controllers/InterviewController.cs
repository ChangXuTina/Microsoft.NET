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
    public class InterviewController : Controller
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;

        public InterviewController(IInterviewServiceAsync _interviewServiceAsync)
        {
            interviewServiceAsync = _interviewServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var interviewCollection = await interviewServiceAsync.GetAllInterviewsAsync();
            return View(interviewCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InterviewRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewServiceAsync.AddInterviewAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await interviewServiceAsync.GetInterviewByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InterviewRequestModel model)
        {
            try
            {
                await interviewServiceAsync.UpdateInterviewAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewServiceAsync.GetInterviewByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(InterviewResponseModel model)
        {
            await interviewServiceAsync.DeleteInterviewAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

