namespace _00_00_others;

public class StaticConstructors
{
    public static void Demo()
    {
        // MyClass myClass1 = new("myClass1");
        // MyClass myClass2 = new("myClass2");
        // MyClass myClass3 = new("myClass3");

        MyClass.Test(); // Static ctor will be run!
    }
}

class MyClass
{
    public MyClass(string className)
    {
        Console.WriteLine($"From the PUBLIC ctor! -> {className}");
    }
    
    static MyClass()
    {
        Console.WriteLine("From the STATIC ctor!");
    }

    public static void Test()
    {
        Console.WriteLine("Static Void Test Member Function from MyClass Triggered!");
    }
}