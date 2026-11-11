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
                Console.WriteLine("3 — таблиця з двома входами");
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
                        Console.WriteLine("Поки не зроблено.");
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

        // Довідка про застосунок: тема, сутність, поля з типами
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

        // Табулювання: штраф залежно від кількості днів прострочення
        static void ShowFineTable()
        {
            double from = 1.0;   // початок проміжку (днів)
            double to = 5.0;     // кінець проміжку
            double step = 0.5;   // дробовий крок

            Console.WriteLine("Штраф за прострочення книги");
            Console.WriteLine($"{"Днів",8}{"Простий",12}{"Зростаючий",14}");

            // 1e-9 — запас, щоб остання стрічка не зникла через похибку
            for (double x = from; x <= to + 1e-9; x += step)
            {
                double simple = 2.5 * x;                // 2,5 грн за день
                double growing = 2.5 * x + 0.3 * x * x; // з надбавкою за довге прострочення
                Console.WriteLine($"{x,8:F2}{simple,12:F2}{growing,14:F2}");
            }
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