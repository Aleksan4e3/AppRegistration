using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels.ViewModels;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ICompanyService companyService;

        public EmployeeController(
            IEmployeeService employeeService,
            ICompanyService companyService)
        {
            this.employeeService = employeeService;
            this.companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await employeeService.GetAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View(await CreateEmployeeAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await employeeService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public async Task<CreateEmployeeViewModel> CreateEmployeeAsync()
        {
            var companies = await companyService.GetAsync();

            return new CreateEmployeeViewModel
            {
                EmploymentDate = DateTime.Now.Date,
                Companies = companies.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };
        }
    }
}
