using LinqOperatorDemo.Data;

namespace LinqOperatorDemo.Operators
{
    // 5. JOIN OPERATORS
    public static class JoinOperators
    {
        public static void DemonstrateJoin()
        {
            Console.WriteLine("=== JOIN OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();
            var orders = SampleDataProvider.GetOrders();

            var result = persons.Join(orders,
                person => person.Id,
                order => order.PersonId,
                (person, order) => new { person.Name, order.OrderId, order.Amount });

            Console.WriteLine("Persons with their orders (Inner Join):");
            foreach (var item in result)
            {
                Console.WriteLine($"Person: {item.Name}, Order: {item.OrderId}, Amount: {item.Amount:C}");
            }
            Console.WriteLine();
        }

        public static void DemonstrateGroupJoin()
        {
            Console.WriteLine("=== GROUPJOIN OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();
            var orders = SampleDataProvider.GetOrders();

            var result = persons.GroupJoin(orders,
                person => person.Id,
                order => order.PersonId,
                (person, orderGroup) => new { person.Name, Orders = orderGroup });

            Console.WriteLine("Persons with grouped orders (Left Join):");
            foreach (var item in result)
            {
                Console.WriteLine($"Person: {item.Name}");
                if (item.Orders.Any())
                {
                    foreach (var order in item.Orders)
                    {
                        Console.WriteLine($"  Order: {order.OrderId}, Amount: {order.Amount:C}");
                    }
                }
                else
                {
                    Console.WriteLine("  No orders");
                }
            }
            Console.WriteLine();
        }
    }
}


