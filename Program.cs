using static Linq3.ListGenerator;
namespace Linq3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var products = ProductList;
            var customers = CustomerList;

            #region Question 1: Get the first 3 orders from customers in Washington.
            //var first3OrdersInWashington = customers
            //    .Where(c => c.Region == "WA")
            //    .SelectMany(c => c.Orders)
            //    .Take(3)
            //    .ToList();
            //Console.WriteLine("First 3 Orders in Washington:");
            //foreach (var order in first3OrdersInWashington)
            //{
            //    Console.WriteLine($"OrderID: {order.OrderID}, Total: {order.Total}");
            //}
            #endregion
            #region Question 2: Get all but the first 2 orders from customers in Washington.
            var allButFirst2OrdersInWashington = customers
                .Where(c => c.Region == "WA")
                .SelectMany(c => c.Orders)
                .Skip(2)
                .ToList();
            Console.WriteLine("\nAll but First 2 Orders in Washington:");
            foreach (var order in allButFirst2OrdersInWashington)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, Total: {order.Total}");
            }
            #endregion
            #region Question 3: Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var untilNumberLessThanPosition = numbers
                .TakeWhile((n, index) => n >= index)
                .ToArray();
            Console.WriteLine("\nElements until number less than position:");
            foreach (var number in untilNumberLessThanPosition)
            {
                Console.WriteLine(number);
            }
            #endregion
            #region Question 4: Get the elements of the array starting from the first element divisible by 3.
            var fromFirstDivisibleBy3 = numbers
                .SkipWhile(n => n % 3 != 0)
                .ToArray();
            Console.WriteLine("\nElements from first divisible by 3:");
            foreach (var number in fromFirstDivisibleBy3)
            {
                Console.WriteLine(number);
            }
            #endregion
            #region Question 5: Get the elements of the array starting from the first element less than its position.
            var fromFirstLessThanPosition = numbers
                .SkipWhile((n, index) => n >= index)
                .ToArray();
            Console.WriteLine("\nElements from first less than position:");
            foreach (var number in fromFirstLessThanPosition)
            {
                Console.WriteLine(number);
            }
            #endregion
            #region LINQ – Grouping Operators

            // 1. Use group by to partition a list of numbers by their remainder when divided by 5
            List<int> numbersList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var numbersGroupedByRemainder = numbersList.GroupBy(n => n % 5)
                                                       .Select(g => new { Remainder = g.Key, Numbers = g.ToList() });

            foreach (var group in numbersGroupedByRemainder)
            {
                Console.WriteLine($"Numbers with a remainder of {group.Remainder} when divided by 5:\n{string.Join("\n", group.Numbers)}");

            }


            #endregion
        }

    }
}