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


Console.WriteLine(typeof(Auto)); //Auto
//Console.WriteLine(typeof(Auto.Fiat));


var season = new Season();
var season2 = season;
season2 = Season.Autumn;
var season3 = season2;
Console.WriteLine(season3);
season3 = Season.Summer;
Console.WriteLine(season);
Console.WriteLine(season3);
Console.WriteLine(season2);

//AttributeTargets.

/*
 //try must be followed by catch or finally or both.
try
{
    var foo = 1;
}
*/

try
{
    var foo = 1;
}
catch
{
    return;
}
finally
{
    // can't have return or break in finally
    //return;
}

foreach (var i in Enumerable.Range(0,10))
{
    try
    {
        var f = 1;
    }
    finally
    {
        //can't have break in finally;
        //break;
    }
}

enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

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