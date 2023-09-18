using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class MyPath
    {
        public static string path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName}";
    }
}
