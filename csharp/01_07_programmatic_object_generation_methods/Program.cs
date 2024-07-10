using System.Dynamic;

#region Activator

Type type = typeof(MyClass);
MyClass instance = (MyClass) Activator.CreateInstance(type)!;

#endregion

#region DynamicObject Class

dynamic myDynamicObject = new MyClass();
myDynamicObject.DynamicProperty1 = 123;
myDynamicObject.DynamicProperty2 = "123";

Console.WriteLine(myDynamicObject.DynamicProperty1);

#endregion

#region Creating Objects with the dynamic Keyword

dynamic instanceExpandoObject = new ExpandoObject();
instanceExpandoObject.DynamicProperty1 = 123;
instanceExpandoObject.DynamicProperty2 = "123";

Console.WriteLine($"{instanceExpandoObject.DynamicProperty1} - {instanceExpandoObject.DynamicProperty2}");

#endregion

class MyClass : DynamicObject
{
    public MyClass()
    {
        Console.WriteLine($"{nameof(MyClass)} instance created.");
    }

    private readonly Dictionary<string, object> properties = new();
    
    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        properties.Add(binder.Name, value);
        return true;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        properties.TryGetValue(binder.Name, out result);
        return true;
    }
}