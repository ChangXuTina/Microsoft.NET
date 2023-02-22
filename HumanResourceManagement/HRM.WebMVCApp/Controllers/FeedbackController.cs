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
    public class FeedbackController : Controller
    {
        private readonly IFeedbackServiceAsync feedbackServiceAsync;
        private readonly IInterviewServiceAsync interviewServiceAsync;

        public FeedbackController(IFeedbackServiceAsync _feedbackServiceAsync, IInterviewServiceAsync _interviewServiceAsync)
        {
            feedbackServiceAsync = _feedbackServiceAsync;
            interviewServiceAsync = _interviewServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var feedbackCollection = await feedbackServiceAsync.GetAllFeedbacksAsync();
            return View(feedbackCollection);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.InterviewList = new SelectList(await interviewServiceAsync.GetAllInterviewsAsync(), "Id", "SubmissionId");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FeedbackRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await feedbackServiceAsync.AddFeedbackAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.InterviewList = new SelectList(await interviewServiceAsync.GetAllInterviewsAsync(), "Id", "SubmissionId");
            var result = await feedbackServiceAsync.GetFeedbackByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FeedbackRequestModel model)
        {
            try
            {
                await feedbackServiceAsync.UpdateFeedbackAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await feedbackServiceAsync.GetFeedbackByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FeedbackResponseModel model)
        {
            await feedbackServiceAsync.DeleteFeedbackAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

