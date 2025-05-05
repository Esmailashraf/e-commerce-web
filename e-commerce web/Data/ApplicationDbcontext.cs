using e_commerce_web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_web.Data
{
    public class ApplicationDbcontext: DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);






        }
         public DbSet<Product> Products { get; set; }
         public DbSet<Category> Categories { get; set; }
    }
   
}
