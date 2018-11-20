﻿using System;
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
            List<string> pathes = new List<string>();

            pathes.Add(@"D:\files\BaseGenerator.cs");
            pathes.Add(@"D:\files\TestsGenerator.cs");

            TestsGeneratorConfig config = new TestsGeneratorConfig(readingLimit, processingLimit, writingLimit);
            TestsGenerator generator = new TestsGenerator(config);

            generator.Generate(pathes).Wait();
            Console.WriteLine("Complete");
        }
    }
}
