using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Naloga5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Uporabnik UstvariUporabnika(string uporabniskoIme, string geslo, bool admin);

        [OperationContract]
        Atlet UstvariAtleta(string ime, string priimek, DateTime datumRojstva);

        [OperationContract]
        Tekmovanje UstvariTekmovanje(string naziv, string kraj, DateTime datumTekmovanja);

        [OperationContract]
        bool Uredi(string tabela, string id, string imeStolpca, string vrednost);

        [OperationContract]
        bool Izbrisi(string ime, string id);

        [OperationContract]
        void DodajAtletaTekmovanju(string naziv, string ime, string priimek);

        [OperationContract]
        void DodajTekmovanjeAtletu(string naziv, string ime, string priimek);

        [OperationContract]
        void OdstraniTekmovanjeIzAtleta(string naziv, string ime, string priimek);

        [OperationContract]
        void OdstraniAtletaIztekmovanja(string naziv, string ime, string priimek);


        [OperationContract]
        Uporabnik VpisUporabnika(string username, string password);
        [OperationContract]
        List<Atlet> VsiAtletiNaTekmovanju(string naziv);

        [OperationContract]
        List<Tekmovanje> VsaTekmovanjaNaKaterihNastopaAtlet(string ime, string priimek);


        [OperationContract]
        List<Tekmovanje> VsaTekmovanja();

        [OperationContract]
        List<Atlet> VsiAtleti();



    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Atlet
    {
        public Atlet()
        {
            this.Tekmovanjes = new HashSet<Tekmovanje>();
        }

        public Atlet(string ime, string priimek, DateTime datumRojstva)
        {
            Ime = ime;
            Priimek = priimek;
            DatumRojstva = datumRojstva;
            this.Tekmovanjes = new HashSet<Tekmovanje>();
        }

        [DataMember]
        public string Ime { get; set; }

        [DataMember]
        public string Priimek { get; set; }

        [DataMember]
        public DateTime DatumRojstva { get; set; }

        [Key]
        public int ID { get; set; }
        public virtual ICollection<Tekmovanje> Tekmovanjes { get; set; }
    }


    [DataContract]
    public class Tekmovanje
    {
        public Tekmovanje()
        {
            this.Atlets = new HashSet<Atlet>();
        }

        public Tekmovanje(string naziv, string kraj, DateTime datumTekmovanja)
        {
            Naziv = naziv;
            Kraj = kraj;
            DatumTekmovanja = datumTekmovanja;
            this.Atlets = new HashSet<Atlet>();
        }

        [DataMember]
        public string Naziv { get; set; }

        [DataMember]
        public string Kraj { get; set; }

        [DataMember]
        public DateTime DatumTekmovanja { get; set; }

        [Key]
        public int ID { get; set; }
        public virtual ICollection<Atlet> Atlets { get; set; }
    }

    [DataContract]
    public class Uporabnik
    {
        public Uporabnik(string uporabniskoIme, string geslo, bool admin)
        {
            UporabniskoIme = uporabniskoIme;
            Geslo = geslo;
            Admin = admin;
        }

        [DataMember]
        public string UporabniskoIme { get; set; }

        [DataMember]
        public string Geslo { get; set; }

        [DataMember]
        public bool Admin { get; set; }

        [Key]
        public int ID { get; set; }
    }



    public class AtletikaContext : DbContext
    {

        public AtletikaContext() : base("Baza")
        {
            Database.SetInitializer<AtletikaContext>(new BazaInitializier());
        }

        public DbSet<Atlet> atlets { get; set; }
        public DbSet<Tekmovanje> tekmovanja { get; set; }
        public DbSet<Uporabnik> Uporabniks { get; set; }
    }


    public class BazaInitializier : DropCreateDatabaseIfModelChanges<AtletikaContext>
    {
        protected override void Seed(AtletikaContext context)
        {
            Atlet marko = new Atlet("Marko", "Simunovic", new DateTime(2000, 5, 12));
            Atlet lina = new Atlet("Lina", "Cater", new DateTime(2000, 10, 5));
            Atlet blaz = new Atlet("Blaz", "Roznman", new DateTime(2002, 2, 14));

            Tekmovanje tekmovanje1 = new Tekmovanje("APS", "Celje", new DateTime(2019, 9, 12));
            Tekmovanje tekmovanje2 = new Tekmovanje("Drzavno prvenstvo", "Novo mesto", new DateTime(2020, 9, 12));
            Tekmovanje tekmovanje3 = new Tekmovanje("Miting", "Koper", new DateTime(2018, 9, 12));



            context.atlets.Add(marko);
            context.atlets.Add(lina);
            context.atlets.Add(blaz);

            context.tekmovanja.Add(tekmovanje1);
            context.tekmovanja.Add(tekmovanje2);
            context.tekmovanja.Add(tekmovanje3);
            base.Seed(context);
        }
    }



}