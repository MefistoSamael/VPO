using Task4;
using Task5;

namespace Task5Tests
{
    [TestClass]
    public class FindFileWithExtesionTests
    {
        [TestMethod]
        public void NullCheckTest()
        {
            ExtensionChecker ec = new ExtensionChecker();

            Assert.ThrowsException<ArgumentNullException>(() => { ec.FindFileWithExtesion(null, "txt"); }, ExceptionMessages.folderNull);
            Assert.ThrowsException<ArgumentNullException>(() => { ec.FindFileWithExtesion("c:", null); }, ExceptionMessages.extensionNull);
        }

        [TestMethod]
        public void IncorrectFolderPathTest()
        {
            ExtensionChecker ec = new ExtensionChecker();

            Assert.ThrowsException<IOException>(() => { ec.FindFileWithExtesion($"{MyPath.path}\\incorrect_folder.txt", "txt");});
        }


        [TestMethod]
        public void NotExisitingFolderTest()
        {
            ExtensionChecker ec = new ExtensionChecker();

            Assert.ThrowsException<DirectoryNotFoundException>(() => { ec.FindFileWithExtesion($"{MyPath.path}\\incorrect_folder", "txt");});
        }


        [TestMethod]
        public void NoFilesTest1()
        {
            ExtensionChecker ec = new ExtensionChecker();

            Assert.AreEqual(0, ec.FindFileWithExtesion($"{MyPath.path}\\empty_folder", "txt").Length);
        }


        [TestMethod]
        public void NoFilesTest2()
        {
            ExtensionChecker ec = new ExtensionChecker();

            Assert.AreEqual(0, ec.FindFileWithExtesion($"{MyPath.path}\\full_png_folder", "txt").Length);
        }
        
        [TestMethod]
        public void CascadingFolderTest()
        {
            ExtensionChecker ec = new ExtensionChecker();
            string[] expected = { $"{MyPath.path}\\cascading_folder\\another\\and_another\\1.txt", $"{MyPath.path}\\cascading_folder\\another\\one\\heheheha.txt", $"{MyPath.path}\\cascading_folder\\another\\and_another\\and_another\\2.txt" };
            var amsw = ec.FindFileWithExtesion($"{MyPath.path}\\cascading_folder", "txt");

            Assert.AreEqual(expected[0], amsw[0]);            
            Assert.AreEqual(expected[1], amsw[1]);            
            Assert.AreEqual(expected[2], amsw[2]);            
        }


    }
}