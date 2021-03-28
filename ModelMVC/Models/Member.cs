using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelMVC.Models
{
    public class Member
    {
        [Display(Name = "Employee ID")]
        public int MemberId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String PhoneNumber { get; set; }
        public String BirthPlace { get; set; }
        public DateTime StartDate { get; set; }
        //public int RoleId { get; set; }
    }
}
