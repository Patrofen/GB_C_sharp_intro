using System;
using System.Threading.Channels;

namespace Lesson3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayToDiagonal();
            PhoneBook();
            ReversedString();
            SeaBattle();
        }

        #region 1. Элементы массива по диагонали
        static void ArrayToDiagonal()
        {
            int[,] arr1 = { { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 } };
            Console.Write("Элементы массива по диагонали: ");
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    if (i == j) Console.Write(arr1[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
        #endregion

        #region 2. Телефонный справочник
        static void PhoneBook()
        {
            string[,] phonebook = { {"Вася",  "+74996587943"},
                                    {"Петя",  "+74959998877"},
                                    {"Коля",  "+74951122233"},
                                    {"Маша",  "+79017894455"},
                                    {"Наташа","+79991123365"} };
            for (int i = 0; i < phonebook.GetLength(0); i++)
            {
                Console.WriteLine($"{phonebook[i, 0]}: {phonebook[i, 1]}");
            }
        }
        #endregion

        #region 3. Reversed string
        static void ReversedString()
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
        }
        #endregion

        #region 4. Морской бой
        static void SeaBattle()
        {
            
            char[,] seaBattle = {
                {'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X'},
                {'X', 'O', 'X', 'X', 'X', 'O', 'O', 'O', 'X', 'O'},
                {'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X'},
                {'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'},
                {'X', 'O', 'O', 'O', 'X', 'O', 'X', 'X', 'O', 'X'},
                {'O', 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', 'X'},
                {'O', 'O', 'X', 'X', 'O', 'O', 'O', 'O', 'O', 'O'},
                {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O'}};
            Console.WriteLine("Морской бой:");

            for (int i = 0; i < seaBattle.GetLength(0); i++)
            {
                for (int j = 0; j < seaBattle.GetLength(1); j++)
                {
                    Console.Write(seaBattle[i, j]);
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
