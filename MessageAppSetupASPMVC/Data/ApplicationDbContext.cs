using Microsoft.EntityFrameworkCore;

namespace MessageAppSetupASPMVC.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

    }
}
