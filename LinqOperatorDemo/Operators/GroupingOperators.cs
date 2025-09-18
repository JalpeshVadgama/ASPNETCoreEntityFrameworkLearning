using LinqOperatorDemo.Data;

namespace LinqOperatorDemo.Operators
{
    // 4. GROUPING OPERATORS
    public static class GroupingOperators
    {
        public static void DemonstrateGroupBy()
        {
            Console.WriteLine("=== GROUPBY OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var result = persons.GroupBy(p => p.Department);

            Console.WriteLine("Persons grouped by department:");
            foreach (var group in result)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (var person in group)
                {
                    Console.WriteLine($"  {person.Name} - {person.Salary:C}");
                }
            }
            Console.WriteLine();
        }

        public static void DemonstrateToLookup()
        {
            Console.WriteLine("=== TOLOOKUP OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var lookup = persons.ToLookup(p => p.Age > 30);

            Console.WriteLine("Persons lookup by age > 30:");
            Console.WriteLine($"Persons over 30: {lookup[true].Count()}");
            foreach (var person in lookup[true])
            {
                Console.WriteLine($"  {person.Name} - {person.Age}");
            }

            Console.WriteLine($"Persons 30 or under: {lookup[false].Count()}");
            foreach (var person in lookup[false])
            {
                Console.WriteLine($"  {person.Name} - {person.Age}");
            }
            Console.WriteLine();
        }
    }

}


