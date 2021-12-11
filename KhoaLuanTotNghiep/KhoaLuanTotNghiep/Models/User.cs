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
        public int Point { get; set; }

        public ICollection<News> news { get; set; }

    }
}
