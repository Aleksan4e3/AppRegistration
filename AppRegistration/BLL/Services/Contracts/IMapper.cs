using System.Collections.Generic;
using EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels.ViewModels;

namespace BLL.Services.Contracts
{
    public interface IMapper
    {
        CompanyViewModel Map(Company company);
        Company Map(CreateCompanyViewModel model);
        Company Map(CompanyViewModel model);
        EmployeeViewModel Map(Employee employee);
        Employee Map(CreateEmployeeViewModel model);
        Employee Map(EditEmployeeViewModel model);
        List<SelectListItem> Map(List<CompanyViewModel> model);
        EditEmployeeViewModel Map(EmployeeViewModel model);
    }
}
