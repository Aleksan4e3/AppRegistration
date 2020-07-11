using System;
using System.Threading.Tasks;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ViewModels;

namespace Presentation.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await companyService.GetAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateCompanyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await companyService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await companyService.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await companyService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await companyService.Remove(id);

            var companies = await companyService.GetAsync();

            return PartialView("_Companies", companies);
        }
    }
}
