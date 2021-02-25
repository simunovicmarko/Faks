using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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

        



    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

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

        [DataMember]
        public string Ime { get => ime; set => ime = value; }

        [DataMember]
        public string Priimek { get => priimek; set => priimek = value; }

        [DataMember]
        public DateTime DatumRojstva { get => datumRojstva; set => datumRojstva = value; }
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
    }

    [DataContract]
    public class AtletTekmovanje
    {
        private Atlet atlet;
        private Tekmovanje tekmovanje;
        private string rezultat;

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
    }

}
