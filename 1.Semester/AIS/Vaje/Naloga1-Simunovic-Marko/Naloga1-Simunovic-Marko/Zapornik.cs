using System;

namespace Naloga1_Simunovic_Marko
{
    class Zapornik : Oseba
    {
        //Celica, Datum sprejema, datum konca kazni
        DateTime datumSprejema, datumOdhoda;

        public Zapornik(DateTime datumSprejema, DateTime datumOdhoda, string ime, string priimek, string emso, string naslov) : base(ime, priimek, emso, naslov)
        {
            this.DatumSprejema = datumSprejema;
            this.DatumOdhoda = datumOdhoda;
        }

        public DateTime DatumSprejema { get => datumSprejema; set => datumSprejema = value; }
        public DateTime DatumOdhoda { get => datumOdhoda; set => datumOdhoda = value; }
    }
}
