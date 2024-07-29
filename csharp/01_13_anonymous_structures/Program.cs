#region Anonymous Objects

using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

var anonymousObject = new
{
    Name = "John",
    Age = 25
};

#endregion

#region Anonymous Methods

//Sum sum1 = (int number1, int number2) => number1 + number2;
//Sum sum2 = new Sum((int number1, int number2) => number1 + number2);
//Sum sum3 = delegate (int number1, int number2) {
//    return number1 + number2; 
//};

//var function1 = () => { };
//var function2 = (bool p) => { };
//var function3 = (int a1, int a2) => { return true; };


//delegate int Sum(int number1, int number2);

#endregion

#region Anonymous Collections

var anonArr = new[] { 3, 5 };

var y = new Collection()
{
    new { Name = "John", Age = 25 },
    new { Name = "Jane", Age = 22 },
    new { Name = "Joe", Age = 30 }
};

#endregion