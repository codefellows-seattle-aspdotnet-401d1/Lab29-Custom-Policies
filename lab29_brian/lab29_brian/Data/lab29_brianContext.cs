using Microsoft.EntityFrameworkCore;

namespace lab29_brian.Models
{
    public class lab29_brianContext : DbContext
    {
        public lab29_brianContext (DbContextOptions<lab29_brianContext> options)
            : base(options)
        {
        }

        public DbSet<lab29_brian.Models.UserPost> UserPost { get; set; }
    }
}
