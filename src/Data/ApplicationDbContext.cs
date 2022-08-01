namespace Stuntman.Web.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<StuntmanModel>? Stuntman { get; set; }
    public DbSet<DepartmentModel>? Departments { get; set; }
    public DbSet<ContractModel>? Contracts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
