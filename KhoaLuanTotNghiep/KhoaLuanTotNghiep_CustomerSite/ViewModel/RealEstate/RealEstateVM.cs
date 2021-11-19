using System.ComponentModel.DataAnnotations;

namespace KhoaLuanTotNghiep_CustomerSite.ViewModel.Brand
{
    public class RealEstateVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
