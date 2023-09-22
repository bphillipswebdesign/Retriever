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
        public DateTime Date_Created { get; set; }
        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("First Name")]
        public string First_Name { get; set; }
        [DisplayName("Last Name")]
        public string Last_Name { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        public bool Is_Admin { get; set; }
    }
}