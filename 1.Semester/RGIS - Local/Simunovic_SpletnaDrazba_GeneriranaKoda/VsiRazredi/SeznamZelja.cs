using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Naloga10 {
	public class SeznamZelja {
        ObservableCollection<Predmet> predmetiNaSeznamuZelja = new ObservableCollection<Predmet>();

        internal ObservableCollection<Predmet> PredmetiNaSeznamuZelja { get => predmetiNaSeznamuZelja; set => predmetiNaSeznamuZelja = value; }

        public void DodajNaSeznaméelja(Predmet predmet)
        {
            predmetiNaSeznamuZelja.Add(VsiPredmeti.PridobiPredmet(predmet));
        }

    }

}
