// var director = new Director();
// var builder = new ConcreteBuilder();
// director.Builder = builder;
//
// Console.WriteLine("Standard basic product:");
// director.BuildMinimalViableProduct();
// Console.WriteLine(builder.GetProduct().ListParts());
//
// Console.WriteLine("Standard full featured product:");
// director.BuildFullFeaturedProduct();
// Console.WriteLine(builder.GetProduct().ListParts());
//
// Console.WriteLine("Custom product:");
// builder.BuildPartA();
// builder.BuildPartC();
// Console.Write(builder.GetProduct().ListParts());
//
// class Product
// {
//     private readonly List<object> _parts = new();
//
//     public void Add(string part)
//     {
//         _parts.Add(part);
//     }
//
//     public string ListParts()
//     {
//         string str = string.Empty;
//
//         for (int i = 0; i < this._parts.Count; i++)
//             str += _parts[i] + ", ";
//
//         str = str.Remove(str.Length - 2);
//         return $"Product parts: {str}\n";
//     }
// }
//
// internal interface IBuilder
// {
//     void BuildPartA();
//     void BuildPartB();
//     void BuildPartC();
// }
//
// class ConcreteBuilder : IBuilder
// {
//     private Product _product = new();
//
//     public ConcreteBuilder()
//     {
//         Reset();
//     }
//
//     public void Reset()
//     {
//         _product = new();
//     }
//
//     public void BuildPartA()
//     {
//         _product.Add("PartA1");
//     }
//
//     public void BuildPartB()
//     {
//         _product.Add("PartB1");
//     }
//
//     public void BuildPartC()
//     {
//         _product.Add("PartC1");
//     }
//
//     public Product GetProduct()
//     {
//         Product result = _product;
//
//         Reset();
//
//         return result;
//     }
// }
//
// class Director
// {
//     private IBuilder _builder;
//
//     public IBuilder Builder
//     {
//         set => _builder = value;
//     }
//
//     public void BuildMinimalViableProduct()
//     {
//         _builder.BuildPartA();
//     }
//
//     public void BuildFullFeaturedProduct()
//     {
//         _builder.BuildPartA();
//         _builder.BuildPartB();
//         _builder.BuildPartC();
//     }
// }