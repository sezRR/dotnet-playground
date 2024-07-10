#region Action

// Action action1 = () => Console.WriteLine("Action");
// Action<bool> action2 = (b) => Console.WriteLine("Action<T>");
// Action<bool, int, int> action3 = (b, i1, i2) => Console.WriteLine("Action<T, T, T>");

#endregion

#region Func

// Geriye int dönen metotları temsil eden bir Func delegate'i
// Func<int> func1 = () => 3;

// Geriye bool dönen ve parametre olarak int, char alan Func delegate'i
// Func<int, char, bool> func2 = (i, c) => 3 == 3;

//Geriye (int, char)-tuple dönen ve parametre olarak byte, int, string alan FUnc delegate'i
// Func<byte, int, string, (int, char)> func3 = (b, i, s) => (i, 'c');

#endregion

#region Predicate

// Predicate<bool> predicate1 = b => b;
// Predicate<int> predicate2 = i => i < 10;

#endregion

#region Lambda Discard Parameters

Func<int, int, string, char> func = (_, _, s) => 'a';

#endregion