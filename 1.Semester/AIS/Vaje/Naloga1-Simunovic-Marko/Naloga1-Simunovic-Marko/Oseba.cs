namespace Naloga1_Simunovic_Marko
{
    class Oseba
    {
        private string ime, priimek, emso, naslov;

        public Oseba(string ime, string priimek, string emso, string naslov)
        {
            this.Ime = ime;
            this.Priimek = priimek;
            this.Emso = emso;
            this.Naslov = naslov;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Priimek { get => priimek; set => priimek = value; }
        public string Emso { get => emso; set => emso = value; }
        public string Naslov { get => naslov; set => naslov = value; }

        

    }
}
