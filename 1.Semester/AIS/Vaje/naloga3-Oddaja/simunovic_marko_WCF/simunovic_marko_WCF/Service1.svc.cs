using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace simunovic_marko_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IDeloSSeznami
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;

        List<Atlet> atleti = new List<Atlet>();
        List<Tekmovanje> tekmovanja = new List<Tekmovanje>();
        List<AtletTekmovanje> atletTekmovanjeList = new List<AtletTekmovanje>();
        List<Uporabnik> uporabniki = new List<Uporabnik>();


        //public void UstvariAtleta(string ime, string priimek, DateTime datumRojstva)
        //{
        //    this.atleti.Add(new Atlet(ime, priimek, datumRojstva));
        //}

        public Atlet UstvariAtleta(string ime, string priimek, DateTime datumRojstva)
        {
            Atlet atlet = new Atlet(ime, priimek, datumRojstva);
            this.atleti.Add(atlet);
            return atlet;
        }

        public Tekmovanje UstvariTekmovanje(string naziv, string kraj, DateTime datumTekmovanja)
        {
            Tekmovanje tekmovanje = new Tekmovanje(naziv, kraj, datumTekmovanja);
            this.tekmovanja.Add(tekmovanje);
            return tekmovanje;
        }



        public AtletTekmovanje UstvariTekmovanjeAtlet(Atlet atlet, Tekmovanje tekmovanje, string rezultat)
        {
            AtletTekmovanje atletTekmovanje = new AtletTekmovanje(atlet, tekmovanje, rezultat);
            this.atletTekmovanjeList.Add(atletTekmovanje);
            return atletTekmovanje;
        }

        public Uporabnik UstvariUporabnika(string uporabniskoIme, string geslo, bool admin)
        {
            Uporabnik uporabnik = new Uporabnik(uporabniskoIme, geslo, admin);
            this.uporabniki.Add(uporabnik);
            return uporabnik;
        }



        public Uporabnik VpisUporabnika(string username, string password)
        {
            Uporabnik uporabnik = null;
            uporabnik = uporabniki.Find(x => x.UporabniskoIme.ToLower() == username.ToLower() && x.Geslo == password);
            return uporabnik;
        }

        public List<Atlet> VsiAtletiNaTekmovanju(string naziv)
        {
            //Najde vsa tekmovanja pod nazivom
            List<AtletTekmovanje> atletTekmovanjes = atletTekmovanjeList.FindAll(x => x.Tekmovanje.Naziv.ToLower() == naziv.ToLower());
            List<Atlet> atlets = new List<Atlet>();
            //Doda vse atlete, ki so nastopal na tekmovanju
            foreach (var item in atletTekmovanjes)
            {
                atlets.Add(item.Atlet);
            }

            return atlets;
        }

        public List<Tekmovanje> VsaTekmovanjaNaKaterihNastopAtlet(string ime, string priimek)
        {
            List<AtletTekmovanje> atletTekmovanjes = atletTekmovanjeList.FindAll(x => x.Atlet.Ime.ToLower() == ime.ToLower() && x.Atlet.Priimek.ToLower() == priimek.ToLower());
            List<Tekmovanje> tekmovanjes = new List<Tekmovanje>();
            foreach (var item in atletTekmovanjes)
            {
                tekmovanjes.Add(item.Tekmovanje);
            }
            return tekmovanjes;
        }

        public Atlet PodrobnostiAtleta(string ime, string priimek)
        {
            Atlet atlet = atleti.Find(x => x.Ime.ToLower() == ime.ToLower() && x.Priimek.ToLower() == priimek.ToLower());
            return atlet;

        }

        public Tekmovanje TekmovanjeZNajvecAtleti()
        {
            int stevec = 0;
            Tekmovanje vodi = null;
            foreach (var tekmovanje in tekmovanja)
            {
                int st = atletTekmovanjeList.Count(x => x.Tekmovanje.Naziv == tekmovanje.Naziv &&
                    x.Tekmovanje.Kraj == tekmovanje.Kraj && x.Tekmovanje.DatumTekmovanja == tekmovanje.DatumTekmovanja);
                if (st > stevec)
                {
                    stevec = st;
                    vodi = tekmovanje;
                }
            }

            return vodi;
        }


        public Atlet NajstarejsiAtlet()
        {
            return atleti.Find(x => x.DatumRojstva == atleti.Min(y=>y.DatumRojstva));
        }

        public double PovprecnaStarostAtleta()
        {
            List<int> starosti = new List<int>();
            //Vem, da ni točno ker lahka da še ni imel rojstega dne letos ampak se mi ne da matrat s timeSpani
            foreach (var item in atleti)
            {
                starosti.Add(DateTime.Today.Year - item.DatumRojstva.Year);
            }
            return starosti.Average();
        }

        public List<Atlet> VsiAtleti()
        {
            return atleti;
        }

        public List<Tekmovanje> VsaTekmovanja()
        {
            return tekmovanja;
        }

        
    }


    //[ServiceBehavior (InstanceContextMode = InstanceContextMode.Single)]
    //public class Service2 : IDeloSSeznami
    //{
    //    List<Atlet> atleti = new List<Atlet>();
    //    List<Tekmovanje> tekmovanja = new List<Tekmovanje>();
    //    List<AtletTekmovanje> atletTekmovanjeList = new List<AtletTekmovanje>();
    //    List<Uporabnik> uporabniki = new List<Uporabnik>();


    //    public void UstvariAtleta(string ime, string priimek, DateTime datumRojstva)
    //    {
    //        this.atleti.Add(new Atlet(ime, priimek, datumRojstva));
    //    }

    //    public void UstvariTekmovanje(string naziv, string kraj, DateTime datumTekmovanja)
    //    {
    //        this.tekmovanja.Add(new Tekmovanje(naziv, kraj, datumTekmovanja));
    //    }

    //    public void UstvariTekmovanjeAtlet(Atlet atlet, Tekmovanje tekmovanje, string rezultat)
    //    {
    //        this.atletTekmovanjeList.Add(new AtletTekmovanje(atlet, tekmovanje, rezultat));
    //    }

    //    public void UstvariUporabnika(string uporabniskoIme, string geslo, bool admin)
    //    {
    //        this.uporabniki.Add(new Uporabnik(uporabniskoIme, geslo, admin));
    //    }
    //}
}
