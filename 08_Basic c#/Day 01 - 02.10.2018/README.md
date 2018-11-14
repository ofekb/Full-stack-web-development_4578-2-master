# Using function that is declared in two namspaces

### Problem:
```csharp
namespace _00_basic_oop_class
{
    class Console
    {
        public static void WriteLine(object obj)
        {
            //must add "System" - 
            //because current class ("Console") contains "WriteLine" function
            System.Console.WriteLine($"A msg from personal WriteLine: {obj.ToString()}");
        }
    }
}

```
```csharp

using System;
using _00_basic_oop_class;

namespace _00_basic_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            // !!!! COMPILATION ERROR !!!!!
            //'Console' is an ambiguous reference between 
            //'_00_basic_oop_class.Console' and 'System.Console'  00_basic oop   

            Console.WriteLine();
        }
    }
}

```


### Solution 1:
```csharp
namespace _00_basic_oop_class
{
    class Console
    {
        public static void WriteLine(object obj)
        {
            //must add "System" - 
            //because current class ("Console") contains "WriteLine" function
            System.Console.WriteLine($"A msg from personal WriteLine: {obj.ToString()}");
        }
    }
}

```
```csharp

namespace _00_basic_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Test1");
            _00_basic_oop_class.Console.WriteLine("Test2");
        }
    }
}


```


Output:
```
Test 1
A msg from personal WriteLine: Test2
```


### Solution 2:
```csharp
namespace _00_basic_oop_class
{
    class Console
    {
        public static void WriteLine(object obj)
        {
            //must add "System" - 
            //because current class ("Console") contains "WriteLine" function
            System.Console.WriteLine($"A msg from personal WriteLine: {obj.ToString()}");
        }
    }
}

```
```csharp
using System;
using myConsole = _00_basic_oop_class.Console;

namespace _00_basic_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test1");
            myConsole.WriteLine("Test2");
        }
    }
}
```


Output:
```
Test 1
A msg from personal WriteLine: Test2
```
# Get Current object class and base class - Dynamic

```csharp
using System;

namespace _00_basic_oop
{
    abstract class Food
    {
        //This ctor can be called only from the subClasses constructors
        public Food()
        {
            // GetType().Name - gets the name of the current object class 
            Console.WriteLine($"{GetType().BaseType.Name} was called by {GetType().Name} constructor");
        }
    }


    class Pizza{}

    class Chips{}

    class Program
    {
        static void Main(string[] args)
        {
            Pizza p = new Pizza();
            Chips c = new Chips();
        }
    }
}
```


Output:
```
Food was called by Pizza constructor
Food was called by Chips constructor
```