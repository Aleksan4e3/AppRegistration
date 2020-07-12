using System.Threading.Tasks;
using EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class DataContext : IDataContext
    {
        private readonly AppDbContext appDbContext;

        public DataContext(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public DbSet<T> Set<T>() where T : class, IBaseEntity => appDbContext.Set<T>();

        public async Task<int> SaveChangeAsync() => await appDbContext.SaveChangesAsync();
    }
}
