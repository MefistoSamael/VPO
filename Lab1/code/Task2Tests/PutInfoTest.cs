using System.Text;
using Task2;

namespace Task2Tests
{
    [TestClass]
    public class PutInfoTest
    {
        [TestMethod]
        public void TestValidData()
        {
            //arrange
            var stat = new Statistic();
            List<int> list = new List<int>();
            StringBuilder sb = new StringBuilder();
            //setting up StringWriter to capture the
            // output from console
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            string expectedStr = $"a a 1{Environment.NewLine}a a 2{Environment.NewLine}a a 4{Environment.NewLine}";

            //act
            stat.PutInfo("a", "a", 1, sb, list);
            stat.PutInfo("a", "a", 2, sb, list);
            stat.PutInfo("a", "a", 4, sb, list);

            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            //assert
            Assert.AreEqual(expectedStr, sb.ToString());
        }

        //
        [TestMethod]
        public void TestEmptyData() 
        {
            //arrange
            var stat = new Statistic();
            List<int> list = new List<int>();
            StringBuilder sb = new StringBuilder();
            //setting up StringWriter to capture the
            // output from console
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act & assert
            Assert.ThrowsException<InvalidDataException>(() => { stat.PutInfo("", "a", 1, sb, list); }, ExceptionMessages.noData);
            Assert.ThrowsException<InvalidDataException>(() => { stat.PutInfo("a", "", 1, sb, list); }, ExceptionMessages.noData);
        }

        [TestMethod]
        public void TestNullPutInfo() 
        {
            //arrange
            var stat = new Statistic();
            List<int> list = new List<int>();
            StringBuilder sb = new StringBuilder();
            //setting up StringWriter to capture the
            // output from console
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act & assert
            Assert.ThrowsException<ArgumentNullException>(() => { stat.PutInfo(null, "a", 1, sb, list); });
            Assert.ThrowsException<ArgumentNullException>(() => { stat.PutInfo("a", null, 1, sb, list); });
            Assert.ThrowsException<ArgumentNullException>(() => { stat.PutInfo("a", "a", 1, null, list); });
            Assert.ThrowsException<ArgumentNullException>(() => { stat.PutInfo("a", "a", 1, sb, null); });


        }

        [TestMethod]
        public void TestZeroAge() 
        {
            //arrange
            var stat = new Statistic();
            List<int> list = new List<int>();
            StringBuilder sb = new StringBuilder();
            //setting up StringWriter to capture the
            // output from console
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            Assert.ThrowsException<InvalidDataException>(() => { stat.PutInfo("a", "a", 0, sb, list); }, ExceptionMessages.invalidAge);
            //assert
        }
        
        [TestMethod]
        public void TestInvalidAge() 
        {
            //arrange
            var stat = new Statistic();
            List<int> list = new List<int>();
            StringBuilder sb = new StringBuilder();
            //setting up StringWriter to capture the
            // output from console
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act & assert
            Assert.ThrowsException<InvalidDataException>(() => { stat.PutInfo("a", "a", 138, sb, list); }, ExceptionMessages.invalidAge);
        }
    }
}