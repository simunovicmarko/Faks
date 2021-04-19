using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ORA_REST_API
{

    //[DataContract]
    public class Results
    {

        public Results()
        {
        }

        public Results(string[] arr)
        {
            values = arr;
            Name = values[0];
            GenderRank = values[1];
            DivRank = values[2];
            OverallRank = values[3];
            Bib = values[4];
            Division = values[5];
            Age = values[6];
            State = values[7];
            Country = values[8];
            Profession = values[9];
            Points = values[10];
            Swim = values[11];
            SwimDistance = values[12];
            T1 = values[13];
            Bike = values[14];
            BikeDistance = values[15];
            T2 = values[16];
            Run = values[17];
            RunDistance = values[18];
            Overall = values[19];
        }



        string[] values;


        [Key]
        //[DataMember]
        public int ID { get; set; }


        public Competition competition { get; set; }

        //public virtual ICollection<Competition> Competitions { get; set; }
        // [DataMember]
        public string Name { get; set; }
        //[DataMember]

        public string GenderRank { get; set; }
        //[DataMember]

        public string DivRank { get; set; }
        // [DataMember]
        public string OverallRank { get; set; }
        //[DataMember]
        public string Bib { get; set; }
        //[DataMember]
        public string Division { get; set; }
        //[DataMember]
        public string Age { get; set; }
        // [DataMember]
        public string State { get; set; }
        //[DataMember]
        public string Country { get; set; }
        //[DataMember]
        public string Profession { get; set; }
        //[DataMember]
        public string Points { get; set; }
        // [DataMember]
        public string Swim { get; set; }
        //[DataMember]
        public string SwimDistance { get; set; }
        // [DataMember]
        public string T1 { get; set; }
        // [DataMember]
        public string Bike { get; set; }
        // [DataMember]
        public string BikeDistance { get; set; }
        // [DataMember]
        public string T2 { get; set; }
        // [DataMember]
        public string Run { get; set; }
        //[DataMember]
        public string RunDistance { get; set; }
        //[DataMember]
        public string Overall { get; set; }


    }
}
