using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.ViewModels;

namespace BLL.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAsync();
        Task<EmployeeViewModel> GetAsync(Guid id);
        Task<CreateEmployeeViewModel> CreateAsync(CreateEmployeeViewModel model);
        Task<EditEmployeeViewModel> UpdateAsync(EditEmployeeViewModel model);
    }
}
