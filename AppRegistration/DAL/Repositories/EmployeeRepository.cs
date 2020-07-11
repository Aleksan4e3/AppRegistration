using DAL.Context;
using DAL.Repositories.Contracts;
using EntityModels;

namespace DAL.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
