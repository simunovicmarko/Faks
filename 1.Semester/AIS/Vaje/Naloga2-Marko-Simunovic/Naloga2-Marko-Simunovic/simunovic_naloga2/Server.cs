using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Naloga2_Marko_Simunovic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stevila = new int[10];


            var server = new NamedPipeServerStream("Server");
            server.WaitForConnection();
            Console.WriteLine("Server povezan");
            StreamReader sr = new StreamReader(server);
            StreamWriter sw = new StreamWriter(server);

            string vnos;
            int stevka;
            string vun;
            char opr = '+';

            while (server.IsConnected)
            {
                //Izpis
                vun = "";
                bool veljavenVnos = false;
                while (server.IsConnected &&!veljavenVnos)
                {
                    sw.WriteLine("Vnesite stevilo");
                    try { sw.Flush(); } catch (Exception) { }
                    vnos = sr.ReadLine();
                    try
                    {
                        //Enkrat parsa da vidi če je cel string število pol pa vsak znak posebi
                        int.Parse(vnos);
                        foreach (var znak in vnos)
                        {
                            stevka = int.Parse(znak.ToString());
                            if (opr == '+')
                            {
                                stevila[stevka]++;
                            }
                            else
                                stevila[stevka]--;

                        }

                        //Vse zloži v en string
                        for (int i = 0; i < stevila.Length; i++)
                        {
                            vun = vun + i + " - " + stevila[i] + "x\n";

                        }
                        sw.WriteLine(vun);
                        try { sw.Flush(); } catch (Exception) { }
                        veljavenVnos = true;
                    }
                    catch (Exception)
                    {
                        sw.WriteLine("Napacen vnos");
                        try { sw.Flush(); } catch (Exception) { }
                    }
                }
                //Preverjanje ali želi uporabnik nadaljevati
                veljavenVnos = false;
                while (server.IsConnected &&!veljavenVnos)
                {
                    sw.WriteLine("Ali želite nadaljevati");
                    try { sw.Flush(); } catch (Exception) { }
                    vnos = sr.ReadLine();
                    if (vnos.ToLower() == "da" || vnos.ToLower() == "ne")
                    {
                        veljavenVnos = true;
                        if (vnos.ToLower() == "ne")
                        {
                            sw.WriteLine("Koncaj");
                            try { sw.Flush(); } catch (Exception) { }
                            break;
                        }
                        else
                        {
                            sw.WriteLine("");
                            try { sw.Flush(); } catch (Exception) { }
                        }

                    }
                    else
                    {
                        sw.WriteLine("Napaka");
                        try { sw.Flush(); } catch (Exception) { }
                    }
                }


                //Vnos operatorja
                veljavenVnos = false;
                while (server.IsConnected &&!veljavenVnos)
                {
                    sw.WriteLine("Vnesite operator");
                    try { sw.Flush(); } catch (Exception) { }
                    vnos = sr.ReadLine();
                    if (vnos == "+")
                    {
                        opr = '+';
                        veljavenVnos = true;
                        sw.WriteLine("Uspesno");
                        try { sw.Flush(); } catch (Exception) { }
                    }
                    else if (vnos == "-")
                    {
                        opr = '-';
                        veljavenVnos = true;
                        sw.WriteLine("Uspesno");
                        try { sw.Flush(); } catch (Exception) { }
                    }
                    else
                    {
                        sw.WriteLine("");
                        try { sw.Flush(); } catch (Exception) { }
                    }
                }

                veljavenVnos = false;
            }
            Console.WriteLine("Disconnect");
            
        }
    }
}
