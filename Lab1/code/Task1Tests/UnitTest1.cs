using Task1;

namespace Task1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var g = new Greeter();
            //setting up StringWriter to capture the
            // output from console
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            g.Greet();

            //assert
            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var exclamationCount = 0;
            // counting number of exclamation marks
            foreach ( var sign in outputLines[2])
                if ( sign == '!')
                    exclamationCount++;

            //checking if message is correct
            Assert.AreEqual("Hello, world!", outputLines[0]);
            Assert.AreEqual("Andhiagain!", outputLines[1]);
            Assert.IsTrue( exclamationCount >= 5 && exclamationCount <= 50);
            


        }
    }
}