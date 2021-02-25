using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace simunovic_marko_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    //[ServiceContract]
    //public interface IService1
    //{

    //    [OperationContract]
    //    string GetData(int value);

    //    [OperationContract]
    //    CompositeType GetDataUsingDataContract(CompositeType composite);

        
    //    // TODO: Add your service operations here
    //}

    [ServiceContract]
    public interface IDeloSSeznami
    {
        [OperationContract]
        Uporabnik UstvariUporabnika(string uporabniskoIme, string geslo, bool admin);

        [OperationContract]
        Atlet UstvariAtleta(string ime, string priimek, DateTime datumRojstva);

        [OperationContract]
        Tekmovanje UstvariTekmovanje(string naziv, string kraj, DateTime datumTekmovanja);

        [OperationContract]
        AtletTekmovanje UstvariTekmovanjeAtlet(Atlet atlet, Tekmovanje tekmovanje, string rezultat);

        

        [OperationContract]
        Uporabnik VpisUporabnika(string username, string password);

        
        ////////////////////////////////////////////////////
        
        [OperationContract]
        List<Atlet> VsiAtletiNaTekmovanju(string naziv);

        [OperationContract]
        List<Tekmovanje> VsaTekmovanjaNaKaterihNastopAtlet(string ime, string priimek);

        [OperationContract]
        Atlet PodrobnostiAtleta(string ime, string priimek);

        [OperationContract]
        Tekmovanje TekmovanjeZNajvecAtleti();

        [OperationContract]
        Atlet NajstarejsiAtlet();

        [OperationContract]
        double PovprecnaStarostAtleta();

        [OperationContract]
        List<Atlet> VsiAtleti();

        [OperationContract]
        List<Tekmovanje> VsaTekmovanja();

        

        [OperationContract]
        List<Atlet> VrniAtlete();

        [OperationContract]
        bool Uredi(string tabela, string id, string imeStolpca, string vrednost);






    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.


    [DataContract]
    public class Atlet
    {
        private string ime, priimek;
        private DateTime datumRojstva;

        public Atlet(string ime, string priimek, DateTime datumRojstva)
        {
            this.ime = ime;
            this.priimek = priimek;
            this.datumRojstva = datumRojstva;
        }

        public Atlet()
        {
            this.Tekmovanjes = new HashSet<Tekmovanje>();
        }

        [DataMember]
        public string Ime { get => ime; set => ime = value; }

        [DataMember]
        public string Priimek { get => priimek; set => priimek = value; }

        [DataMember]
        public DateTime DatumRojstva { get => datumRojstva; set => datumRojstva = value; }

        [Key]
        public int ID { get; set; }
        public virtual ICollection<Tekmovanje> Tekmovanjes { get; set; }

    }


    [DataContract]
    public class Tekmovanje
    {
        private string naziv, kraj;
        private DateTime datumTekmovanja;

        public Tekmovanje(string naziv, string kraj, DateTime datumTekmovanja)
        {
            this.naziv = naziv;
            this.kraj = kraj;
            this.datumTekmovanja = datumTekmovanja;
        }

        [DataMember]
        public string Naziv { get => naziv; set => naziv = value; }

        [DataMember]
        public string Kraj { get => kraj; set => kraj = value; }

        [DataMember]
        public DateTime DatumTekmovanja { get => datumTekmovanja; set => datumTekmovanja = value; }

        [Key]
        public int ID { get; set; }
        public virtual ICollection<Atlet> Atlets { get; set; }
    }

    [DataContract]
    public class AtletTekmovanje
    {
        private Atlet atlet;
        private Tekmovanje tekmovanje;
        private string rezultat;

        public AtletTekmovanje()
        {
            this.Atleti = new HashSet<Atlet>();
            this.Tekmovanja = new HashSet<Tekmovanje>();
        }


        public AtletTekmovanje(Atlet atlet, Tekmovanje tekmovanje)
        {
            this.atlet = atlet;
            this.tekmovanje = tekmovanje;
        }

        public AtletTekmovanje(Atlet atlet, Tekmovanje tekmovanje, string rezultat)
        {
            this.atlet = atlet;
            this.tekmovanje = tekmovanje;
            this.Rezultat = rezultat;
        }

        [DataMember]
        public Atlet Atlet { get => atlet; set => atlet = value; }
        [DataMember]
        public Tekmovanje Tekmovanje { get => tekmovanje; set => tekmovanje = value; }
        [DataMember]
        public string Rezultat { get => rezultat; set => rezultat = value; }

        public int AtletTekmovanjeID { get; set; }

        public virtual ICollection<Atlet> Atleti { get; set; }
        public virtual ICollection<Tekmovanje> Tekmovanja { get; set; }
    }

    [DataContract]
    public class Uporabnik
    {
        private string uporabniskoIme, geslo;
        private bool admin;



        public Uporabnik(string uporabniskoIme, string geslo, bool admin)
        {
            this.uporabniskoIme = uporabniskoIme;
            this.geslo = geslo;
            this.admin = admin;
        }

        [DataMember]
        public string UporabniskoIme { get => uporabniskoIme; set => uporabniskoIme = value; }

        [DataMember]
        public string Geslo { get => geslo; set => geslo = value; }

        [DataMember]
        public bool Admin { get => admin; set => admin = value; }

        [Key]
        public int ID { get; set; }
    }


    //
    
    public class AtletikaContext : DbContext
    {
        
        public AtletikaContext() : base("Baza")
        {
            Database.SetInitializer<AtletikaContext>(new BazaInitializier());
        }

        public DbSet<Atlet> atlets { get; set; }
        public DbSet<Tekmovanje> tekmovanja { get; set; }
        public DbSet<AtletTekmovanje> AtletTekmovanjes { get; set; }

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


            Uporabnik uporabnik1 = new Uporabnik("Sime", "geslo123", true);
            Uporabnik uporabnik2 = new Uporabnik("Queno", "geslo123", false);
            Uporabnik uporabnik3 = new Uporabnik("Piscanc", "geslo123", false);



            context.atlets.Add(marko);
            context.atlets.Add(lina);
            context.atlets.Add(blaz);

            context.tekmovanja.Add(tekmovanje1);
            context.tekmovanja.Add(tekmovanje2);
            context.tekmovanja.Add(tekmovanje3);


            context.Uporabniks.Add(uporabnik1);
            context.Uporabniks.Add(uporabnik2);
            context.Uporabniks.Add(uporabnik3);
            base.Seed(context);
        }
    }

}
