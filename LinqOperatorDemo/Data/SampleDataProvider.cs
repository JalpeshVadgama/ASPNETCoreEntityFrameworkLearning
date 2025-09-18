using LinqOperatorDemo.Models;

namespace LinqOperatorDemo.Data
{
    // Data provider for sample data
    public static class SampleDataProvider
    {
        public static List<Person> GetPersons()
        {
            return new List<Person>
            {
                new Person { Id = 1, Name = "John Doe", Age = 30, Department = "IT", Salary = 75000, JoinDate = new DateTime(2020, 1, 15) },
                new Person { Id = 2, Name = "Jane Smith", Age = 25, Department = "HR", Salary = 65000, JoinDate = new DateTime(2021, 3, 10) },
                new Person { Id = 3, Name = "Bob Johnson", Age = 35, Department = "IT", Salary = 85000, JoinDate = new DateTime(2019, 5, 20) },
                new Person { Id = 4, Name = "Alice Brown", Age = 28, Department = "Finance", Salary = 70000, JoinDate = new DateTime(2022, 2, 5) },
                new Person { Id = 5, Name = "Charlie Wilson", Age = 40, Department = "IT", Salary = 95000, JoinDate = new DateTime(2018, 8, 12) },
                new Person { Id = 6, Name = "Diana Miller", Age = 32, Department = "HR", Salary = 68000, JoinDate = new DateTime(2020, 11, 8) },
                new Person { Id = 7, Name = "Eva Davis", Age = 27, Department = "Finance", Salary = 72000, JoinDate = new DateTime(2023, 1, 20) }
            };
        }

        public static List<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department { Name = "IT", Manager = "Tech Lead" },
                new Department { Name = "HR", Manager = "HR Director" },
                new Department { Name = "Finance", Manager = "Finance Manager" },
                new Department { Name = "Marketing", Manager = "Marketing Head" }
            };
        }

        public static List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order { OrderId = 101, PersonId = 1, Amount = 1500.50m, OrderDate = new DateTime(2024, 1, 15) },
                new Order { OrderId = 102, PersonId = 2, Amount = 750.25m, OrderDate = new DateTime(2024, 2, 10) },
                new Order { OrderId = 103, PersonId = 1, Amount = 2200.00m, OrderDate = new DateTime(2024, 2, 20) },
                new Order { OrderId = 104, PersonId = 3, Amount = 450.75m, OrderDate = new DateTime(2024, 3, 5) },
                new Order { OrderId = 105, PersonId = 4, Amount = 1800.30m, OrderDate = new DateTime(2024, 3, 15) },
                new Order { OrderId = 106, PersonId = 2, Amount = 950.00m, OrderDate = new DateTime(2024, 4, 1) }
            };
        }

        public static List<int> GetNumbers()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 5, 3, 8, 2 };
        }

        public static List<string> GetNames()
        {
            return new List<string> { "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Alice", "Bob" };
        }
    }


}
