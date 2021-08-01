using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();

            while(true)
            {
                var key = Console.ReadKey(true);
                calc.SendKeystroke(key.KeyChar);
                Console.Clear();
                Console.Write(calc.DisplayText);
            }
        }
    }
}
