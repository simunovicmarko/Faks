using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic.Models
{
    public class Login
    {
        [EmailAddress(ErrorMessage = "E-Pošta ni v pravilni obliki")]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
