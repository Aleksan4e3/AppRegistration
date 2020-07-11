using DAL.Context;
using DAL.Repositories.Contracts;
using EntityModels;

namespace DAL.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(IDataContext dataContext) : base(dataContext) { }
    }
}
