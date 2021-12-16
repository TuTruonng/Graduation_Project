using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Models
{
    public class User : IdentityUser
    {
        public User() : base()
        {
        }

        public User(string userName) : base(userName)
        {
        }

        [PersonalData]
        public string FullName { get; set; }

        [PersonalData]
        public bool Status { get; set; }

        [PersonalData]
        public bool ChangePassword { get; set; }

        [PersonalData]
        public decimal Salary { get; set; }

        [PersonalData]
        public decimal SalaryBasic { get; set; }

        [PersonalData]
        public DateTime DateOfBirth { get; set; }

        [PersonalData]
        public DateTime JoinedDate { get; set; }

        [PersonalData]
        public DateTime CreateDate { get; set; }

        [PersonalData]
        public int Point { get; set; }

        public virtual ICollection<News> news { get; set; }
        public virtual List<RealEstate> RealEstateIdUser { get; set; }
        public virtual List<RealEstate> RealEstateIdAdmin { get; set; }
        public virtual List<Order> orderIdUser { get; set; }
        public virtual List<Order> orderIdAdmin { get; set; }
    }
}
