
using System.ComponentModel.DataAnnotations;

namespace KhoaLuanTotNghiep_BackEnd.Models
{
    public class News
    {
        [Key]
        public string NewsID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Img { get; set; }

        public string NewsName { get; set; }

        public string Description { get; set; }
        public User user { get; set; }
    }
}
