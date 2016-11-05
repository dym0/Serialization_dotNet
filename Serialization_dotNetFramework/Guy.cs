using System;
using System.Xml.Serialization;

namespace Serialization_dotNetFramework
{
    [Serializable]
    public class Guy
    {
        public decimal Wallet { get; set; }

        public string Name { get; set; }

        public Guy(string name, decimal wallet)
        {
            Name = name;
            Wallet = wallet;
        }


        public void AddMoney(decimal amount)
        {
            Wallet += amount;

            Console.WriteLine(amount + " Added to this wallet.");
        }

        public void Subtract(decimal amount)
        {
            Wallet -= amount;
        }
    }
}