using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Threading;

namespace rptDaily
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Root();
        }
        static void Root()
        {
            Console.WriteLine("- - Please select your OS-type - -"); Console.WriteLine("");Console.WriteLine("1: Secure persistence");Console.WriteLine("2: Persistance");Console.WriteLine("3: Live session");Console.WriteLine("");

            int selection=0;
            try
            {
                selection = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Root();
            }

            switch (selection)
            {
                case 1:
                    KaliLinuxInstance kalizero = new KaliLinuxInstance("Kali", "Kali");
                    kalizero.BootEventHandler += ActualBoot;
                    Console.WriteLine("**Secure persistence**");
                    Console.WriteLine("");
                    Console.Write("Username: ");
                    string Username = Console.ReadLine();
                    Console.Write("Password: ");
                    string Password = Console.ReadLine();
                    Console.WriteLine(kalizero.Login(Username, Password));
                    break;
                case 2:

                    KaliLinuxInstance kalione = new KaliLinuxInstance("Persistence");
                    kalione.BootEventHandler += ActualBoot;
                    Console.WriteLine(kalione.Login());
                    break;
                case 3:
                    KaliLinuxInstance kalitwo = new KaliLinuxInstance("LiveSession");
                    kalitwo.BootEventHandler += ActualBoot;
                    Console.WriteLine(kalitwo.Login());
                    break;
                default:
                    Console.WriteLine("No valid input - press any key to try again");
                    Console.ReadKey();
                    Root();
                    break; 


            }
        }
        
        static string ActualBoot(object sender, string OStype)
        {
            OSs oSs = new OSs(OStype);
            if (OStype == "SecurePersistence")
            {
                oSs.SecurePersistance();
                return "started secure persistance";
            }
            else if(OStype == "Persistence")
            {
                oSs.Persistance();
                return "started persistance";

            }
            else if (OStype == "LiveSession")
            {
                oSs.LiveSession();
                return "started live session";
            }
            else
            {
                Console.WriteLine("error: no proper OS selected: {0}", OStype);
                Root();
                return "error";
            }
        }

        

        public delegate string BootEventHandler(object sender, string OStype);

        class OSs //just makes it look cool
        {
            private string OStype { get; set; }
            public OSs(string ostype) 
            { 
                OStype = ostype;
            }
            async public void SecurePersistance() 
            {
                Console.Clear();
                Console.WriteLine("Booting secure persistence mode...");
                Console.WriteLine("");
                string left = "----------";
                string finish = "";
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("["+finish+left+"]");
                    left = left.Substring(1);
                    finish += "#";
                    Thread.Sleep(100);
                }

                Console.Clear();
                Console.WriteLine("Initialising secure persistence mode");
                Console.WriteLine("");
                left = "----------";
                finish = "";
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("[" + finish + left + "]");
                    left = left.Substring(1);
                    finish += "#";
                    Thread.Sleep(100);
                }
                left = "----------";
                finish = "";
                Console.Clear();

                Console.WriteLine("Starting secure persistence mode");
                Console.WriteLine("");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("[" + finish + left + "]");
                    left = left.Substring(1);
                    finish += "#";
                    Thread.Sleep(100);
                }
            }
            async public void Persistance()
            {
                Console.Clear();
                Console.WriteLine("Booting persistence mode...");
                Console.WriteLine("");
                string left = "----------";
                string finish = "";
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("[" + finish + left + "]");
                    left = left.Substring(1);
                    finish += "#";
                    Thread.Sleep(100);
                }

                Console.Clear();
                Console.WriteLine("Initialising persistence mode");
                Console.WriteLine("");
                left = "----------";
                finish = "";
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("[" + finish + left + "]");
                    left = left.Substring(1);
                    finish += "#";
                    Thread.Sleep(100);
                }
                left = "----------";
                finish = "";
                Console.Clear();

                Console.WriteLine("Starting persistence mode");
                Console.WriteLine("");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("[" + finish + left + "]");
                    left = left.Substring(1);
                    finish += "#";
                    Thread.Sleep(100);
                }

            }
            async public void LiveSession()
            {
                Console.Clear();
                Console.WriteLine("Booting Live Session...");
                Console.WriteLine("");
                string left = "----------";
                string finish = "";
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("[" + finish + left + "]");
                    left = left.Substring(1);
                    finish += "#";
                    Thread.Sleep(100);
                }
                Console.Clear();

                left = "----------";
                finish = "";
                Console.Clear();
                Console.WriteLine("Initialising Live Session");
                Console.WriteLine("");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("[" + finish + left + "]");
                    left = left.Substring(1);
                    finish += "#";
                    Thread.Sleep(100);
                }
                Console.Clear();
                left = "----------";
                finish = "";
                Console.WriteLine("Starting Live Session");
                Console.WriteLine("");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("[" + finish + left + "]");
                    left = left.Substring(1);
                    finish += "#";
                    Thread.Sleep(100);
                }
            }
        }

        public class KaliLinuxInstance
        {
            private string Username { get; set; }
            private string Password { get; set; }

            private string OStype { get; set; }
            public KaliLinuxInstance(string username, string password)
            {
                Username = username;
                Password = password;
                OStype = "SecurePersistence";

            }
            public KaliLinuxInstance(string ostype)
            {
                OStype = ostype;
            }
            public event BootEventHandler BootEventHandler;

            public string Login()
            {
                if (BootEventHandler != null)
                {
                    BootEventHandler(this, OStype);
                }
                return "";
            }
            public string Login(string username, string password)
            {
                if (username==Username && password==Password)
                {
                    if (BootEventHandler!=null)
                    {
                        BootEventHandler(this, OStype);
                    }
                    return "";
                }
                else
                {
                    Console.WriteLine("Login attempt failed - press any key to try again");
                    Console.ReadKey();
                    Console.Clear (); 
                    Root();
                    return "";
                }
            }
        }

    }
}
