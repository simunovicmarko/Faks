using System;
using System.IO;
using System.IO.Pipes;
using System.Net.Http.Headers;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new NamedPipeClientStream("Server");
            client.Connect();
            Console.WriteLine("Povezava uspesna");

            StreamReader sr = new StreamReader(client);
            StreamWriter sw = new StreamWriter(client);


            string vnos;
            bool nadaljuj = true;
            bool koncaj = false;
            while (true)
            {

                while (nadaljuj)
                {
                    Console.WriteLine(sr.ReadLine());
                    vnos = Console.ReadLine();
                    sw.WriteLine(vnos);
                    try{sw.Flush();} catch(Exception){};
                    string s = sr.ReadLine();
                    while (s != "")
                    {
                        Console.WriteLine(s);
                        if (s == "Napacen vnos")
                        {
                            break;
                        }
                        s = sr.ReadLine();
                    }
                    if (s == "")
                    {
                        nadaljuj = false;
                    }
                }
                //Console.WriteLine("SOU je naprej");

                //Preverjanje ali želi uporabnik nadaljevati
                nadaljuj = true;
                while (nadaljuj)
                {
                    Console.WriteLine(sr.ReadLine());
                    vnos = Console.ReadLine();
                    sw.WriteLine(vnos);
                    try{sw.Flush();} catch(Exception){};
                    string s = sr.ReadLine();
                    if (s == "")
                    {
                        nadaljuj = false;
                    }
                    else if (s == "Koncaj")
                    {
                        client.Close();
                        nadaljuj = false;
                        koncaj = true;
                    }
                    else
                    {
                        Console.WriteLine("Napacen vnos");
                    }
                }
                if (koncaj == true)
                {
                    break;
                }
                //Console.WriteLine("2");


                //Vnos operatorja
                nadaljuj = true;
                while (nadaljuj)
                {
                    Console.WriteLine(sr.ReadLine());
                    vnos = Console.ReadLine();
                    sw.WriteLine(vnos);
                    try{sw.Flush();} catch(Exception){};
                    string s = sr.ReadLine();
                    if (s == "Uspesno")
                    {
                        nadaljuj = false;
                    }
                    else
                    {
                        Console.WriteLine("Napacen vnos");
                    }
                }
                //Console.WriteLine("3");

                nadaljuj = true;
                //Console.WriteLine(sr.ReadLine());
                //sw.WriteLine(Console.ReadLine());
                //try{sw.Flush();} catch(Exception){};
                //Console.WriteLine(sr.ReadLine());                
            }



        }
    }
}
