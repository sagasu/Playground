// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");

BenchmarkRunner.Run<HoistingAggregation>();

[MemoryDiagnoser]
public class HoistingAggregation
{
    [Benchmark]
    [Arguments(100, 10)]
    public int? A(int? x, int? y)
    {
        int? sum = 0;
        for (int i = 0; i < 1000; i++)
            sum += x + y;

        return sum.Value;
    }

    [Benchmark]
    [Arguments(100, 10)]
    public int? B(int? x, int? y)
    {
        int? sum = 0;
        var h = x + y;
        for (int i = 0; i < 1000; i++)
            sum += h;

        return sum.Value;
    }
}

