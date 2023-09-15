using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Greeter
    {
        public void Greet()
        {
            // creating randomizer
            var rand = new Random();
            // getting count of exclamation marks
            int exclamationCout = rand.Next(5, 50);
            var str = new StringBuilder();
            Console.WriteLine($"Hello, world!{Environment.NewLine}Andhiagain!{Environment.NewLine}{str.Append('!', exclamationCout)}");
        }
    }
}
