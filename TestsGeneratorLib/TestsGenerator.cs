using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TestsGeneratorLib.DataStructures;

namespace TestsGeneratorLib
{
    public class TestsGenerator
    {
        private TestsGeneratorConfig _config;

        public TestsGenerator(TestsGeneratorConfig config)
        {
            _config = config;
        }

        public Task Generate(List<string> pathes,string destination)
        {
            DataflowLinkOptions linkOptions = new DataflowLinkOptions { PropagateCompletion = true };//цель получает уведомление о завершении/сбое
            ExecutionDataflowBlockOptions readBlockOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _config._maxReadTasksCount
            };
            ExecutionDataflowBlockOptions processBlockOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _config._maxProcessingTasksCount
            };
            ExecutionDataflowBlockOptions writeBlockOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _config._maxWriteTasksCount
            };

            TransformBlock<string, string> readBlock = new TransformBlock<string, string>(new Func<string, Task<string>>(AsyncReader.Read), readBlockOptions);
            TransformBlock<string, List<GeneratedTest>> processBlock = new TransformBlock<string, List<GeneratedTest>>(new Func<string, List<GeneratedTest>>(GenerateTestClasses), processBlockOptions);
            ActionBlock<List<GeneratedTest>> writeBlock = new ActionBlock<List<GeneratedTest>>(((generatedClasses) => AsyncWriter.Write(destination, generatedClasses).Wait()), writeBlockOptions);

            readBlock.LinkTo(processBlock, linkOptions);
            processBlock.LinkTo(writeBlock, linkOptions);

            foreach (string path in pathes)
            {
                readBlock.SendAsync(path);
            }
            readBlock.Complete();

            return writeBlock.Completion;
        }

        private List<GeneratedTest> GenerateTestClasses(string sourceCode)
        {
            ParsingResultBuilder builder = new ParsingResultBuilder();
            ParsingResultStructure result = builder.GetResult(sourceCode);
            //here we can genearte test class with result
            TestTemplateGenerator generator = new TestTemplateGenerator();
            List<GeneratedTest> generatedTests = generator.GetTestTemplates(result);

            return generatedTests;
        }

    }
}
