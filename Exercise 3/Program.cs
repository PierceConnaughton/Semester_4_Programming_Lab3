using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        private static void GetFiles()
        {
            var files = new DirectoryInfo("c:\\Windows").GetFiles();

            var query from item in files
                      where item.Length > 10000
        }

        private static void GetFilesLambda()
        {
            var files = new DirectoryInfo("c:\\Windows").GetFiles();

            var query = files
                .Where(f => f.Length > 10000)
                .OrderBy(f -> f.Length)
        }
    }
}
