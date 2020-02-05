using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Files();
            GetFilesLambda();
        }

        private static void Files()
        {
            var files = new DirectoryInfo("c:\\Windows").GetFiles();

            var query = from item in files
                        where item.Length > 10000
                        orderby item.Length, item.Name
                        select new MyFileInfo
                        {
                            Name = item.Name,
                            Length = item.Length,
                            CreationTime = item.CreationTime

                        };

            Console.WriteLine("FileName\tSize\t\tCreation Date");

            foreach (MyFileInfo item in query)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        public class MyFileInfo
        {
            public string Name { get; set; }
            public long Length { get; set; }
            public DateTime CreationTime { get; set; }

            public override string ToString()
            {
                return string.Format("{0,-30},{1:F0} MB\t{2}", Name, Length / 1000, CreationTime);
            }

        }

        private static void GetFilesLambda()
        {
            var files = new DirectoryInfo("c:\\Windows").GetFiles();

            var query = files
                .Where(f => f.Length > 10000)
                .OrderBy(f => f.Length).ThenBy(f => f.Name)
                .Select(f => new MyFileInfo
                {
                    Name = f.Name,
                    Length = f.Length,
                    CreationTime = f.CreationTime
                });

            Console.WriteLine("FileName\tSize\t\tCreation Date");
            foreach (MyFileInfo item in query)
            {
                Console.WriteLine(item.ToString());
            }


            Console.ReadLine();
        }
    }
}

