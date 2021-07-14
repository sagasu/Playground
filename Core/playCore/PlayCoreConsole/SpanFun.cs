using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace playCoreTests
{
    [MemoryDiagnoser]
    public class SpanFun
    {
        private string date = "14 07 2020";

        [Benchmark] // No method properties are allowed :(
        public (int day, int month, int year) ParseAsString()
        {
            var day = date.Substring(0, 2);
            var month = date.Substring(3, 2);
            var year= date.Substring(6);
            return (int.Parse(day), int.Parse(month), int.Parse(year));
        }

        [Benchmark]
        public (int day, int month, int year) ParseAsSpan()
        {
            ReadOnlySpan<char> dateAsSpan = date;
            var day = dateAsSpan.Slice(0, 2);
            var month= dateAsSpan.Slice(3, 2);
            var year = dateAsSpan.Slice(6);
            return (int.Parse(day), int.Parse(month), int.Parse(year));
        }
    }
}
