using LinqOperatorDemo.Data;

namespace LinqOperatorDemo.Operators
{
    // 2. PROJECTION OPERATORS
    public static class ProjectionOperators
    {
        public static void DemonstrateSelect()
        {
            Console.WriteLine("=== SELECT OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            // Project to anonymous type
            var result = persons.Select(p => new { p.Name, p.Department, AnnualSalary = p.Salary * 12 });

            Console.WriteLine("Person details with annual salary:");
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name}, Department: {item.Department}, Annual: {item.AnnualSalary:C}");
            }
            Console.WriteLine();
        }

        public static void DemonstrateSelectMany()
        {
            Console.WriteLine("=== SELECTMANY OPERATOR ===");
            var departments = new[]
            {
                new { Name = "IT", Employees = new[] { "John", "Alice", "Bob" } },
                new { Name = "HR", Employees = new[] { "Jane", "Charlie" } },
                new { Name = "Finance", Employees = new[] { "David", "Eve" } }
            };

            // Flatten nested collections
            var allEmployees = departments.SelectMany(d => d.Employees);

            Console.WriteLine("All employees from all departments:");
            foreach (var employee in allEmployees)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine();
        }
    }
}

