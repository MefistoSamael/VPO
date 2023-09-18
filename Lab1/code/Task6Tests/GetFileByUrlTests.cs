using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6;

namespace Task6Tests
{
    [TestClass]
    public class GetFileByUrlTests
    {

        [TestMethod]
        public void TestNullArguments()
        {
            var ud = new UrlDownLoader();

            Assert.ThrowsException<ArgumentNullException>(() => { ud.GetFileByUrl(null, "1"); });
            Assert.ThrowsException<ArgumentNullException>(() => { ud.GetFileByUrl("1", null); });
        }
        

        [TestMethod]
        public void TestIncorrectUrl()
        {
            var ud = new UrlDownLoader();

            Assert.ThrowsException<UriFormatException>(() => { ud.GetFileByUrl("a", "1"); });
        }
        

        [TestMethod]
        public void TestIncorrectUrl2()
        {
            var ud = new UrlDownLoader();

            Assert.ThrowsException<AggregateException>(() => { ud.GetFileByUrl("1", "https://av.bu"); });
        }
        

        [TestMethod]
        public void TestIncorrectDirectory()
        {
            var ud = new UrlDownLoader();

            Assert.ThrowsException<DirectoryNotFoundException>(() => { ud.GetFileByUrl("1", "http://www.contoso.com/"); });
        }


        [TestMethod]
        public void TestCorrectData()
        {
            var ud = new UrlDownLoader();

            Assert.IsTrue(File.Exists(ud.GetFileByUrl(Environment.CurrentDirectory, "https://av.by")));
        }

        
        
    }
}
