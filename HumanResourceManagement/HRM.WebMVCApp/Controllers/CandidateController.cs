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
    public class CandidateController : Controller
    {
        private readonly ICandidateServiceAsync candidateServiceAsync;

        public CandidateController(ICandidateServiceAsync _candidateServiceAsync)
        {
            candidateServiceAsync = _candidateServiceAsync;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var candidateCollection = await candidateServiceAsync.GetAllCandidatesAsync();
            return View(candidateCollection);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await candidateServiceAsync.AddCandidateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await candidateServiceAsync.GetCandidateByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CandidateRequestModel model)
        {
            try
            {
                await candidateServiceAsync.UpdateCandidateAsync(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await candidateServiceAsync.GetCandidateByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CandidateResponseModel model)
        {
            await candidateServiceAsync.DeleteCandidateAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}

