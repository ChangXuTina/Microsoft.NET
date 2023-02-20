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
    public class InterviewStatusController : Controller
    {
        private readonly IInterviewStatusServiceAsync interviewStatusServiceAsync;

        public InterviewStatusController(IInterviewStatusServiceAsync _interviewStatusServiceAsync)
        {
            interviewStatusServiceAsync = _interviewStatusServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var interviewStatusCollection = await interviewStatusServiceAsync.GetAllInterviewStatusAsync();
            return View(interviewStatusCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InterviewStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewStatusServiceAsync.AddInterviewStatusAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await interviewStatusServiceAsync.GetInterviewStatusByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InterviewStatusRequestModel model)
        {
            try
            {
                await interviewStatusServiceAsync.UpdateInterviewStatusAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewStatusServiceAsync.GetInterviewStatusByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(InterviewStatusResponseModel model)
        {
            await interviewStatusServiceAsync.DeleteInterviewStatusAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

