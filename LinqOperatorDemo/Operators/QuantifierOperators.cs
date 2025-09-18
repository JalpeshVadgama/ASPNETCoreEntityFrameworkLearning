using LinqOperatorDemo.Data;

namespace LinqOperatorDemo.Operators
{
    // 8. QUANTIFIER OPERATORS
    public static class QuantifierOperators
    {
        public static void DemonstrateAll()
        {
            Console.WriteLine("=== ALL OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var allAdults = persons.All(p => p.Age >= 18);
            var allHighSalary = persons.All(p => p.Salary > 80000);

            Console.WriteLine($"All persons are adults (>=18): {allAdults}");
            Console.WriteLine($"All persons have high salary (>80k): {allHighSalary}");
            Console.WriteLine();
        }

        public static void DemonstrateAny()
        {
            Console.WriteLine("=== ANY OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var hasPersons = persons.Any();
            var hasItPersons = persons.Any(p => p.Department == "IT");
            var hasMarketingPersons = persons.Any(p => p.Department == "Marketing");

            Console.WriteLine($"Has any persons: {hasPersons}");
            Console.WriteLine($"Has IT persons: {hasItPersons}");
            Console.WriteLine($"Has Marketing persons: {hasMarketingPersons}");
            Console.WriteLine();
        }

        public static void DemonstrateContains()
        {
            Console.WriteLine("=== CONTAINS OPERATOR ===");
            var numbers = SampleDataProvider.GetNumbers();
            var names = SampleDataProvider.GetNames();

            var containsFive = numbers.Contains(5);
            var containsAlice = names.Contains("Alice");
            var containsZoe = names.Contains("Zoe");

            Console.WriteLine($"Numbers contain 5: {containsFive}");
            Console.WriteLine($"Names contain 'Alice': {containsAlice}");
            Console.WriteLine($"Names contain 'Zoe': {containsZoe}");
            Console.WriteLine();
        }
    }


}


