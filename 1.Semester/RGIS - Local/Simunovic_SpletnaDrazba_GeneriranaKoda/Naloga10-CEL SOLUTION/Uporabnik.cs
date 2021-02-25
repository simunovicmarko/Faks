using System;

namespace Naloga1-Class-Diagram {
	public class Uporabnik {
		private string ime;
		private string priimek;
		public string Priimek {
			get {
				return priimek;
			}
			set {
				priimek = value;
			}
		}
		private int id;
		public int Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		private Statistika statistika;


	}

}
