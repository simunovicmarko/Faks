using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic.Models
{
    public class Tekmovanje
    {
        [Key]
        [ScaffoldColumn(false)]

        public int ID { get; set; }
        [DisplayName("Ime")]
        public string Name { get; set; }

        [DisplayName("Prizorišče")]
        public string venue { get; set; }

        [DisplayName("Datum dogodka")]
        public DateTime date { get; set; }
}
}
