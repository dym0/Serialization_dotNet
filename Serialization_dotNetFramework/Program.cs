using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization_dotNetFramework
{
    class Program
    {

        public static void Menu()
        {
            Console.WriteLine("Commands:\n\r add [ammount] [wallets owner name]\n subtract [ammount] [wallets owner name] \n wallets \n Owners: Adrian, Daniel, Konrad  \n\r ");
        }

        public static void IncorrectCmd()
        {
            Console.WriteLine("Incorect command please, input again.");
        }
            

        static void Main(string[] args)
        {
            string cmd;
            string[] splited;
            string path = @"D:\rodzinkaSerializacja.dat";

            List<Guy> Guys = new List<Guy>();
            Serialization serializer = new Serialization(path); 

            string[] commands = { "add", "subtract", "wallets", "exit" };

            Guy Konrad = new Guy("konrad", 1000);
            Guy Daniel = new Guy("daniel", 1000);
            Guy Adrian = new Guy("adrian", 1000);

            Guys.Add(Konrad);
            Guys.Add(Daniel);
            Guys.Add(Adrian);

            if(File.Exists(path))
            {
                Guys = serializer.DeserializeAll();
            }
           

            Menu();

           

            do
            {


                cmd = Console.ReadLine();
                cmd = cmd.ToLower();



                splited = cmd.Split();



                switch (splited[0])
                {

                    case "add":
                        {

                            foreach (Guy guy in Guys)
                            {
                                if (splited[2] == guy.Name)
                                {
                                    guy.AddMoney(Convert.ToDecimal(splited[1]));
                                }
                               
                            }

                            break;
                        }

                    case "subtract":
                        {

                            foreach (Guy guy in Guys)
                            {
                                if (splited[2] == guy.Name)
                                {
                                    guy.Subtract(Convert.ToDecimal(splited[1]));
                                }
                            }

                            break;
                        }

                    case "wallets":
                        {

                            foreach (Guy guy in Guys)
                            {
                                Console.WriteLine(guy.Name + ": " + guy.Wallet + " \n");
                            }

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Incorect command please, input again.");
                            Menu();
                        }
                        break;


                }






            } while (cmd != "exit");

            serializer.Serialize(Guys);

            

         


        }
    }
    
}
