using NBench;
using ProjectManager.Infrastructure.Logging;
using System;

namespace ProjectManager.Business.Tests
{
    public class ProjectBusinessTests
    {
        ILogger _textFileLogger;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _textFileLogger = new TextFileLogger();
        }

        [PerfBenchmark(Description = "Info() method performance performance benchmark.",
            NumberOfIterations = 10,
            RunMode = RunMode.Throughput,
            TestMode = TestMode.Measurement)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void BenchMarkLogInfo()
        {
            _textFileLogger.Info("This is info message.");
        }

        [PerfBenchmark(Description = "Error() method performance performance benchmark.",
           NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Measurement)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        public void BenchMarkLogError()
        {
            _textFileLogger.Error("This is error message.");
        }

        [PerfCleanup]
        public void Cleanup()
        {
        }
    }
}
