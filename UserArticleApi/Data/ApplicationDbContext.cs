using Microsoft.EntityFrameworkCore;
using UserArticleApi.Models;

namespace UserArticleApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<User>users { get; set; }
        public DbSet<Article>articles { get; set; }

    }
}
