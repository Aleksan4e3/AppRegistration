using System.Threading.Tasks;
using EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class, IBaseEntity;
        Task<int> SaveChangeAsync();
    }
}
