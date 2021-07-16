using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace PlayCoreConsole
{
    [MemoryDiagnoser]
    public class ExceptionBenchmark
    {
        [Benchmark]
        public bool TrueFalse()
        {
            return true;
        }
        [Benchmark]
        public bool TrueException()
        {
            try
            {
                throw new AggregateException();
            }
            catch (Exception e)
            {
                return true;
            }
        }
    }
}
