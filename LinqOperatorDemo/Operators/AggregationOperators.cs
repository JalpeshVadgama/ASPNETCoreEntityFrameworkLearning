using LinqOperatorDemo.Data;

namespace LinqOperatorDemo.Operators
{
    // 6. AGGREGATION OPERATORS
    public static class AggregationOperators
    {
        public static void DemonstrateAggregate()
        {
            Console.WriteLine("=== AGGREGATE OPERATOR ===");
            var numbers = SampleDataProvider.GetNumbers().Take(5);

            // Calculate product of all numbers
            var product = numbers.Aggregate((x, y) => x * y);
            Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");
            Console.WriteLine($"Product using Aggregate: {product}");

            // Using seed value
            var sum = numbers.Aggregate(0, (acc, x) => acc + x);
            Console.WriteLine($"Sum using Aggregate with seed: {sum}");
            Console.WriteLine();
        }

        public static void DemonstrateAverage()
        {
            Console.WriteLine("=== AVERAGE OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var avgAge = persons.Average(p => p.Age);
            var avgSalary = persons.Average(p => p.Salary);

            Console.WriteLine($"Average age: {avgAge:F2}");
            Console.WriteLine($"Average salary: {avgSalary:C}");
            Console.WriteLine();
        }

        public static void DemonstrateCount()
        {
            Console.WriteLine("=== COUNT OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var totalCount = persons.Count();
            var itCount = persons.Count(p => p.Department == "IT");
            var highSalaryCount = persons.Count(p => p.Salary > 75000);

            Console.WriteLine($"Total persons: {totalCount}");
            Console.WriteLine($"IT department persons: {itCount}");
            Console.WriteLine($"High salary (>75k) persons: {highSalaryCount}");
            Console.WriteLine();
        }

        public static void DemonstrateLongCount()
        {
            Console.WriteLine("=== LONGCOUNT OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var longCount = persons.LongCount();
            var filteredLongCount = persons.LongCount(p => p.Age > 25);

            Console.WriteLine($"Total persons (LongCount): {longCount}");
            Console.WriteLine($"Persons older than 25 (LongCount): {filteredLongCount}");
            Console.WriteLine();
        }

        public static void DemonstrateMax()
        {
            Console.WriteLine("=== MAX OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();
            var numbers = SampleDataProvider.GetNumbers();

            var maxAge = persons.Max(p => p.Age);
            var maxSalary = persons.Max(p => p.Salary);
            var maxNumber = numbers.Max();

            Console.WriteLine($"Maximum age: {maxAge}");
            Console.WriteLine($"Maximum salary: {maxSalary:C}");
            Console.WriteLine($"Maximum number: {maxNumber}");
            Console.WriteLine();
        }

        public static void DemonstrateMin()
        {
            Console.WriteLine("=== MIN OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();
            var numbers = SampleDataProvider.GetNumbers();

            var minAge = persons.Min(p => p.Age);
            var minSalary = persons.Min(p => p.Salary);
            var minNumber = numbers.Min();

            Console.WriteLine($"Minimum age: {minAge}");
            Console.WriteLine($"Minimum salary: {minSalary:C}");
            Console.WriteLine($"Minimum number: {minNumber}");
            Console.WriteLine();
        }

        public static void DemonstrateSum()
        {
            Console.WriteLine("=== SUM OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();
            var numbers = SampleDataProvider.GetNumbers();

            var totalSalary = persons.Sum(p => p.Salary);
            var totalNumbers = numbers.Sum();
            var itSalarySum = persons.Where(p => p.Department == "IT").Sum(p => p.Salary);

            Console.WriteLine($"Total salary budget: {totalSalary:C}");
            Console.WriteLine($"Sum of numbers: {totalNumbers}");
            Console.WriteLine($"IT department total salary: {itSalarySum:C}");
            Console.WriteLine();
        }

        // NEW IN .NET 9
        public static void DemonstrateCountBy()
        {
            Console.WriteLine("=== COUNTBY OPERATOR (.NET 9) ===");
            var persons = SampleDataProvider.GetPersons();

            var departmentCounts = persons.CountBy(p => p.Department);

            Console.WriteLine("Count by department:");
            foreach (var item in departmentCounts)
            {
                Console.WriteLine($"Department: {item.Key}, Count: {item.Value}");
            }
            Console.WriteLine();
        }

        // NEW IN .NET 9
        public static void DemonstrateAggregateBy()
        {
            Console.WriteLine("=== AGGREGATEBY OPERATOR (.NET 9) ===");
            var persons = SampleDataProvider.GetPersons();

            var departmentSalarySum = persons.AggregateBy(p => p.Department, 0m, (sum, person) => sum + person.Salary);

            Console.WriteLine("Total salary by department:");
            foreach (var item in departmentSalarySum)
            {
                Console.WriteLine($"Department: {item.Key}, Total Salary: {item.Value:C}");
            }
            Console.WriteLine();
        }
    }

}


