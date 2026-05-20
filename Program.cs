using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;  
            Console.InputEncoding = Encoding.UTF8;
            Console.Write("Введіть кількість рядків у масиві: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Помилка! Введіть додатне ціле число: ");
            }

            string[] rows = new string[size];

            Console.WriteLine("\nВведіть рядки:");
            for (int i = 0; i < size; i++)
            {
                Console.Write("  Рядок " + (i + 1) + ": ");
                rows[i] = Console.ReadLine();
            }

            Console.WriteLine("\nВи ввели масив рядків:");
            for (int i = 0; i < rows.Length; i++)
            {
                Console.WriteLine($"  [{i}] = \"{rows[i]}\"");
            }

            Console.WriteLine("Кількість однакових рядків:");

            var grouped = rows.GroupBy(r => r);
            foreach (var group in grouped)
            {
                Console.WriteLine($"  Рядок \"{group.Key}\" зустрічається {group.Count()} раз(и)");
            }


            Console.Write("Введіть число n (кількість однакових символів на початку рядка): ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.Write("Помилка! Введіть додатне ціле число: ");
            }

            Console.WriteLine("\nРядки, що починаються з {n} однакових символів:");

            int count = 0;
            foreach (string row in rows)
            {
                if (StartsWithNSameChars(row, n))
                {
                    Console.WriteLine($"  \"{row}\"");
                    count++;
                }
            }

            Console.WriteLine("\nЗагальна кількість таких рядків: {count}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        static bool StartsWithNSameChars(string str, int n)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            if (str.Length < n)
                return false;

            char firstChar = str[0];

            for (int i = 1; i < n; i++)
            {
                if (str[i] != firstChar)
                    return false;
            }

            return true;
        }
    }
}