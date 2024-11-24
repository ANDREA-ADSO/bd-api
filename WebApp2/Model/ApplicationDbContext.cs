using Microsoft.EntityFrameworkCore;

namespace WebApi.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
    }

}
