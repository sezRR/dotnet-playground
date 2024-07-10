// XHandler xDelegate = X;
// XHandler x2Delegate = () => { };
// XHandler x3Delegate = delegate { };
//
// xDelegate();
// xDelegate.Invoke();
//
// var yDelegate = Y;
// YHandler y2Delegate = (a, p) => (3, 'a');
// YHandler y3Delegate = delegate(A a, (string, int) b) { return (3, 'a'); };
//
// yDelegate(new(), ("asd", 123)); // sync
//
// void X()
// {
//     Console.WriteLine("X");
// }
//
// (int, char) Y(A a, (string, int) p)
// {
//     return (3, 'A');
// }
//
// public delegate void XHandler();
// public delegate (int, char) YHandler(A a, (string, int) p);
//
// public class A
// {
//     
// }

XHandler xDelegate = () => Console.WriteLine("1");
xDelegate += () => Console.WriteLine("2");
xDelegate += Func3;
xDelegate += () => Console.WriteLine("4");
xDelegate += () => Console.WriteLine("5");

xDelegate();
xDelegate -= Func3;
xDelegate();

xDelegate.GetInvocationList().ToList().ForEach(m => Console.WriteLine(m.Method.Name));

void Func3()
{
    Console.WriteLine("3");
}

public delegate void XHandler();