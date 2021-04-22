using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriatlonNamiznaAplikacija
{
    public class User
    {
        public User() { }

        public User(string email, string password)
        {
            Email = email;
            this.password = password;
        }

        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}
