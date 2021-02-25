using System;

namespace Naloga1_Simunovic_Marko
{
    class Obiskovalec : Oseba
    {
        //Zapornik, Čas prihoda, Čas 
        DateTime casPrihoda, casOdhoda;
        Zapornik zapornik;

        public Obiskovalec(DateTime casPrihoda, DateTime casOdhoda, Zapornik zapornik, string ime, string priimek, string emso, string naslov) : base(ime, priimek, emso, naslov)
        {
            this.CasPrihoda = casPrihoda;
            this.CasOdhoda = casOdhoda;
            this.Zapornik = zapornik;
        }

        public DateTime CasPrihoda { get => casPrihoda; set => casPrihoda = value; }
        public DateTime CasOdhoda { get => casOdhoda; set => casOdhoda = value; }
        internal Zapornik Zapornik { get => zapornik; set => zapornik = value; }
    }
}
