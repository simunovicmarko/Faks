using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI;

namespace Naloga5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        AtletikaContext db = new AtletikaContext();

        public Atlet UstvariAtleta(string ime, string priimek, DateTime datumRojstva)
        {
            Atlet atlet = new Atlet(ime, priimek, datumRojstva);
            db.atlets.Add(new Atlet(ime, priimek, datumRojstva));
            db.SaveChanges();
            return atlet;
        }

        public Tekmovanje UstvariTekmovanje(string naziv, string kraj, DateTime datumTekmovanja)
        {
            Tekmovanje tekmovanje = new Tekmovanje(naziv, kraj, datumTekmovanja);
            db.tekmovanja.Add(tekmovanje);
            db.SaveChanges();
            return tekmovanje;
        }

        public Uporabnik UstvariUporabnika(string uporabniskoIme, string geslo, bool admin)
        {
            Uporabnik uporabnik = new Uporabnik(uporabniskoIme, geslo, admin);
            db.Uporabniks.Add(uporabnik);
            db.SaveChanges();
            return uporabnik;
        }

        //Mi je jasno, da s tem pridejo SQL injectoni sam se mi ne da matrat s parametri
        public bool Uredi(string tabela, string id, string imeStolpca, string vrednost)
        {
            string querry = "Update " + tabela + " set " + imeStolpca + " = '" + vrednost + "' where ID = " + id;

            try
            {
                db.Database.ExecuteSqlCommand(querry);
                return true;
            }
            catch (Exception) { }

            return false;

        }

        public bool Izbrisi(string tabela, string id)
        {
            string querry = "Delete from " + tabela + " where id = " + id;
            try
            {
                db.Database.ExecuteSqlCommand(querry);
                return true;
            }
            catch (Exception) { }


            return false;
        }


        public void DodajAtletaTekmovanju(string naziv, string ime, string priimek)
        {
            Tekmovanje tekmovanje = db.tekmovanja.Where(x => x.Naziv == naziv).Single();
            tekmovanje.Atlets.Add(db.atlets.Where(x => x.Ime == ime && x.Priimek == priimek).Single());
            db.SaveChanges();

        }


        public void DodajTekmovanjeAtletu(string naziv, string ime, string priimek)
        {
            Atlet atlet = db.atlets.Where((x => x.Ime == ime && x.Priimek == priimek)).Single();
            atlet.Tekmovanjes.Add(db.tekmovanja.Where(x => x.Naziv == naziv).Single());
            db.SaveChanges();
        }


        public void OdstraniTekmovanjeIzAtleta(string naziv, string ime, string priimek)
        {
            Atlet atlet = db.atlets.Where((x => x.Ime == ime && x.Priimek == priimek)).Single();
            atlet.Tekmovanjes.Remove(db.tekmovanja.Where(x => x.Naziv == naziv).Single());
            db.SaveChanges();
        }

        public void OdstraniAtletaIztekmovanja(string naziv, string ime, string priimek)
        {
            Tekmovanje tekmovanje = db.tekmovanja.Where(x => x.Naziv == naziv).Single();
            tekmovanje.Atlets.Remove(db.atlets.Where((x => x.Ime == ime && x.Priimek == priimek)).Single());
            db.SaveChanges();
        }



        public Uporabnik VpisUporabnika(string username, string password)
        {
            Uporabnik uporabnik = null;
            uporabnik = db.Uporabniks.Where(x => x.UporabniskoIme.ToLower() == username.ToLower() && x.Geslo == password).Single();
            return uporabnik;
        }

        public List<Atlet> VsiAtletiNaTekmovanju(string naziv)
        {
            Tekmovanje tekmovanje = db.tekmovanja.Where(x => x.Naziv == naziv).Single();
            List<Atlet> atlets = tekmovanje.Atlets.ToList();
            return atlets;
        }

        public List<Tekmovanje> VsaTekmovanjaNaKaterihNastopaAtlet(string ime, string priimek)
        {
            Atlet atlet = db.atlets.Where(x => x.Ime == ime && x.Priimek == priimek).Single();
            List<Tekmovanje> tekmovanjes = atlet.Tekmovanjes.ToList();

            return tekmovanjes;
        }

        public List<Tekmovanje> VsaTekmovanja()
        {
            return db.tekmovanja.ToList();
        }

        public List<Atlet> VsiAtleti()
        {
            //List<Atlet> atlets = new List<Atlet>();
            //foreach (var item in db.atlets)
            //{
            //    atlets.Add(item);
            //}
            Atlet[] att = vsiAtleti().ToArray();
            List<Atlet> at = att.ToList();
            return at;
        }
        IEnumerable<Atlet> vsiAtleti()
        {
            foreach (var item in db.atlets)
            {
                yield return item;
            }
        }








    }
}
