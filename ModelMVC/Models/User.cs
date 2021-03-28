using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelMVC.Models
{
    public class User
    {
        public int UserId { get; set; }

        public String Username { get; set; }
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public int RoleId { get; set; }
    }
}
