using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Security.Policy;

namespace Freya_Discord_Nitro_Cashout_1._0._1
{
    class Program
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static int genchecker = 0;
        static int ratechecker = 0;
        static int connectionchecker = 0;
        static int hitschecker = 0;
        static int invalidchecker = 0;
        static int proxychecker = 0;
        static int proxylinecount = 0;
        static string proxynotedited;
        static int proxylinecounter = 0;
        static string ip = "";
        static int port = 0;
        static string location = @"";
        static string ip2 = "";

        static void gencker()
        {

            Console.ForegroundColor = ConsoleColor.Green;

            string random = RandomString(16);

            string nitrogenerated = "http://discord.gift/" + random;

            Console.WriteLine(nitrogenerated);

            string url = "https://discord.com/api/v8/entitlements/gift-codes/%7B" + random;

            string url2 = "https://api.ipify.org";

            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(url);


            string[] lines = File.ReadAllLines(location);
            if (lines.Length > 0)
            proxynotedited = lines[proxylinecounter];
            
            proxylinecounter++;

            string[] editedproxy = proxynotedited.Split(':');

            ip = editedproxy[0];
            port = Convert.ToInt32(editedproxy[1]);



            WebProxy myproxy = new WebProxy(ip, port);

            string ip3 = ip + ":" + port;


            //IP
            HttpWebRequest request1;
            
            //Discord
            HttpWebRequest request2;

            //Discord
            request2 = (HttpWebRequest)WebRequest.Create(url);
            request2.Proxy = myproxy;
            //request2.Timeout = 10000;


            //IP
            request1 = (HttpWebRequest)WebRequest.Create(url2);
            request1.Timeout = 10000;
            request1.Proxy = myproxy;


            string asd = "";

            try
            {

                var responsee = (HttpWebResponse)request1.GetResponse();

                var responsee2 = (HttpWebResponse)request2.GetResponse();

                ip2 = Convert.ToString(responsee2);

                if (responsee.ToString().Contains("redeemed"))
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[+] HIT: " + nitrogenerated);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[API Link] " + (url));
                    Console.WriteLine("");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[IP Address in use] " + ip2);
                    Console.WriteLine("");
                    Console.WriteLine("");

                    genchecker++;

                    hitschecker++;

                    Console.Title = "Hits: " + hitschecker + " | " + "Invalids: " + invalidchecker + " | " + "Connection Error(s): " + connectionchecker + " | " + "Rate Limit(s): " + ratechecker + " | " + "Generated: " + genchecker;


                }
                

                /*
                if (responsee.StatusCode == HttpStatusCode.NotFound)
                    {
                        asd = "404";

                    }

                    else if (responsee.StatusCode == HttpStatusCode.OK)
                    {
                        asd = "OK";

                    }

                    else
                    {
                        asd = "Rate";

                    }
                */


                    /*
                        if (responsee.StatusCode == HttpStatusCode.OK)
                        {
                            asd = "OK";
                        }

                        else if (responsee.StatusCode == HttpStatusCode.NotFound)
                        {
                            asd = "404";
                        }

                        else
                        {
                            asd = "None";
                        }
                    */


