using LinqOperatorDemo.Data;

namespace LinqOperatorDemo.Operators
{
    // 10. PARTITIONING OPERATORS
    public static class PartitioningOperators
    {
        public static void DemonstrateSkip()
        {
            Console.WriteLine("=== SKIP OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var skipFirst3 = persons.Skip(3);

            Console.WriteLine("Skip first 3 persons:");
            foreach (var person in skipFirst3)
            {
                Console.WriteLine($"  {person.Name}");
            }
            Console.WriteLine();
        }

        public static void DemonstrateSkipWhile()
        {
            Console.WriteLine("=== SKIPWHILE OPERATOR ===");
            var numbers = new[] { 1, 3, 5, 7, 2, 4, 6, 8 };

            var skipWhileOdd = numbers.SkipWhile(n => n % 2 == 1);

            Console.WriteLine($"Original numbers: {string.Join(", ", numbers)}");
            Console.WriteLine($"Skip while odd: {string.Join(", ", skipWhileOdd)}");
            Console.WriteLine();
        }

        public static void DemonstrateTake()
        {
            Console.WriteLine("=== TAKE OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var takeFirst3 = persons.Take(3);

            Console.WriteLine("Take first 3 persons:");
            foreach (var person in takeFirst3)
            {
                Console.WriteLine($"  {person.Name}");
            }
            Console.WriteLine();
        }

        public static void DemonstrateTakeWhile()
        {
            Console.WriteLine("=== TAKEWHILE OPERATOR ===");
            var numbers = new[] { 1, 3, 5, 7, 2, 4, 6, 8 };

            var takeWhileOdd = numbers.TakeWhile(n => n % 2 == 1);

            Console.WriteLine($"Original numbers: {string.Join(", ", numbers)}");
            Console.WriteLine($"Take while odd: {string.Join(", ", takeWhileOdd)}");
            Console.WriteLine();
        }
    }
}


