namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SquareCalculator sc = new SquareCalculator();
            Console.WriteLine(sc.CalculateSquare(Convert.ToDouble(args[0]), Convert.ToDouble(args[1]))); 
        }
    }
}