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
            Povezava.DeloSSeznamiClient client = new DeloSSeznamiClient();
            VnosPodatkov(client);


            //Glavni del programa
            Uporabnik vpisanUporabnik = null;

            vpisanUporabnik = Vpis(client);

            while (true)
            {
                //Izpis možnosti
                if (vpisanUporabnik.Admin)
                    AdminPogled();
                else
                    UporabniskiPogled();

                Console.WriteLine("Katero opercijo želite izvesti");
                int operacija = 0;
                try
                {
                     operacija = int.Parse(Console.ReadLine());
                }
                catch (Exception) { }
                
                
                string ime, priimek, naziv;
                switch (operacija)
                {
                    case 1:
                        Console.WriteLine("Vpišite naziv");
                        naziv = Console.ReadLine();
                        List<Atlet> atlets = client.VsiAtletiNaTekmovanju(naziv);
                        foreach (var item in atlets)
                        {
                            if (item != null)
                                Console.WriteLine(IzpisAtlet(item));
                        }
                        break;
                    case 2:
                        Console.WriteLine("Vnesite Ime");
                        ime = Console.ReadLine();
                        Console.WriteLine("Vnesite Priimek");
                        priimek = Console.ReadLine();
                        List<Tekmovanje> tekmovanjes = client.VsaTekmovanjaNaKaterihNastopAtlet(ime, priimek);
                        foreach (var item in tekmovanjes)
                        {
                            if (item != null)
                                Console.WriteLine(IzpisTekmovanje(item));
                        }
                        break;
                    case 3:
                        Console.WriteLine("Vnesite Ime");
                        ime = Console.ReadLine();
                        Console.WriteLine("Vnesite Priimek");
                        priimek = Console.ReadLine();
                        Atlet atlet = client.PodrobnostiAtleta(ime, priimek);
                        if (atlet != null)
                            Console.WriteLine(IzpisAtlet(atlet));
                        break;
                    case 4:
                        Tekmovanje tekmovanje = client.TekmovanjeZNajvecAtleti();
                        if (tekmovanje != null)
                            Console.WriteLine(IzpisTekmovanje(tekmovanje));
                        break;
                    case 5:
                        if (IzpisAtlet(client.NajstarejsiAtlet()) != null)
                            Console.WriteLine(IzpisAtlet(client.NajstarejsiAtlet()));
                        break;
                    case 6:
                        Console.WriteLine(client.PovprecnaStarostAtleta());
                        break;
                    case 7:
                        if (vpisanUporabnik.Admin)
                        {
                            List<Atlet> atlets1 = client.VsiAtleti();
                            foreach (var item in atlets1)
                            {
                                if (item != null)
                                    Console.WriteLine(IzpisAtlet(item));
                            }
                        }
                        else
                            Console.WriteLine("Nimate pravic ali funkcionalnost ne obstaja");
                        break;
                    case 8:
                        if (vpisanUporabnik.Admin)
                        {
                            List<Tekmovanje> tekmovanjes1 = client.VsaTekmovanja();
                            foreach (var item in tekmovanjes1)
                            {
                                Console.WriteLine(IzpisTekmovanje(item));
                            }
                        }
                        else
                            Console.WriteLine("Nimate pravic ali funkcionalnost ne obstaja");
                        break;
                    default:
                        Console.WriteLine("Nimate pravic ali funkcionalnost ne obstaja");
                        break;
                }

                Console.WriteLine();
            }





        }

        static void VnosPodatkov(Povezava.DeloSSeznamiClient client)
        {
            //Vnos podatkov
            Atlet marko = client.UstvariAtleta("Marko", "Simunovic", new DateTime(2000, 5, 12));
            Atlet lina = client.UstvariAtleta("Lina", "Cater", new DateTime(2000, 10, 5));
            Atlet blaz = client.UstvariAtleta("Blaz", "Roznman", new DateTime(2002, 2, 14));

            Tekmovanje tekmovanje1 = client.UstvariTekmovanje("APS", "Celje", new DateTime(2019, 9, 12));
            Tekmovanje tekmovanje2 = client.UstvariTekmovanje("Drzavno prvenstvo", "Novo mesto", new DateTime(2020, 9, 12));
            Tekmovanje tekmovanje3 = client.UstvariTekmovanje("Miting", "Koper", new DateTime(2018, 9, 12));

            AtletTekmovanje atletTekmovanje1 = client.UstvariTekmovanjeAtlet(marko, tekmovanje1, "17.44");
            AtletTekmovanje atletTekmovanje4 = client.UstvariTekmovanjeAtlet(lina, tekmovanje1, "17.44");
            AtletTekmovanje atletTekmovanje5 = client.UstvariTekmovanjeAtlet(blaz, tekmovanje1, "17.44");
            AtletTekmovanje atletTekmovanje2 = client.UstvariTekmovanjeAtlet(lina, tekmovanje2, "61.32");
            AtletTekmovanje atletTekmovanje3 = client.UstvariTekmovanjeAtlet(blaz, tekmovanje3, "57.45");
            AtletTekmovanje atletTekmovanje6 = client.UstvariTekmovanjeAtlet(blaz, tekmovanje3, "57.45");
            AtletTekmovanje atletTekmovanje7 = client.UstvariTekmovanjeAtlet(blaz, tekmovanje3, "57.45");
            AtletTekmovanje atletTekmovanje8 = client.UstvariTekmovanjeAtlet(blaz, tekmovanje3, "57.45");

            Uporabnik uporabnik1 = client.UstvariUporabnika("Sime", "geslo123", true);
            Uporabnik uporabnik2 = client.UstvariUporabnika("Queno", "geslo123", false);
            Uporabnik uporabnik3 = client.UstvariUporabnika("Piscanc", "geslo123", false);
            Uporabnik uporabnik4 = client.UstvariUporabnika("", "", true);
        }

        static Uporabnik Vpis(Povezava.DeloSSeznamiClient client)
        {
            //dokler ne vnese pravilnih podatkov program zahteva vnos podatkov
            Uporabnik uporabnik = null;
            string username, geslo;

            while (uporabnik == null)
            {
                Console.WriteLine("Vnesite uporabniško ime");
                username = Console.ReadLine();
                Console.WriteLine("Vnesite geslo");
                geslo = Console.ReadLine();
                uporabnik = client.VpisUporabnika(username, geslo);
                if (uporabnik == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Napačen vnos\nPoskusite ponovno");
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Uspešen vpis");
            }

            return uporabnik;
        }

        static void UporabniskiPogled()
        {
            Console.WriteLine("1. Vsi atleti, ki so nastopali na tekmovanju");
            Console.WriteLine("2. Vsa tekmovanja na katerih je nastopal atlet");
            Console.WriteLine("3. Podrobnosti atleta");
            Console.WriteLine("4. Tekmovanje z največ atleti");
            Console.WriteLine("5. Najstarejši atlet");
            Console.WriteLine("6. Povprečna starost atleta");
        }

        static void AdminPogled()
        {
            UporabniskiPogled();
            Console.WriteLine("7. Vsi atleti");
            Console.WriteLine("8. Vsa tekmovanja");
        }

        static string IzpisAtlet(Atlet atlet)
        {
            return atlet.Ime + " " + atlet.Priimek + " " + atlet.DatumRojstva;
        }

        static string IzpisTekmovanje(Tekmovanje tekmovanje)
        {
            return tekmovanje.Naziv + " " + tekmovanje.Kraj + " " + tekmovanje.DatumTekmovanja;
        }
    }
}
