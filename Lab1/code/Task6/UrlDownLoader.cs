using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task6
{
    public class UrlDownLoader
    {
        public readonly List<string> Extensions = new List<string>() { "pdf", "rar" };
        public string GetFileByUrlConsoleAgrgs(string[] args)
        {
            var checkedArgs = CheckConsoleAgrgs(args);
            return GetFileByUrl(checkedArgs[0], checkedArgs[1]);
        }
        public string[] CheckConsoleAgrgs(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException(ExceptionMessages.incorrectConsoleArguments);

            return args;
        }

        public string GetFileByUrl(string path, string url)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            string ext;
            // regex for getting extension of the file
            // so we now how to save file
            Regex regex = new Regex(@"\.([a-z]*)/?$");
            if (regex.IsMatch(url))
            {
                ext = regex.Match(url).Groups[1].Value;
                if (!Extensions.Contains(ext))
                    ext = "html";
            }
            else
            {
                ext = "html";
            }

            // updating path so we can save our file
            path = Path.Combine(path, Path.GetRandomFileName());
            path = Path.ChangeExtension(path, ext);


            Uri uri = new Uri(url);

            using HttpClient client = new HttpClient();
            // gettig response with our file
            var response = client.GetStreamAsync(uri).Result;

            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            // saving file to disk
            response.CopyTo(fs);

            return path;
        }

    }
}
