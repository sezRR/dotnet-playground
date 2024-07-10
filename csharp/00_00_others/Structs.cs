using System;

namespace _00_00_others;

public class Structs
{
    public static void Demo()
    {
        MyStruct m1 = new()
        {
            X = 1,
            Y = 2
        };

        MyStruct m2 = new()
        {
            X = 1,
            Y = 2
        };
        if (m1.Equals(m2))
            Console.WriteLine("Equals");


        MyStruct myStruct1 = new()
        {
            X = 123,
            Y = 456
        };

        MyStruct myStruct2 = myStruct1;

        myStruct1.X = 1;
        Console.WriteLine(myStruct1.X);
        Console.WriteLine(myStruct2.X);
    }
}

struct MyStruct
{
    public int X { get; set; }
    public int Y { get; set; }

    public void A()
    {
    }
}