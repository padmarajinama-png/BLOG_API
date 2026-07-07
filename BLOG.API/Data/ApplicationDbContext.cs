using BLOG.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BLOG.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BlogImage> BlogImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogPost>()
                .HasMany(bp => bp.Categories)
                .WithMany(c => c.BlogPosts)
                .UsingEntity(j => j.ToTable("BlogPostCategory"));
        }
    }
}