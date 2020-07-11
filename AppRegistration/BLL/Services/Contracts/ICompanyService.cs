using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.ViewModels;

namespace BLL.Services.Contracts
{
    public interface ICompanyService
    {
        Task<List<CompanyViewModel>> GetAsync();
        Task<CompanyViewModel> GetAsync(Guid id);
        Task<CreateCompanyViewModel> CreateAsync(CreateCompanyViewModel model);
        Task<CompanyViewModel> UpdateAsync(CompanyViewModel model);
    }
}
