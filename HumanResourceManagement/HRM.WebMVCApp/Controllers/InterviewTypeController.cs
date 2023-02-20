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
    public class InterviewTypeController : Controller
    {
        private readonly IInterviewTypeServiceAsync interviewTypeServiceAsync;

        public InterviewTypeController(IInterviewTypeServiceAsync _interviewTypeServiceAsync)
        {
            interviewTypeServiceAsync = _interviewTypeServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var interviewTypeCollection = await interviewTypeServiceAsync.GetAllInterviewTypesAsync();
            return View(interviewTypeCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InterviewTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewTypeServiceAsync.AddInterviewTypeAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await interviewTypeServiceAsync.GetInterviewTypeByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InterviewTypeRequestModel model)
        {
            try
            {
                await interviewTypeServiceAsync.UpdateInterviewTypeAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewTypeServiceAsync.GetInterviewTypeByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(InterviewTypeResponseModel model)
        {
            await interviewTypeServiceAsync.DeleteInterviewTypeAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

