using System;
using System.Text;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool running = true;

            while (running)
            {
                Console.WriteLine("=== Бібліотека ===");
                Console.WriteLine("1 — довідка");
                Console.WriteLine("2 — таблиця штрафів за прострочення");
                Console.WriteLine("3 — видачі книг за жанрами і днями тижня");
                Console.WriteLine("0 — вихід");
                Console.Write("Ваш вибір: ");
                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowAbout();
                        Pause();
                        break;
                    case "2":
                        ShowFineTable();
                        Pause();
                        break;
                    case "3":
                        ShowLoansTable();
                        Pause();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("До побачення.");
                        break;
                    default:
                        Console.WriteLine("Немає такого пункту. Спробуйте ще раз.");
                        Pause();
                        break;
                }
            }
        }

        // Довідка про застосунок
        static void ShowAbout()
        {
            Console.WriteLine("Тема: Бібліотека (облік книг).");
            Console.WriteLine("Головна сутність: книга. Полів: 7.");
            Console.WriteLine("Поля:");
            Console.WriteLine("  1. Номер — int (призначає програма)");
            Console.WriteLine("  2. Назва — string");
            Console.WriteLine("  3. Автор — string");
            Console.WriteLine("  4. Жанр — string");
            Console.WriteLine("  5. Рік видання — int (1800–2026)");
            Console.WriteLine("  6. Ціна — double (більше 0)");
            Console.WriteLine("  7. Кількість примірників — int (0 і більше)");
            Console.WriteLine("Підсумкова величина: загальна вартість фонду.");
        }

        // Табулювання: штраф залежно від днів прострочення
        static void ShowFineTable()
        {
            double from = 1.0;
            double to = 5.0;
            double step = 0.5;

            Console.WriteLine("Штраф за прострочення книги");
            Console.WriteLine($"{"Днів",8}{"Простий",12}{"Зростаючий",14}");

            // 1e-9 — запас, щоб остання стрічка не зникла через похибку
            for (double x = from; x <= to + 1e-9; x += step)
            {
                double simple = 2.5 * x;
                double growing = 2.5 * x + 0.3 * x * x;
                Console.WriteLine($"{x,8:F2}{simple,12:F2}{growing,14:F2}");
            }
        }

        // Таблиця з двома входами: жанри (рядки) x дні тижня (стовпці)
        static void ShowLoansTable()
        {
            string[] genres = { "Роман", "Детектив", "Фантастика", "Поезія", "Історія",
                                "Наука", "Пригоди", "Казки" };
            string[] days = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Нд" };

            Console.Write("Скільки жанрів показати (1–" + genres.Length + "): ");
            if (!int.TryParse(Console.ReadLine(), out int rows) || rows < 1 || rows > genres.Length)
            {
                Console.WriteLine("Помилка: потрібне ціле число від 1 до " + genres.Length + ".");
                return;
            }

            Console.Write("Скільки днів показати (1–" + days.Length + "): ");
            if (!int.TryParse(Console.ReadLine(), out int cols) || cols < 1 || cols > days.Length)
            {
                Console.WriteLine("Помилка: потрібне ціле число від 1 до " + days.Length + ".");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Видачі книг за тиждень");

            // Шапка
            Console.Write($"{"Жанр",-14}");
            for (int c = 0; c < cols; c++)
            {
                Console.Write($"{days[c],6}");
            }
            Console.WriteLine($"{"Разом",8}");

            // Підсумки по стовпцях
            int[] colSums = new int[cols];
            int grandTotal = 0;

            for (int r = 0; r < rows; r++)
            {
                int rowSum = 0; // лічильник рядка — всередині зовнішнього циклу
                Console.Write($"{genres[r],-14}");
                for (int c = 0; c < cols; c++)
                {
                    int value = (r + 1) * (c + 2) % 9 + 1; // умовні дані
                    Console.Write($"{value,6}");
                    rowSum += value;
                    colSums[c] += value;
                }
                Console.WriteLine($"{rowSum,8}");
                grandTotal += rowSum;
            }

            // Рядок підсумків
            Console.Write($"{"Разом",-14}");
            for (int c = 0; c < cols; c++)
            {
                Console.Write($"{colSums[c],6}");
            }
            Console.WriteLine($"{grandTotal,8}");
        }

        // Пауза перед поверненням у меню
        static void Pause()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}