using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Contracts;
using DAL.Context;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using ViewModels.ViewModels;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDataContext dataContext;
        private readonly IMapper mapper;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IDataContext dataContext,
            IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<List<EmployeeViewModel>> GetAsync()
        {
            var employees = await employeeRepository.GetQuery().ToListAsync();
            var model = employees.Select(mapper.Map).ToList();

            return model;
        }

        public async Task<EmployeeViewModel> GetAsync(Guid id)
        {
            var employee = await employeeRepository.GetAsync(id);
            var model = mapper.Map(employee);

            return model;
        }

        public async Task<CreateEmployeeViewModel> CreateAsync(CreateEmployeeViewModel model)
        {
            var employee = mapper.Map(model);

            await employeeRepository.AddAsync(employee);
            await dataContext.SaveChangeAsync();

            return model;
        }

        public async Task<EditEmployeeViewModel> UpdateAsync(EditEmployeeViewModel model)
        {
            var employee = mapper.Map(model);

            employeeRepository.Update(employee);
            await dataContext.SaveChangeAsync();

            return model;
        }

        public async Task RemoveAsync(Guid id)
        {
            await employeeRepository.RemoveAsync(id);
            await dataContext.SaveChangeAsync();
        }
    }
}
