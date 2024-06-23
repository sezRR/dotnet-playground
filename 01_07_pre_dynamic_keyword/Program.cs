var a = 5; // At the compile time, var will be turned into int.
dynamic b = 5; // At the runtime, dynamic will be turned into int.

// a = 5
// CompareTo -> If it returns -1: variable "a" is smaller than specified parameter for the CompareTo (6 ... +inf),
//              if it returns 0: variable "a" equals to the specified parameter for the CompareTo (5)
//              if it returns 1: variable "a" is bigger than the specified parameter for the CompareTo (-inf ... 4)
Console.WriteLine(a.CompareTo(6));

// In the given example above, we can access the function CompareTo which is defined for the type int.
// However, we cannot access the CompareTo function with the variable b, since it is defined with dynamic keyword.
// Furthermore, if you try to execute a function with dynamic b at the runtime, you will get the exception at runtime 
// that the function is not defined. For instance, b.ToStringTest(); -> exception will be thrown at the runtime.
// Thus, you should be aware of what you are doing or what you are using when you are working with dynamic variables,
// because normally, if you are doing a mistake which cause compile time error, you are not going to encounter with it,
// I mean, compiler is not going to warn you about that compile time exception(s) while using the dynamic variables.
// To sum up, compiler is not going to warn you about any exception, despite it is "compile time" exception.

Console.WriteLine(b.GetType()); // Output -> System.Int32
Console.WriteLine(b * b); // Output -> 25

// You can change the type of variable at the runtime using dynamic keyword
b = "Hello, World!";
Console.WriteLine(b.GetType()); // Output -> System.String

// If you need to make an API call to remote client, it can be beneficial to use dynamic keyword, especially if you do
// not know the return types of the called API endpoints.