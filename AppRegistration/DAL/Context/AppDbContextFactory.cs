using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BHOPAQ4\\SQLEXPRESS;Initial Catalog=AppRegistration;Integrated Security=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
