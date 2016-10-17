using Microsoft.EntityFrameworkCore;
using Training4Developers.Data.Models;

namespace Training4Developers.Data
{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}