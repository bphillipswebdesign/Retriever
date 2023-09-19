using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN7.BL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public DateTime date_created { get; set; }
        [DisplayName("Username")]
        public string username { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
        [DisplayName("First Name")]
        public string first_name { get; set; }
        [DisplayName("Last Name")]
        public string last_name { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        public bool is_admin { get; set; }
    }
}