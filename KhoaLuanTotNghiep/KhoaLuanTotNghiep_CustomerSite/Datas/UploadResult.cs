using System.ComponentModel.DataAnnotations;

namespace KhoaLuanTotNghiep_CustomerSite.Datas
{
    public class UploadResult
    {
        [Key]
        public int Id { get; set; }
        public string UploadResultAsJson { get; set; }
    }
}
