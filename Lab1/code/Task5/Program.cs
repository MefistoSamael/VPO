using Task5;

ExtensionChecker extensionChecker = new ExtensionChecker();
var a = extensionChecker.FindFileWithExtesion($"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName}\\cascading_folder", "txt");
Console.WriteLine(" ");
