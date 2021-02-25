using System;
using System.Linq;
using System.Net;

namespace Naloga1_Simunovic_Marko
{
    class Program
    {
        static void Main(string[] args)
        {
            Zapor zapor = new Zapor();
            zapor.Pazniki.Add(new Paznik(new DateTime(2020, 10, 9, 7, 0, 0), new DateTime(2020, 10, 9, 15, 0, 0), "Miha", "Novak", "1205505121", "Englesova 4"));
            zapor.Pazniki.Add(new Paznik(new DateTime(2020, 10, 9, 7, 0, 0), new DateTime(2020, 10, 9, 15, 0, 0), "Jože", "Robežnik", "1205509121", "Englesova 15"));


            zapor.Zaporniki.Add(new Zapornik(new DateTime(2018, 10, 9), new DateTime(2020, 10, 9), "Marko", "Šimunović", "1205509141", "Slovenska 15"));
            zapor.Zaporniki.Add(new Zapornik(new DateTime(2018, 10, 9), new DateTime(2021, 10, 9), "Luka", "Most", "1205509141", "Mehiska 13"));
            zapor.Zaporniki.Add(new Zapornik(new DateTime(2018, 10, 9), new DateTime(2022, 10, 9), "Janez", "Novak", "1205509141", "Leva 15"));
            zapor.Zaporniki.Add(new Zapornik(new DateTime(2018, 10, 9), new DateTime(2023, 10, 9), "Novak", "Djoković", "1205509141", "Legenda 19"));
            zapor.Zaporniki.Add(new Zapornik(new DateTime(2018, 10, 9), new DateTime(2024, 10, 9), "Rafa", "Izgubil", "1205509141", "Mal manjsa legenda 17"));


            zapor.Obiskovalci.Add(new Obiskovalec(new DateTime(2020, 10, 9, 9, 15, 0), new DateTime(2020, 10, 9, 10, 0, 0), zapor.Zaporniki.Find(x => x.Ime == "Marko"), "Jože", "Robežnik", "1205509121", "Englesova 15"));
            zapor.Obiskovalci.Add(new Obiskovalec(new DateTime(2020, 10, 9, 9, 15, 0), new DateTime(2020, 10, 9, 10, 0, 0), zapor.Zaporniki.Find(x => x.Ime == "Marko"), "Luka", "Robežnik", "1205509129", "Englesova 15"));
            zapor.Obiskovalci.Add(new Obiskovalec(new DateTime(2020, 10, 9, 9, 15, 0), new DateTime(2020, 10, 9, 10, 0, 0), zapor.Zaporniki.Find(x => x.Ime == "Marko"), "Janez", "Robežnik", "1205509141", "Englesova 15"));


            

            Celica c1 = new Celica(zapor.Zaporniki.ElementAt(0));
            c1.Zaporniki.Add(zapor.Zaporniki.ElementAt(1));
            c1.Zaporniki.Add(zapor.Zaporniki.ElementAt(2));
            c1.Zaporniki.Add(zapor.Zaporniki.ElementAt(3));


            Celica c2 = new Celica(zapor.Zaporniki.ElementAt(0));
            c2.Zaporniki.Add(zapor.Zaporniki.ElementAt(4));
            c2.Zaporniki.Add(zapor.Zaporniki.ElementAt(2));
            c2.Zaporniki.Add(zapor.Zaporniki.ElementAt(3));


            Celica c3 = new Celica(zapor.Zaporniki.ElementAt(0));
            c3.Zaporniki.Add(zapor.Zaporniki.ElementAt(1));
            c3.Zaporniki.Add(zapor.Zaporniki.ElementAt(4));
            c3.Zaporniki.Add(zapor.Zaporniki.ElementAt(3));
            c3.Zaporniki.Add(zapor.Zaporniki.ElementAt(3));


            Celica c4 = new Celica(zapor.Zaporniki.ElementAt(2));
            c4.Zaporniki.Add(zapor.Zaporniki.ElementAt(1));
            c4.Zaporniki.Add(zapor.Zaporniki.ElementAt(4));

            zapor.Celice.Add(c1);
            zapor.Celice.Add(c2);
            zapor.Celice.Add(c3);
            zapor.Celice.Add(c4);


            Console.WriteLine(zapor.CelicaZNajvecZaporniki());
            Console.WriteLine();
            Console.WriteLine(zapor.NajdljeVZaporu());
            Console.WriteLine();
            zapor.KolikoObiskovImaZapornik(zapor.Zaporniki.ElementAt(0));


            //StreamWriter sw = new StreamWriter("Osebe.csv");
            zapor.VpisVDatoteko(zapor.Zaporniki);
            


        }
    }
}
