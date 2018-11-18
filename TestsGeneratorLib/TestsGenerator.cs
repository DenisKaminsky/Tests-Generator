using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TestsGeneratorLib
{
    public class TestsGenerator
    {
        private TestsGeneratorConfig _config;

        public TestsGenerator(TestsGeneratorConfig config)
        {
            _config = config;
        }

        public Task Generate()
        {
            DataflowLinkOptions linkOptions = new DataflowLinkOptions { PropagateCompletion = true };//цель получает уведомление о завершении/сбое
            ExecutionDataflowBlockOptions readBlockOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _config._maxReadTasksCount
            };
            ExecutionDataflowBlockOptions processingBlockOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _config._maxProcessingTasksCount
            };
            ExecutionDataflowBlockOptions writeOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _config._maxWriteTasksCount
            };



        }

    }
}
