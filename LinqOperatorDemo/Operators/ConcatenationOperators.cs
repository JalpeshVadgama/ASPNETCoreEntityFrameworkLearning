namespace LinqOperatorDemo.Operators
{
    // 11. CONCATENATION OPERATORS
    public static class ConcatenationOperators
    {
        public static void DemonstrateConcat()
        {
            Console.WriteLine("=== CONCAT OPERATOR ===");
            var names1 = new[] { "Alice", "Bob", "Charlie" };
            var names2 = new[] { "David", "Eve", "Frank" };

            var concatenated = names1.Concat(names2);

            Console.WriteLine($"First sequence: {string.Join(", ", names1)}");
            Console.WriteLine($"Second sequence: {string.Join(", ", names2)}");
            Console.WriteLine($"Concatenated: {string.Join(", ", concatenated)}");
            Console.WriteLine();
        }
    }

}


