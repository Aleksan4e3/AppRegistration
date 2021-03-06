using System.Collections.Generic;
using System.Linq;
using BLL.Services.Contracts;
using EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels.ViewModels;

namespace BLL.Services
{
    public class Mapper : IMapper
    {
        public CompanyViewModel Map(Company company)
        {
            return new CompanyViewModel
            {
                Id = company.Id,
                Name = company.Name,
                Staff = company.Employees.Count,
                LegalForm = company.LegalForm
            };
        }

        public Company Map(CreateCompanyViewModel model)
        {
            return new Company
            {
                Name = model.Name,
                LegalForm = model.LegalForm
            };
        }

        public Company Map(CompanyViewModel model)
        {
            return new Company
            {
                Id = model.Id,
                Name = model.Name,
                LegalForm = model.LegalForm
            };
        }

        public EmployeeViewModel Map(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                Surname = employee.Surname,
                Name = employee.Name,
                Patronymic = employee.Patronymic,
                EmploymentDate = employee.EmploymentDate,
                Position = employee.Position,
                CompanyId = employee.CompanyId,
                Company = employee.Company == null ? new CompanyViewModel() : Map(employee.Company)
            };
        }

        public Employee Map(CreateEmployeeViewModel model)
        {
            return new Employee
            {
                Surname = model.Surname,
                Name = model.Name,
                Patronymic = model.Patronymic,
                EmploymentDate = model.EmploymentDate,
                Position = model.Position,
                CompanyId = model.CompanyId
            };
        }

        public Employee Map(EditEmployeeViewModel model)
        {
            return new Employee
            {
                Id = model.Id,
                Surname = model.Surname,
                Name = model.Name,
                Patronymic = model.Patronymic,
                EmploymentDate = model.EmploymentDate,
                Position = model.Position,
                CompanyId = model.CompanyId
            };
        }

        public List<SelectListItem> Map(List<CompanyViewModel> model)
        {
            return model.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        public EditEmployeeViewModel Map(EmployeeViewModel model)
        {
            return new EditEmployeeViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                EmploymentDate = model.EmploymentDate,
                Position = model.Position,
                CompanyId = model.CompanyId,
            };
        }
    }
}
