using BLL.Services.Contracts;
using EntityModels;
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
    }
}
