﻿using System;
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
    public class FeedbackController : Controller
    {
        private readonly IFeedbackServiceAsync feedbackServiceAsync;

        public FeedbackController(IFeedbackServiceAsync _feedbackServiceAsync)
        {
            feedbackServiceAsync = _feedbackServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var feedbackCollection = await feedbackServiceAsync.GetAllFeedbacksAsync();
            return View(feedbackCollection);
        }
        public IActionResult Create()
        {
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

