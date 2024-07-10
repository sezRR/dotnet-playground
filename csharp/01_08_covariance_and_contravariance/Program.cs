// int i = 3;
// string s = "asd";
// char c = 'c';

// Polymorphism
A a = new B();

// Covariance - büyük tür -> küçük tür ataması (kalıtsal ilişki yoksa)
object[] names = new string[5] { "Ahmet", "Mehmet", "Hilmi", "Rakıf", "Şuayip" };
A[] aArr = new B[3];

IEnumerable<object> cars = new List<string>() { "Opel", "Toyota", "Mercedes" };
IEnumerable<A> tests = new List<B>() { new(), new(), new() };

Func<A> funcA = GetB;
B GetB() => new();

// Contravariance
// Action<string> xDelegate = XMethod;
// void XMethod(object o) { }
//
// Action<B> bDelegate = AMethod;
// void AMethod(A a) { }

#region Covariance

#region Array Types

// object[] x = new string[5];
// x[0] = "Ahmet";
// x[1] = true; // Runtime exception -> System.ArrayTypeMismatchException
// x[2] = "Hello, World!";
// x[3] = 123.4f;
// x[4] = 123;

#endregion

#region Return Types


#endregion

#region Generic Types
// IAnimal<object> objectAnimal = new Animal<string>();
// IAnimal<A> aAnimal = new Animal<A>();
// IAnimal<A> bAnimal = new Animal<B>();

#endregion

#endregion


#region Contravariance

#region Delegate Types

// Action<A> delegateA = a => { };
// Action<A> b = delegateA;

IAnimal<string> objectAnimal = new Animal<object>();
IAnimal<B> aAnimal = new Animal<B>();
IAnimal<B> bAnimal = new Animal<A>();


#endregion

#endregion

class A
{
    
}

class B : A
{
    
}

class X
{
    public virtual X Hi() => new();
}

class Y : X // C# 9.0
{
    public override Y Hi()
    {
        return this;
    }
}

// interface IAnimal<out T> // out T classlarda ve structlarda olmuyor, covariance yapmak istiyorsan zorunlu
// {
//     
// }
//
// class Animal<T> : IAnimal<T>
// {
//     
// }

interface IAnimal<in T> // in T classlarda ve structlarda olmuyor, contravariance yapmak istiyorsan zorunlu
{
    
}

class Animal<T> : IAnimal<T>
{
    
}

delegate void XHandsler<in T>(T t);
delegate T XHandler<out T>();
