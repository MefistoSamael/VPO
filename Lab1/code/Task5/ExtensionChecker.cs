using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class ExtensionChecker
    {
        public string[] FindFileWithExtesion(string folder, string extension)
        {
            if (String.IsNullOrEmpty(extension))
                throw new ArgumentNullException(ExceptionMessages.extensionNull);
            
            if (String.IsNullOrEmpty(folder))
                throw new ArgumentNullException(ExceptionMessages.folderNull);

            return Directory.GetFiles(folder, $"*.{extension}", SearchOption.AllDirectories);
        }
    }
}
