using Task3;

namespace Task3Test
{
    [TestClass]
    public class CalculateSquareTests
    {
        [TestMethod]
        public void TestValidData1()
        {
            //arrange
            var sc = new SquareCalculator();
            int expectedSquare = 10;
            int width = 2;
            int length = 5;

            //act&assert
            Assert.AreEqual(expectedSquare, sc.CalculateSquare(width, length));
        }

        [TestMethod]
        public void TestValidData2()
        {
            //arrange
            var sc = new SquareCalculator();
            double expectedSquare = 13.75;
            double width = 2.5;
            double length = 5.5;

            //act&assert
            Assert.AreEqual(expectedSquare, sc.CalculateSquare(width, length));
        }

        [TestMethod]
        public void TestNegativeNumbers()
        {
            //arrange
            var sc = new SquareCalculator();

            //act&assert
            Assert.ThrowsException<ArgumentException>(() => { sc.CalculateSquare(-1, 2); }, ExceptionMessages.invalidWidth);
            Assert.ThrowsException<ArgumentException>(() => { sc.CalculateSquare(1, -2); }, ExceptionMessages.invalidLength);
        }


        [TestMethod]
        public void TestZeroNumbers()
        {
            //arrange
            var sc = new SquareCalculator();

            //act&assert
            Assert.ThrowsException<ArgumentException>(() => { sc.CalculateSquare(0, 2); }, ExceptionMessages.invalidWidth);
            Assert.ThrowsException<ArgumentException>(() => { sc.CalculateSquare(1, 0); }, ExceptionMessages.invalidLength);
        }
        
        [TestMethod]
        public void TestInfinityProduct()
        {
            //arrange
            var sc = new SquareCalculator();

            //act&assert
            Assert.ThrowsException<OverflowException>(() => { sc.CalculateSquare(double.MaxValue, 2); }, ExceptionMessages.overflow);
            Assert.ThrowsException<OverflowException>(() => { sc.CalculateSquare(2, double.MaxValue); }, ExceptionMessages.overflow);
        }
                
        [TestMethod]
        public void TestPreceisionLoss()
        {
            //arrange
            var sc = new SquareCalculator();

            //act&assert
            Assert.ThrowsException<Exception>(() => { sc.CalculateSquare(1E-17, 1E-1); }, ExceptionMessages.preceisionLoss);
            Assert.ThrowsException<Exception>(() => { sc.CalculateSquare(1E-1, 1E-17); }, ExceptionMessages.preceisionLoss);
        }

    }
}