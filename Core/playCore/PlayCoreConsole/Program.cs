using System;
using BenchmarkDotNet.Running;

namespace PlayCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make sure it runs in release mode
            BenchmarkRunner.Run<SpanBenchmark>(); // It will execute all the methods in the SpanFun class
            BenchmarkRunner.Run<ExceptionBenchmark>(); 

            Console.WriteLine("Hello World!");
        }
    }
}