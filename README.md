# CSharp-Reflection

C# Code

```c#
using System;
using System.Reflection;

namespace DemoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("Assembly: " + assembly.FullName);

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("Type: " + type.Name + ", BaseType: " + type.BaseType);

                var properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    Console.WriteLine("\tProperty: " + propertyInfo.Name + ", PropertyType: " + propertyInfo.PropertyType);
                }

                var fields = type.GetFields();
                foreach (var fieldInfo in fields)
                {
                    Console.WriteLine("\tField: " + fieldInfo.Name + ", FieldType: " + fieldInfo.FieldType);
                }

                var methods = type.GetMethods();
                foreach (var methodInfo in methods)
                {
                    Console.WriteLine("\tMethod: " + methodInfo.Name + ", ReturnType: " + methodInfo.ReturnType);
                }
            }

            var engine = new Engine()
            {
                Power = 1000
            };

            var car = new Car()
            {
                Engine = engine,
                Model = "F",
                Age = 0,
            };

            Console.WriteLine();
            
            var carType = typeof(Car);
            //var carType = car.GetType();
            var modelProperty = carType.GetProperty("Model");
            Console.WriteLine("CarModel: " + modelProperty?.GetValue(car));

            var runMethod = carType.GetMethod("Run");
            runMethod?.Invoke(car, null);
        }
    }
    
    public class Engine
    {
        public int Power;

        public void Start()
        {
            Console.WriteLine("Engine Start...");
        }
    }

    public class Car
    {
        public Engine Engine;

        public string Model { get; set; }
        public int Age;
        private string Country;

        public void Run()
        {
            Engine.Start();
        }
    }
}
```

Console Output

```console
Assembly: DemoReflection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
Type: Program, BaseType: System.Object
        Method: Equals, ReturnType: System.Boolean
        Method: GetHashCode, ReturnType: System.Int32
        Method: GetType, ReturnType: System.Type
        Method: ToString, ReturnType: System.String
Type: Engine, BaseType: System.Object
        Field: Power, FieldType: System.Int32
        Method: Start, ReturnType: System.Void
        Method: Equals, ReturnType: System.Boolean
        Method: GetHashCode, ReturnType: System.Int32
        Method: GetType, ReturnType: System.Type
        Method: ToString, ReturnType: System.String
Type: Car, BaseType: System.Object
        Property: Model, PropertyType: System.String
        Field: Engine, FieldType: DemoReflection.Engine
        Field: Age, FieldType: System.Int32
        Method: get_Model, ReturnType: System.String
        Method: set_Model, ReturnType: System.Void
        Method: Run, ReturnType: System.Void
        Method: Equals, ReturnType: System.Boolean
        Method: GetHashCode, ReturnType: System.Int32
        Method: GetType, ReturnType: System.Type
        Method: ToString, ReturnType: System.String

CarModel: F
Engine Start...
```
