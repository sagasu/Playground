﻿//namespace Playground;

// See https://aka.ms/new-console-template for more information

using System.Collections;
using Playground;
using s = System.Text; //this is using alias

//use 'extern alias' to reference two versions of assemblies that have the same fully-qualified type names

//Class name is not valid at this point
//var sb = s.StringBuilder;
var t1 = typeof(s.StringBuilder);
var sb = new s.StringBuilder();

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

//var car3 = Car.Fiat;
//var car3 = Car;
Car car3;
car3.Fiat = "aaa";
Console.WriteLine(car3.Fiat);

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

int i1;
// compile time error, local variable may be not initialized.
//Console.WriteLine(i1);

int i2 = 5, j2;
Console.WriteLine(j2 = i2*2); //10

int i3 = 5, i4 = 2, j3 = 2;
Console.WriteLine(j3 = i2 * i4); //10

// compile time error, local variable may be not initialized.
//Display(i1);
static void Display(int val = 0){
    Console.WriteLine(val);
}


string str1, str2;
str1 = "foo";
str2 = "foo";
Console.WriteLine(object.ReferenceEquals(str1, str2)); // True!
var str3 = str1;
Console.WriteLine(object.ReferenceEquals(str1, str3)); // True
str3 = "bar";
str3 = "foo";
Console.WriteLine(object.ReferenceEquals(str1, str3)); // True!?
Console.WriteLine(str1 == str3); // True
Console.WriteLine(str1 == str3); // True

bool b1 = new Boolean();
Console.WriteLine(b1);//false
Boolean b2;

// compile time error, local variable may be not initialized.
//Console.WriteLine(b2);

int[] arr = { 1, 2, 3 };
try
{
    Console.WriteLine(arr[10]);
}
catch (Exception e)
{
    Console.WriteLine(e);
}
//Compile time error: A previous catch clause catch all exceptions of this and super type
//catch (IndexOutOfRangeException ex)
//{
//    Console.WriteLine(ex);
//}

int[] arr2 = { 1, 2, 3 };
try
{
    Console.WriteLine(arr2[10]);
}catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("ioore");
}

Console.WriteLine(Convert.ToInt32('A'));
Console.WriteLine(Convert.ToInt32('a'));


IList nums=null;
Console.WriteLine(nums?[0]); //empty output

while (false) ; //while doesn't require a body

// for doesn't require a body either
// I commented it otherwise it will run endlessly 
//for (;;) ;

//Can't access unique members for either of them.
Shape sq = new Square();
//sq.Sides = 4;
//sq.GetSides();

Printer lp = new LaserPrinter();
lp.Install(); // Printer Installed
lp.InstallNew(); // Printer new Installed
lp.InstallVirtual(); // Printer virtual Installed 
lp.InstallVirtualNew(); // Printer virtual new Installed
lp.InstallVirtualWithOverride(); // Laser Printer virtual new Installed
Console.WriteLine("________________1");
var lp2 = new LaserPrinter();
lp2.Install(); // Laser Printer Installed
lp2.InstallNew(); // Laser Printer new Installed
lp2.InstallVirtual(); // Laser Printer virtual Installed 
lp2.InstallVirtualNew(); // Laser Printer virtual new Installed
lp2.InstallVirtualWithOverride(); // Laser Printer virtual new Installed

//LaserPrinter lp3 = new Printer(); // compile error 

Console.WriteLine("________________2");
Printer2 lp3 = new LaserPrinter2();

Console.WriteLine("________________3");
var lp4 = new LaserPrinter2();

Console.WriteLine("________________4");
Printer3 lp5 = new LaserPrinter3();

Console.WriteLine("________________5");
var lp6 = new LaserPrinter3();

Processor<int> processor = new Processor<int>();
processor.BaseValue = 1;
int result = processor.Add(10);
Console.WriteLine(result);

Name name = new Name();
name.Introduction("steve"); // my name is steve, I think that in older version of c# it would not compile

Boolean foo1 = true;
foo1 = false;
bool foo2 = false;

//it needs to be initialized
//RefCheck(ref int gg);
//it needs to be initialized
//int bb;
int bb = 1;
RefCheck(ref bb);
OutCheck(out int c);

//IEnumerable<out T> is covariant using out, which means that all lower in hierarchy types can also be used

// Checking differences between List and Array in terms of variance, there is one difference
var mamals= new Mamal[2]{ new Mamal() , new Mamal()};
mamals[0] = new Mamal();
mamals[0] = new Human();
//mamals[0] = new Animal();

// This work with array but doesn't with List<>
mamals = new Human[2];
//mamals = new Animal[2];

var mamAL = new ArrayList();
mamAL.Add(new Mamal());
mamAL.Add(new Human());
mamAL.Add(new Animal()); //this works because it is covariant from object

// list is covariant I guess that because it implements IEnumerable
var listMamal = new List<Mamal>();
listMamal.Add(new Human());
listMamal.Add(new Mamal());
//listMamal.Add(new Animal());


// This doesn't work with List but works with Array
// listMamal = new List<Human>();
// This doesn't work for List and Array
//listMamal = new List<Animal>();

static void InCheck(in int g)
{
    // can't change g because it is readonly
    //g += 1;
}

static void RefCheck(ref int a)
{
    a += 1;
    return;
}

static void OutCheck(out int a)
{
    // a might not be initialized first
    //a += 1;
    //return;
    a = 1;
}

static void MyMethod()
{
    var ff = 1;
    // cant' have enum in a method
    //public enum MyEnum
    //{
    //    Spring,
    //    Summer
    //}

}

public struct Foo<T> where T : class
{
    public T First;
    public T Second;

    public Foo(T first)
    {
        this.First = first;
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

class Processor<T>
{
    public int Add(int value)
    {
        // this will not work, because we don't know the type of T
        // return this.BaseValue + value;
        return 1;
    }

    public T BaseValue { get; set; }
}