                myproxy.BypassProxyOnLocal = false;
                request1.Proxy = myproxy;
                request1.Method = "GET";
            }




            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[-] Invalid Code!");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[API Link] " + (url));
                    Console.WriteLine("");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[IP Address in use] " + ip3);
                    Console.WriteLine("");
                    Console.WriteLine("");

                    invalidchecker++;

                    genchecker++;

                    Console.Title = "Hits: " + hitschecker + " | " + "Invalids: " + invalidchecker + " | " + "Connection Error(s): " + connectionchecker + " | " + "Rate Limit(s): " + ratechecker + " | " + "Generated: " + genchecker;
                }

                else if (ex.Message.Contains("429"))
                {

                    Console.WriteLine(asd);

                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    Console.WriteLine("[#] Rate limited! Retry after 10 Minutes!");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[API Link] " + (url));
                    Console.WriteLine("");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[IP Address in use] " + ip3);
                    Console.WriteLine("");
                    Console.WriteLine("");

                    ratechecker++;

                    genchecker++;

                    Console.Title = "Hits: " + hitschecker + " | " + "Invalids: " + invalidchecker + " | " + "Connection Error(s): " + connectionchecker + " | " + "Rate Limit(s): " + ratechecker + " | " + "Generated: " + genchecker;
                }
            

                else if (ex.Message.Contains("redeemed"))
                 {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("[+] HIT: " + nitrogenerated);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[API Link] " + (url));
                    Console.WriteLine("");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[IP Address in use] " + ip3);
                    Console.WriteLine("");
                    Console.WriteLine("");

                    genchecker++;

                    hitschecker++;

                    Console.Title = "Hits: " + hitschecker + " | " + "Invalids: " + invalidchecker + " | " + "Connection Error(s): " + connectionchecker + " | " + "Rate Limit(s): " + ratechecker + " | " + "Generated: " + genchecker;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[-] Connection Error!");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[API Link] " + (url));
                    Console.WriteLine("");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[IP Address in use] " + ip3);
                    Console.WriteLine("");
                    Console.WriteLine("");

                    connectionchecker++;
                    genchecker++;

                    Console.Title = "Hits: " + hitschecker + " | " + "Invalids: " + invalidchecker + " | " + "Connection Error(s): " + connectionchecker + " | " + "Rate Limit(s): " + ratechecker + " | " + "Generated: " + genchecker;
                }

            }









            /*


            using (var client = new WebClient())
            {
                //"198.199.86.11", 8080
                //client.Proxy = new WebProxy("173.212.228.57", 3128);




                try
                {
                    client.DownloadString(url);
                }
                catch (WebException wex)
                {

                    if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.OK)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("[+] HIT: " + nitrogenerated);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("[API Link] " + (url));
                        Console.WriteLine("");

                        genchecker++;

                        hitschecker++;

                        Console.Title = "Hits: " + hitschecker + " | " + "Invalids: " + invalidchecker + " | " + "Connection Error(s): " + connectionchecker + " | " + "Rate Limit(s): " + ratechecker + " | " + "Generated: " + genchecker;
                    }

                    else if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("[-] Invalid Code!");

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("[API Link] " + (url));
                        Console.WriteLine("");

                        invalidchecker++;

                        genchecker++;

                        Console.Title = "Hits: " + hitschecker + " | " + "Invalids: " + invalidchecker + " | " + "Connection Error(s): " + connectionchecker + " | " + "Rate Limit(s): " + ratechecker + " | " + "Generated: " + genchecker;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                        Console.WriteLine("[#] Rate limited! Retry after 10 Minutes!");

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("[API Link] " + (url));
                        Console.WriteLine("");

                        ratechecker++;

                        genchecker++;

                        Console.Title = "Hits: " + hitschecker + " | " + "Invalids: " + invalidchecker + " | " + "Connection Error(s): " + connectionchecker + " | " + "Rate Limit(s): " + ratechecker + " | " + "Generated: " + genchecker;
                    }




                }
            }

            */
        }










        static void Main(string[] args)
        {

            int startchecker = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;


            Console.WriteLine("This application was developed by Endarionn for TurkHackTeam.");
            Console.WriteLine("https://www.turkhackteam.org/");

            Console.WriteLine("");

            Console.WriteLine("The logic is pretty simple. First of all I use api to check if nitro is working. However, different situations may occur when using APIs. For example, code 404 means that the nitro is not working, code 429 means that you have been banned for a short time, etc.");

            Console.WriteLine("");

            Console.WriteLine("According to the answers we received from the API, we can see the code and its status in the console.");

            Console.WriteLine("");

            Console.WriteLine("OK, I WILL ADD PROXY FEATURE SOON. I DIDN'T THINK THE DIFFICULTS TO USE THIS APPLICATION WHO CANNOT WRITE 2 3 LINES OF CODE AND ADD PROXY FEATURE. But if you get a rate limit ban until i add proxy to checker, use Vpn.");

            Console.WriteLine("");

            Console.WriteLine("By the way, if the text appears in yellow it means valid, if it appears red it means invalid, if it appears blue it means ip ban, if it appears white again it means connection error.");

            Console.WriteLine("");

            //Console.WriteLine("Enter the location of your http/s proxies to avoid ip ban.");

            //string proxylocation = Console.ReadLine();









            Console.WriteLine("Proxy (HTTP/S):");
            location = Console.ReadLine();




            Console.WriteLine("Type 1 to continue.");

            startchecker = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            while (startchecker == 1)
            {
                gencker();
            }
        }
    }
}
