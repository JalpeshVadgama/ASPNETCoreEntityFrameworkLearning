using LinqOperatorDemo.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOperatorDemo.Operators
{

    // 1. FILTERING OPERATORS
    public static class FilteringOperators
    {
        public static void DemonstrateWhere()
        {
            Console.WriteLine("=== WHERE OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            // Filter persons older than 30
            var result = persons.Where(p => p.Age > 30);

            Console.WriteLine("Persons older than 30:");
            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        public static void DemonstrateOfType()
        {
            Console.WriteLine("=== OFTYPE OPERATOR ===");
            var mixedList = new List<object> { 1, "Hello", 3.14, 42, "World", true, 99 };

            // Filter only integer values
            var integers = mixedList.OfType<int>();
            var strings = mixedList.OfType<string>();

            Console.WriteLine("Integer values:");
            foreach (var num in integers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("String values:");
            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
        }
    }

}


