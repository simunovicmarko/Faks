using Client.Povezava;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Povezava.Service1Client client = new Povezava.Service1Client();
            while (true)
            {
                PogledNaloga4();
                string izbira = Console.ReadLine();

                switch (izbira)
                {
                    case "1":
                        List<Atlet> atleti = client.VsiAtleti();
                        foreach (var item in atleti)
                        {
                            IzpisAtlet(item);
                        }
                        break;
                    case "2":
                        List<Tekmovanje> tekmovanjes = client.VsaTekmovanja();
                        foreach (var item in tekmovanjes)
                        {
                            IzpisTekmovanje(item);
                        }
                        break;
                    case "3":
                        dodajUporbnika(client);
                        break;

                    case "4":
                        dodajAtleta(client);
                        break;

                    case "5":
                        dodajTekmovanje(client);
                        break;

                    case "6":
                        dodajAtletaTekmovanju(client);
                        break;

                    case "7":
                        dodajTekmovanjeAtletu(client);
                        break;

                    case "8":
                        odstraniAtletaIztekmovanja(client);
                        break;

                    case "9":
                        odstraniTekmovanjeIzAtleta(client);
                        break;
                    case "10":
                        uredi(client);
                        break;
                    case "11":
                        izbrisi(client);
                        break;


                }


            }




            //Implementacija dodaj


        }





        static void PogledNaloga4()
        {
            Console.WriteLine("1. Vsi atleti");
            Console.WriteLine("2. Vsa tekmovanja");
            Console.WriteLine("3. Dodaj uporabnika");
            Console.WriteLine("4. Dodaj atleta");
            Console.WriteLine("5. Dodaj tekmovanje");
            Console.WriteLine("6. Dodaj atleta tekmovanju");
            Console.WriteLine("7. Dodaj tekmovanje atletu");
            Console.WriteLine("8. Odstrani atleta tekmovanju");
            Console.WriteLine("9. Odstrani tekmovanje atletu");
            Console.WriteLine("10. Uredi");
            Console.WriteLine("11. Odstrani");



        }


        static void dodajUporbnika(Povezava.Service1Client client)
        {
            Console.WriteLine("Vnesi ime");
            string ime = Console.ReadLine();
            Console.WriteLine("Vnesi geslo");
            string geslo = Console.ReadLine();
            Console.WriteLine("Vnesi admin (0/1)");
            string admin = Console.ReadLine();
            bool ad;
            if (admin == "1")
            {
                ad = true;
            }
            else
                ad = false;

            client.UstvariUporabnika(ime, geslo, ad);

        }


        static void dodajAtleta(Povezava.Service1Client client)
        {
            Console.WriteLine("Vnesi ime");
            string ime = Console.ReadLine();
            Console.WriteLine("Vnesi priimek");
            string priimek = Console.ReadLine();
            Console.WriteLine("Vnos datuma rojstva");
            DateTime datum = UstvariDatum();

            client.UstvariAtleta(ime, priimek, datum);

        }

        static void dodajTekmovanje(Povezava.Service1Client client)
        {
            Console.WriteLine("Vnesi naziv");
            string ime = Console.ReadLine();
            Console.WriteLine("Vnesi kraj");
            string kraj = Console.ReadLine();
            Console.WriteLine("Vnos datuma tekmovanja");
            DateTime datum = UstvariDatum();

            client.UstvariTekmovanje(ime, kraj, datum);

        }


        static void uredi(Povezava.Service1Client client)
        {
            Console.WriteLine("Vnesi tabelo");
            string tabela = Console.ReadLine();

            Console.WriteLine("Vnesi id");
            string id = Console.ReadLine();


            Console.WriteLine("Vnesi ime stolpca");
            string stolpec = Console.ReadLine();

            Console.WriteLine("Vnesi vrednost");
            string vrednost = Console.ReadLine();


            client.Uredi(tabela, id, stolpec, vrednost);
        }

        static void izbrisi(Povezava.Service1Client client)
        {
            Console.WriteLine("Vnesi tabelo");
            string tabela = Console.ReadLine();

            Console.WriteLine("Vnesi id");
            string id = Console.ReadLine();

            client.Izbrisi(tabela, id);
        }

        static void dodajAtletaTekmovanju(Povezava.Service1Client client)
        {
            Console.WriteLine("Vnesi ime atleta");
            string ime = Console.ReadLine();
            Console.WriteLine("Vnesi priimek atleta");
            string priimek = Console.ReadLine();
            Console.WriteLine("Vnesi naziv tekmovanja");
            string tekmovanje = Console.ReadLine();

            client.DodajAtletaTekmovanju(tekmovanje, ime, priimek);
        }

        static void dodajTekmovanjeAtletu(Povezava.Service1Client client)
        {
            Console.WriteLine("Vnesi ime atleta");
            string ime = Console.ReadLine();
            Console.WriteLine("Vnesi priimek atleta");
            string priimek = Console.ReadLine();
            Console.WriteLine("Vnesi naziv tekmovanja");
            string tekmovanje = Console.ReadLine();

            client.DodajTekmovanjeAtletu(tekmovanje, ime, priimek);
        }

        static void odstraniTekmovanjeIzAtleta(Povezava.Service1Client client)
        {
            Console.WriteLine("Vnesi ime atleta");
            string ime = Console.ReadLine();
            Console.WriteLine("Vnesi priimek atleta");
            string priimek = Console.ReadLine();
            Console.WriteLine("Vnesi naziv tekmovanja");
            string tekmovanje = Console.ReadLine();

            client.OdstraniTekmovanjeIzAtleta(tekmovanje, ime, priimek);
        }



        static void odstraniAtletaIztekmovanja(Povezava.Service1Client client)
        {
            Console.WriteLine("Vnesi ime atleta");
            string ime = Console.ReadLine();
            Console.WriteLine("Vnesi priimek atleta");
            string priimek = Console.ReadLine();
            Console.WriteLine("Vnesi naziv tekmovanja");
            string tekmovanje = Console.ReadLine();

            client.OdstraniAtletaIztekmovanja(tekmovanje, ime, priimek);
        }


        static string IzpisAtlet(Atlet atlet)
        {
            return atlet.Ime + " " + atlet.Priimek + " " + atlet.DatumRojstva;
        }

        static string IzpisTekmovanje(Tekmovanje tekmovanje)
        {
            return tekmovanje.Naziv + " " + tekmovanje.Kraj + " " + tekmovanje.DatumTekmovanja;
        }

        static DateTime UstvariDatum()
        {
            Console.WriteLine("Vnesite dan");
            int dan = int.Parse(Console.ReadLine());
            Console.WriteLine("Vnesite mesec");
            int mesec = int.Parse(Console.ReadLine());
            Console.WriteLine("Vnesite leto");
            int leto = int.Parse(Console.ReadLine());

            return new DateTime(leto, mesec, dan);
        }
    }
}
