using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic.Models
{
    public class Uporabnik
    {


        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Vnoso polje je zahtevano")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Dovoljene so samo črke")]
        public string Ime { get; set; }




        [Required(ErrorMessage = "Vnoso polje je zahtevano")]
        [RegularExpression(@"^([A-Za-z])+$", ErrorMessage = "Dovoljene so samo črke")]
        public string Priimek { get; set; }




        [Required(ErrorMessage = "Vnoso polje je zahtevano")]
        [RegularExpression(@"^(\d{13})?$", ErrorMessage = "EMŠO je sestavljen iz trinajstih števil")]
        public string EMŠO { get; set; }



        [Required(ErrorMessage = "Vnoso polje je zahtevano")]
        [DateRange("01/01/1900", ErrorMessage = "Neveljaven datum")]
        public DateTime DatumRojstva { get; set; }


        [Required(ErrorMessage = "Vnoso polje je zahtevano")]
        public string KrajRojstva { get; set; }



        


        [Required(ErrorMessage = "Vnoso polje je zahtevano")]
        [EmailAddress(ErrorMessage = "E-Pošta ni v pravilni obliki")]
        public string Eposta { get; set; }




        [Required(ErrorMessage = "Vnoso polje je zahtevano")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]+$", ErrorMessage = "Geslo mora vsebovati vsaj eno črko, eno število in en poseben znak")]
        [NotMapped]
        public string Geslo { get; set; }




        [Required(ErrorMessage = "Vnoso polje je zahtevano")]
        [Compare("Geslo", ErrorMessage = "Gesli se ne ujemata")]
        [NotMapped]
        public string Geslo1 { get; set; }



        public static IEnumerable<SelectListItem> GetKraji()
        {
            List<string> kraji = new List<string>() { "Celje", "Maribor", "Ljubljana", "Žalec", "Šentjur" };

            foreach (var kraj in kraji)
            {
                yield return new SelectListItem(kraj, kraj);
            }
        }



    }

}
