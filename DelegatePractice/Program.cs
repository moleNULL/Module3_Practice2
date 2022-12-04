﻿/*
                                                      Задача
    На тему делегатів:

-Написати метод, який рахує суму двох чисел.
-Двічі методом для підрахунку сум підписатися на подію.
-Порахувати суму результатів обчислень методів.
-Логіка сум результатів повинна бути обернена в метод обгортки, який містить у  собі try-catch.
-Конструкція try-catch має бути винесена в окремий метод. Усередині конструкції try виконується
    логіка якогось методу і цей метод передається як параметр.

 */

namespace DelegatePractice
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