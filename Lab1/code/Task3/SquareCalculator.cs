using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class SquareCalculator
    {

        public double CalculateSquare(double width, double length)
        {
            // checking for the valid width and length
            if (width <= 0)
                throw new ArgumentException(ExceptionMessages.invalidWidth);

            if (length <= 0)
                throw new ArgumentException(ExceptionMessages.invalidLength);

            double answ = width * length;

            if (answ < 1E-17)
                throw new Exception(ExceptionMessages.preceisionLoss);

            // tracking overflow
            if (double.IsInfinity(answ))
                throw new OverflowException(ExceptionMessages.overflow);

            // tracking underflow
            if (double.IsNaN(answ))
                throw new OverflowException(ExceptionMessages.underflow);

            return answ;
        }

    }
}
