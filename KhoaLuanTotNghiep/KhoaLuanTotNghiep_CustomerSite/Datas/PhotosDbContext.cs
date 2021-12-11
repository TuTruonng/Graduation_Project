using Microsoft.EntityFrameworkCore;

namespace KhoaLuanTotNghiep_CustomerSite.Datas
{
    public class PhotosDbContext : DbContext
    {
        public PhotosDbContext(DbContextOptions<PhotosDbContext> options) : base(options)
        {

        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<UploadResult> UploadResults { get; set; }
    }
}
