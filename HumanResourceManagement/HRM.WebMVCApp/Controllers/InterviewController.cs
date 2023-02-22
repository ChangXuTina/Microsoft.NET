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
    public class InterviewController : Controller
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;
        private readonly IInterviewStatusServiceAsync interviewStatusServiceAsync;
        private readonly IInterviewTypeServiceAsync interviewTypeServiceAsync;
        private readonly IEmployeeServiceAsync employeeServiceAsync;
        private readonly ISubmissionServiceAsync submissionServiceAsync;

        public InterviewController(
            IInterviewServiceAsync _interviewServiceAsync,
            IInterviewStatusServiceAsync _interviewStatusServiceAsync,
            IInterviewTypeServiceAsync _interviewTypeServiceAsync,
            IEmployeeServiceAsync _employeeServiceAsync,
            ISubmissionServiceAsync _submissionServiceAsync)
        {
            interviewServiceAsync = _interviewServiceAsync;
            interviewStatusServiceAsync = _interviewStatusServiceAsync;
            interviewTypeServiceAsync = _interviewTypeServiceAsync;
            employeeServiceAsync = _employeeServiceAsync;
            submissionServiceAsync = _submissionServiceAsync;
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
                ViewBag.SubmissionList = new SelectList(await submissionServiceAsync.GetAllSubmissionsAsync(), "Id", "CandidateId");
                ViewBag.InterviewTypeList = new SelectList(await interviewTypeServiceAsync.GetAllInterviewTypesAsync(), "Id", "Title");
                ViewBag.InterviewStatusList = new SelectList(await interviewStatusServiceAsync.GetAllInterviewStatusAsync(), "Id", "Title");
                ViewBag.IntervierList = new SelectList(await employeeServiceAsync.GetAllEmployeesAsync(), "Id", "Firstname");
                await interviewServiceAsync.AddInterviewAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.SubmissionList = new SelectList(await submissionServiceAsync.GetAllSubmissionsAsync(), "Id", "CandidateId");
            ViewBag.InterviewTypeList = new SelectList(await interviewTypeServiceAsync.GetAllInterviewTypesAsync(), "Id", "Title");
            ViewBag.InterviewStatusList = new SelectList(await interviewStatusServiceAsync.GetAllInterviewStatusAsync(), "Id", "Title");
            ViewBag.IntervierList = new SelectList(await employeeServiceAsync.GetAllEmployeesAsync(), "Id", "Firstname");
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

