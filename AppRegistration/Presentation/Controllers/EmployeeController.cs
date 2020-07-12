using System;
using System.Threading.Tasks;
using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ViewModels;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly ICompanyService companyService;
        private readonly IMapper mapper;

        public EmployeeController(
            IEmployeeService employeeService,
            ICompanyService companyService,
            IMapper mapper)
        {
            this.employeeService = employeeService;
            this.companyService = companyService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await employeeService.GetAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companies = await companyService.GetAsync();
            var model = new CreateEmployeeViewModel
            {
                EmploymentDate = DateTime.Now.Date,
                Companies = mapper.Map(companies)
            };

            return View(model);
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
            var companies = await companyService.GetAsync();
            var employee = await employeeService.GetAsync(id);
            var model = mapper.Map(employee);
            model.Companies = mapper.Map(companies);

            return View(model);
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
    }
}
