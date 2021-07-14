using System;
using BenchmarkDotNet.Running;
using playCoreTests;

namespace PlayCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make sure it runs in release mode
            BenchmarkRunner.Run<SpanFun>(); // It will execute all the methods in the SpanFun class

            Console.WriteLine("Hello World!");
        }
    }
}