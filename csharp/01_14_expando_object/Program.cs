using System.Dynamic;
using System.Text.Json;

dynamic person = new ExpandoObject();
person.Name = "John";
person.Surname = "Doe";
person.Age = 30;
person.BirthYear = new Func<int>(() => DateTime.Now.Year - person.Age);

Console.WriteLine($"Birth year: {person.BirthYear()}\n");

IDictionary<string, object> personDataDictionary = person;
foreach (KeyValuePair<string, object> item in personDataDictionary)
    Console.WriteLine($"Key: {item.Key} - Value: {item.Value}");

personDataDictionary.Remove("BirthYear");


// Serialization - Deserialization

dynamic person1 = new ExpandoObject();
person1.Name = "John";
person1.Surname = "Doe";
person1.Age = 30;

dynamic person2 = new ExpandoObject();
person2.Name = "Jane";
person2.Surname = "Doe";
person2.Age = 25;

dynamic person3 = new ExpandoObject();
person3.Name = "Jack";
person3.Surname = "Doe";
person3.Age = 20;

List<ExpandoObject> list = new()
{
    person1,
    person2,
    person3
};

var jsonData = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
Console.WriteLine(jsonData);

dynamic? data = JsonSerializer.Deserialize<List<ExpandoObject>>(jsonData);
// Write the deserialized data to console
foreach (var item in data!)
    Console.WriteLine($"Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}");
