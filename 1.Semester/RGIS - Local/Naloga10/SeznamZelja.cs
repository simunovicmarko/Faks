using System;

namespace Naloga1-Class-Diagram {
	public class SeznamZelja {
		private ObservableCollection<Predmet> predmetiNaSeznamuZelja;
		public ObservableCollection<Predmet> PredmetiNaSeznamuZelja {
			get {
				return predmetiNaSeznamuZelja;
			}
			set {
				predmetiNaSeznamuZelja = value;
			}
		}

		public void DodajNaSeznaméelja(ref Predmet predmet) {
			throw new System.NotImplementedException("Not implemented");
		}

		private System.Collections.Generic.List<Predmet> predmets;

	}

}
