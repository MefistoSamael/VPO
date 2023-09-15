using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class SquareCalculator
    {
        private const string invalidWidthExceptionMessage = "error: invalid width";
        private const string invalidLengthExceptionMessage = "error: invalid length";
        private const string overflowExceptionMessage = "Ahhh, senpai, it's too big";
        private const string underflowExceptionMessage = "senpai, it's too small";
        public double Task3()
        {
            Console.WriteLine("Enter length");
            var length = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter width");
            var width = Convert.ToDouble(Console.ReadLine());

            return CalculateSquare(length, width);
        }

        public double CalculateSquare(double width, double length)
        {
            // checking for the valid width and length
            if (width < 0)
                throw new InvalidDataException(invalidWidthExceptionMessage);

            if (length < 0)
                throw new InvalidDataException(invalidLengthExceptionMessage);

            double answ = width * length;

            // tracking overflow
            if (double.IsInfinity(answ))
                throw new OverflowException(overflowExceptionMessage);

            if (double.IsNaN(answ))
                throw new OverflowException(underflowExceptionMessage);

            return answ;
        }

    }
}
