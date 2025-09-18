using LinqOperatorDemo.Data;

namespace LinqOperatorDemo.Operators
{
    // 9. SET OPERATORS
    public static class SetOperators
    {
        public static void DemonstrateDistinct()
        {
            Console.WriteLine("=== DISTINCT OPERATOR ===");
            var numbers = SampleDataProvider.GetNumbers();
            var names = SampleDataProvider.GetNames();

            var distinctNumbers = numbers.Distinct();
            var distinctNames = names.Distinct();

            Console.WriteLine($"Original numbers: {string.Join(", ", numbers)}");
            Console.WriteLine($"Distinct numbers: {string.Join(", ", distinctNumbers)}");
            Console.WriteLine($"Original names: {string.Join(", ", names)}");
            Console.WriteLine($"Distinct names: {string.Join(", ", distinctNames)}");
            Console.WriteLine();
        }

        public static void DemonstrateExcept()
        {
            Console.WriteLine("=== EXCEPT OPERATOR ===");
            var numbers1 = new[] { 1, 2, 3, 4, 5 };
            var numbers2 = new[] { 3, 4, 5, 6, 7 };

            var except = numbers1.Except(numbers2);

            Console.WriteLine($"First sequence: {string.Join(", ", numbers1)}");
            Console.WriteLine($"Second sequence: {string.Join(", ", numbers2)}");
            Console.WriteLine($"First except Second: {string.Join(", ", except)}");
            Console.WriteLine();
        }

        public static void DemonstrateIntersect()
        {
            Console.WriteLine("=== INTERSECT OPERATOR ===");
            var numbers1 = new[] { 1, 2, 3, 4, 5 };
            var numbers2 = new[] { 3, 4, 5, 6, 7 };

            var intersect = numbers1.Intersect(numbers2);

            Console.WriteLine($"First sequence: {string.Join(", ", numbers1)}");
            Console.WriteLine($"Second sequence: {string.Join(", ", numbers2)}");
            Console.WriteLine($"Intersection: {string.Join(", ", intersect)}");
            Console.WriteLine();
        }

        public static void DemonstrateUnion()
        {
            Console.WriteLine("=== UNION OPERATOR ===");
            var numbers1 = new[] { 1, 2, 3, 4, 5 };
            var numbers2 = new[] { 3, 4, 5, 6, 7 };

            var union = numbers1.Union(numbers2);

            Console.WriteLine($"First sequence: {string.Join(", ", numbers1)}");
            Console.WriteLine($"Second sequence: {string.Join(", ", numbers2)}");
            Console.WriteLine($"Union: {string.Join(", ", union)}");
            Console.WriteLine();
        }
    }


}


