using KhoaLuanTotNghiep_BackEnd.Data.SeedData;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KhoaLuanTotNghiep.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedRealEstateData();
            base.OnModelCreating(builder);

            builder.Entity<RealEstate>(entity =>
            {
                entity.ToTable("realEstates");

                entity.HasKey(r => r.RealEstateID);
                entity.Property(r => r.RealEstateID).ValueGeneratedOnAdd();

                entity.HasOne<User>(r => r.user)
                    .WithMany(u => u.RealEstateIdUser)
                    .HasForeignKey(r => r.UserID)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne<User>(r => r.admin)
                    .WithMany(u => u.RealEstateIdAdmin)
                    .HasForeignKey(r => r.AdminID)
                    .OnDelete(DeleteBehavior.NoAction);

                //entity.HasData(DefaultAssignments.SeedAssignments());
            });
        }

        public DbSet<Category> categories { get; set; }

        public DbSet<RealEstate> realEstates { get; set; }

        public DbSet<Report> reports { get; set; }

        public DbSet<News> news { get; set; }

        public DbSet<Rates> rates { get; set; }

        public DbSet<Transaction> transactions { get; set; }


    }
}
