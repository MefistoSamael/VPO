using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Statistic
    {

        public void Task()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var list = new List<int>();
            while (true) 
            {
                Console.Write("Enter First name: ");
                var firstName = Console.ReadLine();
                Console.Write("Enter Last name: ");
                var lastName = Console.ReadLine();
                Console.Write("Enter age: ");
                // if age has not only digits then
                // convert will throw exception
                // by its own
                int age;
                try
                {
                    age = Convert.ToInt32(Console.ReadLine());
                }
                catch(System.FormatException)
                {
                    throw new InvalidDataException(ExceptionMessages.invalidAge);
                }
                catch
                {
                    throw;
                }


                PutInfo(firstName!, lastName!, age, stringBuilder, list);


                // checking if user want to exit
                Console.Write("To finish the input press q and the enter");
                var isEnd = Console.ReadLine();

                if (isEnd == "q")
                    break;
            }

            GetStats(stringBuilder, list);
        }

        public void PutInfo(string firstName, string lastName, int age, StringBuilder stringBuilder, List<int> list)
        {
            // if no data where provided - throw exception with
            // aproptiate message
            if (firstName == "" || lastName == "")
                throw new InvalidDataException(ExceptionMessages.noData);

            if (firstName == null || lastName == null || stringBuilder == null || list == null)
                throw new ArgumentNullException();

            // if first name has something else than letter
            // throw aproptiate exception
            if (!ValidString(firstName!))
                throw new InvalidDataException(ExceptionMessages.firstName);

            // if last name has something else than letter
            // throw aproptiate exception
            if (!ValidString(lastName!))
                throw new InvalidDataException(ExceptionMessages.lastName);


            if (age <= 0 || age > 137)
                throw new InvalidDataException(ExceptionMessages.invalidAge);


            // creating valid output string
            stringBuilder.Append(firstName);
            stringBuilder.Append(" ");
            stringBuilder.Append(lastName);
            stringBuilder.Append(" ");
            stringBuilder.Append(age);
            stringBuilder.Append(Environment.NewLine);

            //list of ages, to write minimum, maximum and middle age
            list.Add(age);
        }

        // outputs fata in correct format
        public void GetStats(StringBuilder stringBuilder, List<int> list)
        {
            if (stringBuilder == null || list == null)
                throw new ArgumentNullException();

            if (list.Count == 0)
                throw new ArgumentException(ExceptionMessages.emptyList );
            list.Sort();
            Console.Write(stringBuilder);
            Console.WriteLine($"minimum age: {list[0]}");
            Console.WriteLine($"middle age: {CountMiddleAge(list)}");
            Console.WriteLine($"maximum age: {list[list.Count - 1]}");
        }
        private bool ValidString(string str)
        {
            // checking if the sybol is letter
            foreach (var symbol in str)
                if (!((symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z')))
                    return false;
            return true;
        }

        public double CountMiddleAge(List<int> list)
        {
            double middle = 0;

            foreach(var item in list)
                middle += item;

            return Math.Round(middle/list.Count, 2);
        }
    }
}
