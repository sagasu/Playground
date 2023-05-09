using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Playground;

public class Name
{
    public void Introduction(string name) => Console.WriteLine("My name is " + name);
    public void Introduction(string name, int age = 0) => Console.WriteLine($"My name is {name} my age is {age}");

    public async void AsyncMethodReturnsVoid()
    {
        await AsyncMethod();
    }

    public Task AsyncMethod()
    {
        return new Task(() => Console.WriteLine("foo"));
    }
}

