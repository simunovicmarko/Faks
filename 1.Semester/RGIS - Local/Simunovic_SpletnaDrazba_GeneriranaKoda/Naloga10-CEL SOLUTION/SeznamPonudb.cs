using System;

namespace Naloga1-Class-Diagram {
	public class SeznamPonudb {
		private List<Ponudba> ponudbe;
		public List<Ponudba> Ponudbe {
			get {
				return ponudbe;
			}
			set {
				ponudbe = value;
			}
		}

		public void DodajPonudbo(ref Uporabnik uporabnik) {
			throw new System.NotImplementedException("Not implemented");
		}

		private System.Collections.Generic.List<Ponudba> elementi;
		private Statistika statistika;

		private Dražba dražba;

	}

}
