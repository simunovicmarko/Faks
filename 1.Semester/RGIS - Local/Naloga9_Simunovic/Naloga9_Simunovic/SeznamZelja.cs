using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Naloga9_Simunovic
{
    class SeznamZelja
    {
        ObservableCollection<Predmet> predmetiNaSeznamuZelja = new ObservableCollection<Predmet>();

        internal ObservableCollection<Predmet> PredmetiNaSeznamuZelja { get => predmetiNaSeznamuZelja; set => predmetiNaSeznamuZelja = value; }

        public void DodajNaSeznamŽelja(Predmet predmet)
        {
            predmetiNaSeznamuZelja.Add(VsiPredmeti.PridobiPredmet(predmet));
        }
    }
}
