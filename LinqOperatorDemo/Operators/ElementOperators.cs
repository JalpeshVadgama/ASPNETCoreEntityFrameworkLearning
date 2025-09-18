using LinqOperatorDemo.Data;

namespace LinqOperatorDemo.Operators
{
    // 7. ELEMENT OPERATORS
    public static class ElementOperators
    {
        public static void DemonstrateElementAt()
        {
            Console.WriteLine("=== ELEMENTAT OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            try
            {
                var thirdPerson = persons.ElementAt(2);
                Console.WriteLine($"Third person (index 2): {thirdPerson.Name}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Index out of range");
            }
            Console.WriteLine();
        }

        public static void DemonstrateElementAtOrDefault()
        {
            Console.WriteLine("=== ELEMENTATORDEFAULT OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var tenthPerson = persons.ElementAtOrDefault(9);
            Console.WriteLine($"Tenth person (index 9): {tenthPerson?.Name ?? "null"}");
            Console.WriteLine();
        }

        public static void DemonstrateFirst()
        {
            Console.WriteLine("=== FIRST OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var firstPerson = persons.First();
            var firstItPerson = persons.First(p => p.Department == "IT");

            Console.WriteLine($"First person: {firstPerson.Name}");
            Console.WriteLine($"First IT person: {firstItPerson.Name}");
            Console.WriteLine();
        }

        public static void DemonstrateFirstOrDefault()
        {
            Console.WriteLine("=== FIRSTORDEFAULT OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var firstMarketing = persons.FirstOrDefault(p => p.Department == "Marketing");
            Console.WriteLine($"First Marketing person: {firstMarketing?.Name ?? "null"}");
            Console.WriteLine();
        }

        public static void DemonstrateLast()
        {
            Console.WriteLine("=== LAST OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var lastPerson = persons.Last();
            var lastHrPerson = persons.Last(p => p.Department == "HR");

            Console.WriteLine($"Last person: {lastPerson.Name}");
            Console.WriteLine($"Last HR person: {lastHrPerson.Name}");
            Console.WriteLine();
        }

        public static void DemonstrateLastOrDefault()
        {
            Console.WriteLine("=== LASTORDEFAULT OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var lastMarketing = persons.LastOrDefault(p => p.Department == "Marketing");
            Console.WriteLine($"Last Marketing person: {lastMarketing?.Name ?? "null"}");
            Console.WriteLine();
        }

        public static void DemonstrateSingle()
        {
            Console.WriteLine("=== SINGLE OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            try
            {
                var singlePerson = persons.Single(p => p.Id == 1);
                Console.WriteLine($"Person with ID 1: {singlePerson.Name}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();
        }

        public static void DemonstrateSingleOrDefault()
        {
            Console.WriteLine("=== SINGLEORDEFAULT OPERATOR ===");
            var persons = SampleDataProvider.GetPersons();

            var singleMarketing = persons.SingleOrDefault(p => p.Department == "Marketing");
            Console.WriteLine($"Single Marketing person: {singleMarketing?.Name ?? "null"}");
            Console.WriteLine();
        }
    }

}


