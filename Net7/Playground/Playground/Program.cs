//namespace Playground;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var p = new Playground.Person() { FullName = ""};

var car1 = new Car();
car1.Fiat = "aa";
var car2 = car1;

Console.Out.WriteLine(car1); // Car
Console.Out.WriteLine(car2.Fiat);//aa
car2.Fiat = "bb";
Console.Out.WriteLine(car1.Fiat);//aa
Console.Out.WriteLine(car2.Fiat);//bb

var auto1 = new Auto();
auto1.Fiat = "cc";
var auto2 = auto1;
Console.WriteLine(auto2.Fiat);//cc
auto2.Fiat = "dd";
Console.WriteLine(auto1.Fiat);//dd
Console.WriteLine(auto2.Fiat);//dd

struct Car
{
    public string Fiat;
    string BMW;

    public Car(string bmw)
    {
        BMW = bmw;
    }
}

class Auto
{
    public string Fiat;
    string BMW;
}