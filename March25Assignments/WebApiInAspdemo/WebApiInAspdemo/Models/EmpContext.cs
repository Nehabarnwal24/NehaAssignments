using Microsoft.EntityFrameworkCore;
using WebApiInAspdemo.Models;

namespace WebApiInAsp.netcoreMvcDemo.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        {

        }

        public DbSet<Employee> employees { set; get; }

    }
}

