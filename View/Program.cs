using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsGeneratorLib;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {            
            int readingLimit = 3;
            int writingLimit = 3;
            int processingLimit = 8;
            string path = @"D:\files\BaseGenerator.cs";
            TestsGeneratorConfig config = new TestsGeneratorConfig(readingLimit, processingLimit, writingLimit);
            TestsGenerator generator = new TestsGenerator(config);

            generator.Generate(path).Wait();
            Console.WriteLine("Complete");
        }
    }
}
