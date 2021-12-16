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
            });

            builder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasKey(o => o.OrderId);
                entity.Property(o => o.OrderId).ValueGeneratedOnAdd();

                entity.HasOne<User>(o => o.user)
                    .WithMany(u => u.orderIdUser)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne<User>(o => o.admin)
                    .WithMany(u => u.orderIdAdmin)
                    .HasForeignKey(o => o.AdminId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne<RealEstate>(o => o.realEstate)
                   .WithOne(r => r.order)
                   .HasForeignKey<Order>(o => o.RealestateId);
            });
        }

        public DbSet<Category> categories { get; set; }

        public DbSet<RealEstate> realEstates { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<Report> reports { get; set; }

        public DbSet<News> news { get; set; }

        public DbSet<Rates> rates { get; set; }

        public DbSet<Transaction> transactions { get; set; }


    }
}
