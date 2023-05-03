//namespace Playground;

// See https://aka.ms/new-console-template for more information

using System.Collections;
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
for (;;) ;// for doesn't require a body either


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