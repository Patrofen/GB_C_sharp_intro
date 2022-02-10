using System;

namespace Lesson4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FullNames();
            StringToNumbers();
            TimeOfYearStart();
            Console.WriteLine(Fibonacci(17));
        }

        #region Задание №1 GetFullName
        static void FullNames()
        {
            Console.WriteLine("Задание №1" + "\n");
            string[] persons = {GetFullName("Иванов", "Иван", "Иванович"),
                                GetFullName("Петров", "Пётр", "Петрович"),
                                GetFullName("Сидоров", "Михаил", "Михайлович"),
                                GetFullName("Абдурахман", "Ибн Хаттаб", "Бей")};

            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine(persons[i]);
            }
            Console.Write("\n");
        }
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            string fullName = firstName + " " + lastName + " " + patronymic;
            return fullName;
        }
        #endregion

        #region Задание №2 Сумма чисел в строке
        static void StringToNumbers()
        {
            Console.WriteLine("Задание №2" + "\n");
            Console.Write("Введите числа через пробел: ");
            string data = Console.ReadLine();
            Console.WriteLine(Sum(data));
            Console.Write("\n");
        }

        static int Sum(string line)
        {
            int sum = 0;
            string number = "";

            for (int i = 0; i <= line.Length; i++)
            {
                if (i == line.Length || line[i] == ' ')
                {
                    if (number != "")
                    {
                        sum += Convert.ToInt32(number);
                        number = "";
                    }
                }
                else
                {
                    number += line[i];
                }
            }
            //string[] array = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //foreach (string item in array)
            //{
            //    sum += Convert.ToInt32(item);
            //}
            return sum;
        }
        #endregion

        #region Задание №3 Времена года
        static void TimeOfYearStart()
        {
            Console.WriteLine("Задание №3" + "\n");
            Console.Write("Введите порядковый номер текущего месяца: ");

            string inputMonthNumber;
            do
            {
                inputMonthNumber = Console.ReadLine();
                if (!IsValidMonthNum(inputMonthNumber))
                {
                    Console.WriteLine("Ошибка! Введите число от 1 до 12: ");
                }
            } while (!IsValidMonthNum(inputMonthNumber));

            TimeOfYear2(Convert.ToInt32(inputMonthNumber));
            Console.Write("\n");
        }

        static bool IsValidMonthNum(string text)
        {
            bool isValidMonths = int.TryParse(text, out int monthNumber);
            return isValidMonths && (monthNumber >= 1 && monthNumber <= 12);
        }

        static void TimeOfYear2(int MonthNum)
        {
            switch (MonthNum)
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine($"{TimesOfYearEng.Winter}");
                    TimeOfYear3(TimesOfYearEng.Winter);
                    break;
                case 3:
                case 4:
                case 5:
                    Console.WriteLine($"{TimesOfYearEng.Spring}");
                    TimeOfYear3(TimesOfYearEng.Spring);
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine($"{TimesOfYearEng.Summer}");
                    TimeOfYear3(TimesOfYearEng.Summer);
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine($"{TimesOfYearEng.Autumn}");
                    TimeOfYear3(TimesOfYearEng.Autumn);
                    break;
            }
        }

        static void TimeOfYear3(TimesOfYearEng Arg)
        {
            switch (Arg)
            {
                case TimesOfYearEng.Winter:
                    Console.WriteLine(TimesOfYearRus.Зима);
                    break;
                case TimesOfYearEng.Spring:
                    Console.WriteLine(TimesOfYearRus.Весна);
                    break;
                case TimesOfYearEng.Summer:
                    Console.WriteLine(TimesOfYearRus.Лето);
                    break;
                case TimesOfYearEng.Autumn:
                    Console.WriteLine(TimesOfYearRus.Осень);
                    break;
            }
        }
        #endregion

        #region Задание №4 Числа Фибоначчи
        //без рекурсии
        /*static int Fibonacci(int position)
        {
            int f1 = 1;
            int f2 = 0;
            if (position == 1) // терминальное условие
            {
                return 0;
            }
            if (position == 2) // терминальное условие
            {
                return 1;
            }

            int fib = 0;
            for (int i = 3; i <= position; i++)
            {
                fib = f1 + f2;
                f2 = f1;
                f1 = fib;
            }
            return fib;
        }*/

        //с рекурсией
        static int Fibonacci(int position)
        {
            Console.WriteLine("Задание №4" + "\n");
            return Fibonacci(position, out _);
        }
        static int Fibonacci(int position, out int f1)
        {
            f1 = 0;
            if (position == 1) // терминальное условие
            {
                return 0;
            }
            else if (position == 2) // терминальное условие
            {
                return 1;
            }
            else
            {
                f1 = Fibonacci(position - 1, out int f2);
                return f1 + f2;
            }
        }
        #endregion


        [Flags]
        public enum TimesOfYearEng
        {
            Winter = 1,
            Spring = 2,
            Summer = 3,
            Autumn = 4
        }
        public enum TimesOfYearRus
        {
            Зима = 1,
            Весна = 2,
            Лето = 3,
            Осень = 4
        }
    }
}
