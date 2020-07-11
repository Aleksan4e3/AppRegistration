using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Contracts;
using DAL.Context;
using DAL.Repositories.Contracts;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using ViewModels.ViewModels;

namespace BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IDataContext dataContext;
        private readonly IMapper mapper;

        public CompanyService(
            ICompanyRepository companyRepository,
            IDataContext dataContext,
            IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<List<CompanyViewModel>> GetAsync()
        {
            var companies = await companyRepository.GetQuery().ToListAsync();
            var model = companies.Select(mapper.Map).ToList();

            return model;
        }

        public async Task<CompanyViewModel> GetAsync(Guid id)
        {
            var company = await companyRepository.GetAsync(id);
            var model = mapper.Map(company);

            return model;
        }

        public async Task<CreateCompanyViewModel> CreateAsync(CreateCompanyViewModel model)
        {
            var company = mapper.Map(model);

            await companyRepository.AddAsync(company);
            await dataContext.SaveChangeAsync();

            return model;
        }

        public async Task<CompanyViewModel> UpdateAsync(CompanyViewModel model)
        {
            var company = mapper.Map(model);

            companyRepository.Update(company);
            await dataContext.SaveChangeAsync();

            return model;
        }
    }
}
