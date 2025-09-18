using LinqOperatorDemo.Data;

namespace LinqOperatorDemo.Operators
{
    // 3. SORTING OPERATORS
    public static class SortingOperators
    {
        public static void DemonstrateOrderBy()
        {
            Console.WriteLine("=== ORDERBY OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var result = persons.OrderBy(p => p.Age);

            Console.WriteLine("Persons ordered by age (ascending):");
            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        public static void DemonstrateOrderByDescending()
        {
            Console.WriteLine("=== ORDERBYDESCENDING OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var result = persons.OrderByDescending(p => p.Salary);

            Console.WriteLine("Persons ordered by salary (descending):");
            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        public static void DemonstrateThenBy()
        {
            Console.WriteLine("=== THENBY OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var result = persons.OrderBy(p => p.Department).ThenBy(p => p.Age);

            Console.WriteLine("Persons ordered by department, then by age:");
            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        public static void DemonstrateThenByDescending()
        {
            Console.WriteLine("=== THENBYDESCENDING OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var result = persons.OrderBy(p => p.Department).ThenByDescending(p => p.Salary);

            Console.WriteLine("Persons ordered by department, then by salary (desc):");
            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        public static void DemonstrateReverse()
        {
            Console.WriteLine("=== REVERSE OPERATOR ===");
            var numbers = SampleDataProvider.GetNumbers().Take(5);

            Console.WriteLine("Original sequence:");
            Console.WriteLine(string.Join(", ", numbers));

            var reversed = numbers.Reverse();
            Console.WriteLine("Reversed sequence:");
            Console.WriteLine(string.Join(", ", reversed));
            Console.WriteLine();
        }
    }

}


