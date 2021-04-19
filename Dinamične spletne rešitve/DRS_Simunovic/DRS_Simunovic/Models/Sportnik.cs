using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic.Models
{
    public class Sportnik
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [DisplayName("Ime")]
        public string Name { get; set; }

        [DisplayName("Priimek")]
        public string LastName { get; set; }

        [DisplayName("Datum rojstva")]
        public DateTime dateOfBirth { get; set; }


        [NotMapped]
        public Int32 IntDaPokažemDaDela { get; set; }
        [NotMapped]
        public double DoubleDaPokažemDaDela { get; set; }
    }
}
