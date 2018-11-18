namespace TestsGeneratorLib
{
    public class TestsGeneratorConfig
    {
        public int _maxReadTasksCount { get; }
        public int _maxProcessingTasksCount { get; }
        public int _maxWriteTasksCount { get; }

        public TestsGeneratorConfig(int maxReadTasksCount,int maxProcessingTasksCount,int maxWriteTasksCount)
        {
            _maxReadTasksCount = maxReadTasksCount;
            _maxProcessingTasksCount = maxProcessingTasksCount;
            _maxWriteTasksCount = maxWriteTasksCount;
        }
    }
}
