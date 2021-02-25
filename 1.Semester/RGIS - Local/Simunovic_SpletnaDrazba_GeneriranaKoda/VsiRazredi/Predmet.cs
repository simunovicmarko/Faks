using System;

namespace Naloga10 {
	public class Predmet {
        private int id;
        string naziv;
        decimal izklicnaCena;
        DateTime datumPrenehanjaSprejemanjaPonudb;

        public Predmet(int id, string naziv, decimal izklicnaCena, DateTime datumPrenehanjaSprejemanjaPonudb)
        {
            this.id = id;
            this.naziv = naziv;
            this.izklicnaCena = izklicnaCena;
            this.datumPrenehanjaSprejemanjaPonudb = datumPrenehanjaSprejemanjaPonudb;
        }

        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public decimal IzklicnaCena { get => izklicnaCena; set => izklicnaCena = value; }
        public DateTime DatumPrenehanjaSprejemanjaPonudb { get => datumPrenehanjaSprejemanjaPonudb; set => datumPrenehanjaSprejemanjaPonudb = value; }


        public override string ToString()
        {
            return $"{id}, {naziv}, {izklicnaCena}, {datumPrenehanjaSprejemanjaPonudb.ToString("dd.mm.yyyy")}";
        }

    }

}
