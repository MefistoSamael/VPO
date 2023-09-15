using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task2Tests
{
    [TestClass]
    public class GetStatsTest
    {
        [TestMethod]
        public void TestNullGetStats()
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
            Assert.ThrowsException<ArgumentNullException>(() => { stat.GetStats(null, list); });
            Assert.ThrowsException<ArgumentNullException>(() => { stat.GetStats(sb, null); });
        }

        [TestMethod]
        public void TestEmptyList()
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
            Assert.ThrowsException<ArgumentException>(() => { stat.GetStats(sb, list); }, ExceptionMessages.emptyList);

        }

        [TestMethod]
        public void TestOneElementList()
        {
            //arrange
            var stat = new Statistic();
            List<int> list = new List<int>();
            StringBuilder sb = new StringBuilder();
            int expectedMin = 1;
            int expectedMax = 1;
            double expectedMid = 1;


            sb.Append("a");
            sb.Append(" "); 
            sb.Append("a");
            sb.Append(" ");
            sb.Append(1); 
            sb.Append(Environment.NewLine);
            list.Add(1);
            //setting up StringWriter to capture the
            // output from console
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act & assert
            stat.GetStats(sb, list);

            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            //assert
            Assert.AreEqual("a a 1", outputLines[0]);
            Assert.AreEqual($"minimum age: {expectedMin}", outputLines[1]);
            Assert.AreEqual($"middle age: {expectedMid}", outputLines[2]);
            Assert.AreEqual($"maximum age: {expectedMax}", outputLines[3]);
        }

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
            int expectedMin = 1;
            int expectedMax = 4;
            double expectedMid = 2.33;

            sb.Append("a");
            sb.Append(" ");
            sb.Append("a");
            sb.Append(" ");
            sb.Append(1);
            sb.Append(Environment.NewLine);

            sb.Append("a");
            sb.Append(" ");
            sb.Append("a");
            sb.Append(" ");
            sb.Append(2);
            sb.Append(Environment.NewLine);

            sb.Append("a");
            sb.Append(" ");
            sb.Append("a");
            sb.Append(" ");
            sb.Append(4);
            sb.Append(Environment.NewLine);

            list.Add(1);
            list.Add(2);
            list.Add(4);
            stat.GetStats(sb, list);

            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            //assert
            Assert.AreEqual("a a 1", outputLines[0]);
            Assert.AreEqual("a a 2", outputLines[1]);
            Assert.AreEqual("a a 4", outputLines[2]);
            Assert.AreEqual($"minimum age: {expectedMin}", outputLines[3]);
            Assert.AreEqual($"middle age: {expectedMid}", outputLines[4]);
            Assert.AreEqual($"maximum age: {expectedMax}", outputLines[5]);

        }

    }

}
