using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Naloga9_Simunovic
{
    static class VsiPredmeti
    {
        public static List<Predmet> predmeti = new List<Predmet>();

        static VsiPredmeti()
        {
            predmeti.Add(new Predmet(predmeti.Count + 1, "Krompir", 10, new DateTime(2021, 1, 1)));
            predmeti.Add(new Predmet(predmeti.Count + 1, "Steak", 10, new DateTime(2021, 2, 1)));
            predmeti.Add(new Predmet(predmeti.Count + 1, "Nož", 10, new DateTime(2021, 3, 1)));
            predmeti.Add(new Predmet(predmeti.Count + 1, "RAčunalnik", 10, new DateTime(2021, 4, 1)));
        }

        public static Predmet PridobiPredmet(Predmet predmet)
        {
           return predmeti.Find(x => x == predmet);
        }
    }
}
