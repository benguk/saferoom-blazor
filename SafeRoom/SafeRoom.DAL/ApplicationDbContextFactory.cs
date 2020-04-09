using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SafeRoom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRoom.DAL
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connStr = ConfigurationHelper.GetCurrentSettings("ConnectionStrings:DefaultConnection");
            optionsBuilder.UseSqlServer(connStr);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
