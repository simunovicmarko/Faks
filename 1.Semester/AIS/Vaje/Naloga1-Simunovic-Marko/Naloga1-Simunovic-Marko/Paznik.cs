using System;

namespace Naloga1_Simunovic_Marko
{
    class Paznik : Oseba
    {
        //Čas prihoda, odhoda
        DateTime casPrihodaVSluzbo, casOdhodaIzSluzbe;

        public Paznik(DateTime casPrihodaVSluzbo, DateTime casOdhodaIzSluzbe, string ime, string priimek, string emso, string naslov) : base(ime, priimek, emso, naslov)
        {
            this.CasPrihodaVSluzbo = casPrihodaVSluzbo;
            this.CasOdhodaIzSluzbe = casOdhodaIzSluzbe;
        }

        public DateTime CasPrihodaVSluzbo { get => casPrihodaVSluzbo; set => casPrihodaVSluzbo = value; }
        public DateTime CasOdhodaIzSluzbe { get => casOdhodaIzSluzbe; set => casOdhodaIzSluzbe = value; }


        //public override void VpisVDatoteko<T>(List<T> osebe)
        //{
        //    if (!File.Exists("osebe.csv"))
        //    {
        //        var x = File.Create("osebe.csv");
        //        x.Close();
        //    }

        //    StreamWriter sw = new StreamWriter("osebe.csv");
        //    foreach (var item in osebe)
        //    {
        //        sw.WriteLine(item.Ime + ", " + item.Priimek + ", " + item.Emso + ", " + item.Naslov);
        //    }

        //}

    }
}
