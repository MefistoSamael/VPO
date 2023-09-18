using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6;

namespace Task6Tests
{
    [TestClass]
    public class GetFileByUrlConsoleAgrgsTests
    {

        [TestMethod]
        public void TestIncorrectArgs()
        {
            var ud = new UrlDownLoader();
            var incorrectData = new string[] { "1", "2", "3" };
            Assert.ThrowsException<ArgumentException>(() => { ud.GetFileByUrlConsoleAgrgs(incorrectData); }, ExceptionMessages.incorrectConsoleArguments);
        }


        [TestMethod]
        public void TestIncorrectUrl()
        {
            var ud = new UrlDownLoader();
            var incorrectData = new string[] { "1", "https://av.bu", };
            Assert.ThrowsException<AggregateException>(() => { ud.GetFileByUrlConsoleAgrgs(incorrectData); });
        }


        [TestMethod]
        public void TestIncorrectUrl2()
        {
            var ud = new UrlDownLoader();
            var incorrectData = new string[] { "1", "2", };
            Assert.ThrowsException<UriFormatException>(() => { ud.GetFileByUrlConsoleAgrgs(incorrectData); });
        }


        [TestMethod]
        public void TestIncorrectDirectory()
        {
            var ud = new UrlDownLoader();
            var incorrectData = new string[] { "1", "http://www.contoso.com/" };
            Assert.ThrowsException<DirectoryNotFoundException>(() => { ud.GetFileByUrlConsoleAgrgs(incorrectData); });
        }


        [TestMethod]
        public void TestCorrectData()
        {
            var ud = new UrlDownLoader();
            var correctData = new string[] { Environment.CurrentDirectory, "http://www.contoso.com/" };
            Assert.IsTrue(File.Exists(ud.GetFileByUrlConsoleAgrgs(correctData)));
        }

    }
}
