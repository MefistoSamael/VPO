namespace Task4Test
{
    [TestClass]
    public class CreateHtmlGradientTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (StreamReader sr = new StreamReader(Task4.MyPath.path))
            {
                var str = sr.ReadToEnd().Split('\n', StringSplitOptions.RemoveEmptyEntries);

                Assert.AreEqual("<!DOCTYPE html>", str[0]);
                Assert.AreEqual("<html>", str[1]);
                Assert.AreEqual("<head>", str[2]);
                Assert.AreEqual("<title>Градиентная таблица</title>", str[3]);
                Assert.AreEqual("</head>", str[4]);
                Assert.AreEqual("<body>", str[5]);
                Assert.AreEqual("<table>", str[6]);

                int rowCount = 255; // Row count in table
                double step = 255.0 / rowCount; // Evaluating step for changing the color

                for (int i = 0; i < rowCount; i++)
                {
                    int red = (int)(255 - i * step);
                    int green = (int)(255 - i * step);
                    int blue = (int)(255 - i * step);

                    string bgColor = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);

                    // Creating table with certaing background color
                    Assert.AreEqual("<tr style='background-color:" + bgColor + "'>", str[i*3+7]);
                    Assert.AreEqual("<td width=\"1000\"> </td>", str[i * 3 + 8]);
                    Assert.AreEqual("</tr>", str[i * 3 + 9]);
                }

                // Closing all html tags
                Assert.AreEqual("</table>", str[rowCount * 3 + 7]);
                Assert.AreEqual("</body>", str[rowCount * 3 + 8]);
                Assert.AreEqual("</html>", str[rowCount * 3 + 9]);
            }
        }
    }
}