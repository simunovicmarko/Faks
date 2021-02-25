using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Naloga1_Simunovic_Marko
{
    class Zapor
    {
        List<Celica> celice = new List<Celica>();
        List<Paznik> pazniki = new List<Paznik>();
        List<Zapornik> zaporniki = new List<Zapornik>();
        List<Obiskovalec> obiskovalci = new List<Obiskovalec>();

        public Zapor() { }

        public Zapor(List<Celica> celice, List<Paznik> pazniki, List<Zapornik> zaporniki, List<Obiskovalec> obiskovalci)
        {
            this.Celice = celice;
            this.Pazniki = pazniki;
            this.Zaporniki = zaporniki;
            this.obiskovalci = obiskovalci;
        }

        internal List<Celica> Celice { get => celice; set => celice = value; }
        internal List<Paznik> Pazniki { get => pazniki; set => pazniki = value; }
        internal List<Zapornik> Zaporniki { get => zaporniki; set => zaporniki = value; }
        internal List<Obiskovalec> Obiskovalci { get => obiskovalci; set => obiskovalci = value; }

        public string NajdljeVZaporu()
        {
            Zapornik z = zaporniki.Find(x => (x.DatumOdhoda - x.DatumSprejema) == zaporniki.Max(y => y.DatumOdhoda - y.DatumSprejema));
            return z.Ime + " " + z.Priimek;
        }

        public string CelicaZNajvecZaporniki()
        {
            //Vrne vse zapornike ki so v celici z največ zaporniki
            Celica c = celice.Find(x => x.Zaporniki.Count == celice.Max(y => y.Zaporniki.Count));
            string s = "";
            foreach (var item in c.Zaporniki)
            {
                s = s + "\n" + item.Ime + " " + item.Priimek;
            }

            return s;
        }

        public void KolikoObiskovImaZapornik(Zapornik zapornik)
        {
            int stevec = 0;
            foreach (var item in obiskovalci)
            {
                if (item.Zapornik == zapornik)
                {
                    stevec++;
                }
            }
            Console.WriteLine(zapornik.Ime + " " + zapornik.Priimek + ": " + stevec);
        }

        


        public  void VpisVDatoteko<T>(List<T> osebe) where T : Oseba
        {

            if (!File.Exists("osebe.csv"))
            {
                var x = File.Create("osebe.csv");
                x.Close();
            }

            using (StreamWriter sw = new StreamWriter("osebe.csv")) {
                foreach (var item in osebe)
                {
                    sw.WriteLine(item.Ime + "," + item.Priimek + "," + item.Emso + "," + item.Naslov);
                }
            }


            
        }
    }
}
