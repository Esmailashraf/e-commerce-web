using e_commerce_web.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_web.Data
{
    public class ApplicationDbcontext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var AdminRoleId = "b0a3e2ff-b1f7-4c6b-bfb1-01ab5bbc6815";
            var VendorRoleId = "f6fad1d1-43f5-4968-9329-7ef92a658c6f";
            var UserRoleId = "5579cda1-5bbd-4355-bee1-4d623bb976de";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = AdminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = VendorRoleId,
                    Name = "Vendor",
                    NormalizedName = "Vendor".ToUpper()
                },
                new IdentityRole
                {
                    Id = UserRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            };


            modelBuilder.Entity<IdentityRole>()
                .HasData(roles);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);






        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }

}
