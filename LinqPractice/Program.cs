/*
                                                      Задача
    На тему LINQ:

-Створити список контактів та випробувати всі основні методи LINQ
-Методи:
    *Select(), Where(), OrderBy(), OrderByDescending(), Join(),
    *GroupBy(), All(), Any(), Count(), Take(),
    *TakeLast(), Skip(), SkipWhile(), Contains(), Distinct()
    *Except(), Union(), Intersect(), Concat(), First(),
    *FirstOrDefault(), ElementAt(), ElementAtOrDefault(), Last(),
    *LastOrDefault(), Reverse()

 */

namespace LinqPractice
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Starter.Run();

            Console.Write("\nPress any key to continue . . .");
            Console.ReadKey();
        }
    }
}