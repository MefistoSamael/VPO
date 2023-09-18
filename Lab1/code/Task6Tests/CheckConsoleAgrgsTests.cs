using Task6;

namespace Task6Tests
{
    [TestClass]
    public class CheckConsoleAgrgsTests
    {

        [TestMethod]
        public void IncorrectArgsTest()
        {
            //arrange
            var ud = new UrlDownLoader();

            //act&assert
            Assert.ThrowsException<ArgumentException>(() => { ud.CheckConsoleAgrgs(new string[] { "a", "b", "c" }); }, ExceptionMessages.incorrectConsoleArguments);
        }


        [TestMethod]
        public void CorrectArgsTest()
        {
            //arrange
            var ud = new UrlDownLoader();
            var expexted = (new string[] { "a", "b" });

            //act
            var real = ud.CheckConsoleAgrgs(new string[] { "a", "b" });
            
            //assert
            Assert.AreEqual(expexted[0],real[0]);
            Assert.AreEqual(expexted[1],real[1]);
        }


    }
}