using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int quantityRealEstateSelled { get; set; }
        public int quantityRealEstateWaitingAccept { get; set; }
        public int quantityRealEstate { get; set; }
        public string SalaryBasic { get; set; }
        public string Salary { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
