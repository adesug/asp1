using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using belajarASPDB.Models;

namespace belajarASPDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<belajarASPDB.Models.NamaSiswaModel> NamaSiswaModel { get; set; } = default!;
    }
}
