using System;

namespace Naloga1-Class-Diagram {
	public class Predmet {
		private int id;
		public int Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}
		private string naziv;
		public string Naziv {
			get {
				return naziv;
			}
			set {
				naziv = value;
			}
		}
		private decimal izklicnaCena;
		public decimal IzklicnaCena {
			get {
				return izklicnaCena;
			}
			set {
				izklicnaCena = value;
			}
		}
		private DateTime datumPrenehanjaSprejemanjaPonudb;
		public DateTime DatumPrenehanjaSprejemanjaPonudb {
			get {
				return datumPrenehanjaSprejemanjaPonudb;
			}
			set {
				datumPrenehanjaSprejemanjaPonudb = value;
			}
		}

		private Dražba dražba;

		private VsiPredmeti seznam;

	}

}
