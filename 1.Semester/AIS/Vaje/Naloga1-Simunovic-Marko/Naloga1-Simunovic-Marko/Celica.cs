using System.Collections.Generic;

namespace Naloga1_Simunovic_Marko
{
    class Celica
    {
        //Seznam zapornikov v celici
        List<Zapornik> zaporniki = new List<Zapornik>();

        public Celica()
        {

        }

        public Celica(List<Zapornik> zaporniki)
        {
            this.Zaporniki = zaporniki;
        }

        public Celica(Zapornik zapornik)
        {
            this.zaporniki.Add(zapornik);
        }

        public Celica(Celica celica)
        {
            this.zaporniki = celica.zaporniki;
        }

        public List<Zapornik> Zaporniki { get => zaporniki; set => zaporniki = value; }


        public void DodajZapornika(Zapornik zapornik)
        {
            this.zaporniki.Add(zapornik);
        }

        public void OdstraniZapornikaPoImenu(string ime)
        {
            this.zaporniki.RemoveAll(x => x.Ime == ime);
        }
    }
}
