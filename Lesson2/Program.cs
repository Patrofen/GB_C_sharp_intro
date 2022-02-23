using System;
using System.Globalization;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            AverageTemp();
            MonthNumber();
            EvenOddNums();
            Check_KKM();
            WinterMonth();
            BitMasks();
        }

        #region 1. Среднесуточная температура
        static void AverageTemp()
        {
            Console.Write("Введите минимальную температуру за сутки: ");
            string minTempStr = Console.ReadLine().Replace(".", ",");
            Console.Write("Введите максимальную температуру за сутки: ");
            string maxTempStr = Console.ReadLine().Replace(".", ",");

            bool isValidMinTemp = float.TryParse(minTempStr, out float minTemp);
            bool isValidMaxTemp = float.TryParse(maxTempStr, out float maxTemp);

            // Чтобы не замещать замещать точку на запятую можно использовать парсинг с CultureInfo.InvariantCulture
            bool isValid = float.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture,
                out float result);

            if (isValidMinTemp && isValidMaxTemp)
            {
                Console.WriteLine($"Среднесуточная температура:  + {(minTemp + maxTemp) / 2.0f:f2}");
            }
            else if (!isValidMinTemp)
            {
                Console.WriteLine("Некрректно введено значение минимальной температуры");
            }
            else if (!isValidMaxTemp)
            {
                Console.WriteLine("Некрректно введено значение максимальной температуры");
            }
        }
        #endregion

        #region 2. Порядковый номер текущего месяца
        static void MonthNumber()
        {
            Console.Write("Введите порядковый номер текущего месяца: ");
            string inputMonthNumber = Console.ReadLine();

            bool isValidMonths = int.TryParse(inputMonthNumber, out int MonthNumber);

            if (isValidMonths && MonthNumber >= 1 && MonthNumber <= 12)
            {
                Console.Write($"Текущий месяц: {Enum.GetName(typeof(Months), MonthNumber)}");
            }
            else
            {
                Console.WriteLine("Введён некорректный порядковый номер месяца");
            }
        }
        #endregion

        #region 3. Чётное / нечётное
        static void EvenOddNums()
        {
            Console.Write("Проверка чётности. Введите целое число: ");
            string inputNumber = Console.ReadLine();
            bool isValidNumber = int.TryParse(inputNumber, out int Number);

            if (isValidNumber)
            {
                Console.Write(Number % 2 == 0 ? "Чётное" : "Нечётное");
            }
            else Console.Write("Введено некорректное значение");
        }
        #endregion

        #region 4. Чек ККМ
        static void Check_KKM()
        {
            int CheckNum = 1;
            Console.WriteLine("Кассовый чек № " + CheckNum);
            Console.WriteLine("ООО Ромашка");
            Console.WriteLine("Адрес: Деревня Верхние Бобыли, ул. Ленина, 10А");
            Console.WriteLine("Дата, время: " + DateTime.Now);
            Console.WriteLine("***********************************************");
            string Product = "Молоко";
            Console.WriteLine("Товар: " + Product);
            double Price = 55.3;
            Console.WriteLine("Цена: " + Price + " руб.");
        }
        #endregion

        #region 5. Месяц из зимнего периода
        static void WinterMonth()
        {
            Console.Write("Введите порядковый номер месяца: ");
            string inputMonthNumber = Console.ReadLine();
            Console.Write("Введите среднюю температуру: ");
            string inputMidTemp = Console.ReadLine().Replace(".", ",");

            bool isValidMonths = int.TryParse(inputMonthNumber, out int MonthNumber);
            bool isValidMidTemp = float.TryParse(inputMidTemp, out float midTemp);
            bool isWinterMonth = (MonthNumber == 12) || (MonthNumber == 1) || (MonthNumber == 2);

            if (!isValidMonths || !isValidMidTemp)
            {
                Console.WriteLine("Введены некорректные значения");
                return;
            }


            if (isWinterMonth && midTemp > 0)
            {
                Console.Write("Дождливая зима");
            }
            else if (isWinterMonth)
            {
                Console.Write("Обычная зима");
            }
            else
            {
                Console.Write("Вообще не зима");
            }
        }
        #endregion

        #region 6. Битовые маски
        static void BitMasks()
        {
            //Маски режимов работы офисов
            DaysOfWeek Office1 = (DaysOfWeek)0b_0011111;
            DaysOfWeek Office2 = DaysOfWeek.Суббота | DaysOfWeek.Воскресенье;
            DaysOfWeek Office3 = DaysOfWeek.Понедельник | DaysOfWeek.Вторник | DaysOfWeek.Среда
                               | DaysOfWeek.Четверг | DaysOfWeek.Пятница
                               | DaysOfWeek.Суббота | DaysOfWeek.Воскресенье;

            Console.WriteLine($"Режим работы офиса №1: {Office1}");
            Console.WriteLine($"Режим работы офиса №2: {Office2}");
            Console.WriteLine($"Режим работы офиса №3: {Office3}");
        }
        #endregion

        [Flags]
        public enum DaysOfWeek
        {
            Понедельник = 0b_0000001,
            Вторник = 0b_0000010,
            Среда = 0b_0000100,
            Четверг = 0b_0001000,
            Пятница = 0b_0010000,
            Суббота = 0b_0100000,
            Воскресенье = 0b_1000000
        }

        public enum Months
        {
            Январь = 1, Февраль = 2, Март = 3,
            Апрель = 4, Май = 5, Июнь = 6,
            Июль = 7, Август = 8, Сентябрь = 9,
            Октябрь = 10, Ноябрь = 11, Декабрь = 12
        }
    }
}
