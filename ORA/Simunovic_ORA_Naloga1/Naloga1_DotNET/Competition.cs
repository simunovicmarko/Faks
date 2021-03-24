using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga1_DotNET
{
    public class Competition
    {

        public Competition()
        {
            //results = new HashSet<Results>();
        }
        public Competition(string name, string year)
        {
            Name = name;
            Year = year;
            //results = new HashSet<Results>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }

        //public ICollection<Results> results;
    }
}
