using System;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await employeeService.GetAsync());
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await CreateEmployeeAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await employeeService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await employeeService.RemoveAsync(id);

            var employees = await employeeService.GetAsync();

            return PartialView("_Employees", employees);
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

        [NonAction]
        public async Task<EditEmployeeViewModel> CreateEmployeeAsync(Guid id)
        {
            var companies = await companyService.GetAsync();
            var employee = await employeeService.GetAsync(id);

            return new EditEmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                EmploymentDate = employee.EmploymentDate,
                Position = employee.Position,
                CompanyId = employee.CompanyId,
                Companies = companies.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };
        }
    }
}
