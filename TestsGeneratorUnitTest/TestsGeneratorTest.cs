using System.IO;
using System.Collections.Generic;
using TestsGeneratorLib;
using TestsGeneratorLib.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsGeneratorUnitTest
{
    [TestClass]
    public class TestsGeneratorTest
    {
        private ParsingResultStructure _result;

        [TestInitialize]
        public void SetUp()
        {
            int readingLimit = 3, writingLimit = 3, processingLimit = 8;
            string sourceCode;            
            List<string> pathes = new List<string>();
            ParsingResultBuilder builder;
            TestsGeneratorConfig config;
            TestsGenerator generator;

            pathes.Add(@"D:\files\TestsGenerator.cs");
            config = new TestsGeneratorConfig(readingLimit, processingLimit, writingLimit);
            generator = new TestsGenerator(config);
            generator.Generate(pathes,"D:\\files\\Tests").Wait();

            sourceCode = File.ReadAllText("D:\\files\\Tests\\TestsGeneratorTest");
            builder = new ParsingResultBuilder();
            _result = builder.GetResult(sourceCode);
        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
