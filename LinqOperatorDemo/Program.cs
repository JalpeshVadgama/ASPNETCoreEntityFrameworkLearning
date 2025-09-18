using LinqOperatorDemo.Operators;

namespace LinqOperatorDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("    LINQ OPERATORS DEMONSTRATION");
            Console.WriteLine("         .NET 9 Complete Guide");
            Console.WriteLine("======================================");
            Console.WriteLine();

            // 1. Filtering Operators
            Console.WriteLine("1. FILTERING OPERATORS");
            Console.WriteLine("======================");
            FilteringOperators.DemonstrateWhere();
            FilteringOperators.DemonstrateOfType();

        //    // 2. Projection Operators
        //    Console.WriteLine("2. PROJECTION OPERATORS");
        //    Console.WriteLine("========================");
        //    ProjectionOperators.DemonstrateSelect();
        //    ProjectionOperators.DemonstrateSelectMany();

        //    // 3. Sorting Operators
        //    Console.WriteLine("3. SORTING OPERATORS");
        //    Console.WriteLine("====================");
        //    SortingOperators.DemonstrateOrderBy();
        //    SortingOperators.DemonstrateOrderByDescending();
        //    SortingOperators.DemonstrateThenBy();
        //    SortingOperators.DemonstrateThenByDescending();
        //    SortingOperators.DemonstrateReverse();

        //    // 4. Grouping Operators
        //    Console.WriteLine("4. GROUPING OPERATORS");
        //    Console.WriteLine("=====================");
        //    GroupingOperators.DemonstrateGroupBy();
        //    GroupingOperators.DemonstrateToLookup();

        //    // 5. Join Operators
        //    Console.WriteLine("5. JOIN OPERATORS");
        //    Console.WriteLine("=================");
        //    JoinOperators.DemonstrateJoin();
        //    JoinOperators.DemonstrateGroupJoin();

        //    // 6. Aggregation Operators
        //    Console.WriteLine("6. AGGREGATION OPERATORS");
        //    Console.WriteLine("========================");
        //    AggregationOperators.DemonstrateAggregate();
        //    AggregationOperators.DemonstrateAverage();
        //    AggregationOperators.DemonstrateCount();
        //    AggregationOperators.DemonstrateLongCount();
        //    AggregationOperators.DemonstrateMax();
        //    AggregationOperators.DemonstrateMin();
        //    AggregationOperators.DemonstrateSum();

        //    // .NET 9 New Operators
        //    Console.WriteLine("6a. NEW .NET 9 AGGREGATION OPERATORS");
        //    Console.WriteLine("====================================");
        //    AggregationOperators.DemonstrateCountBy();
        //    AggregationOperators.DemonstrateAggregateBy();

        //    // 7. Element Operators
        //    Console.WriteLine("7. ELEMENT OPERATORS");
        //    Console.WriteLine("====================");
        //    ElementOperators.DemonstrateElementAt();
        //    ElementOperators.DemonstrateElementAtOrDefault();
        //    ElementOperators.DemonstrateFirst();
        //    ElementOperators.DemonstrateFirstOrDefault();
        //    ElementOperators.DemonstrateLast();
        //    ElementOperators.DemonstrateLastOrDefault();
        //    ElementOperators.DemonstrateSingle();
        //    ElementOperators.DemonstrateSingleOrDefault();

        //    // 8. Quantifier Operators
        //    Console.WriteLine("8. QUANTIFIER OPERATORS");
        //    Console.WriteLine("========================");
        //    QuantifierOperators.DemonstrateAll();
        //    QuantifierOperators.DemonstrateAny();
        //    QuantifierOperators.DemonstrateContains();

        //    // 9. Set Operators
        //    Console.WriteLine("9. SET OPERATORS");
        //    Console.WriteLine("================");
        //    SetOperators.DemonstrateDistinct();
        //    SetOperators.DemonstrateExcept();
        //    SetOperators.DemonstrateIntersect();
        //    SetOperators.DemonstrateUnion();

        //    // 10. Partitioning Operators
        //    Console.WriteLine("10. PARTITIONING OPERATORS");
        //    Console.WriteLine("==========================");
        //    PartitioningOperators.DemonstrateSkip();
        //    PartitioningOperators.DemonstrateSkipWhile();
        //    PartitioningOperators.DemonstrateTake();
        //    PartitioningOperators.DemonstrateTakeWhile();

        //}
    }
}
