using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Из методички
            //string filename = "text.txt";
            //File.WriteAllText(filename, "str1"); // записываем в файл строку
            //File.AppendAllText(filename, Environment.NewLine); // вставляем перенос строки
            //File.AppendAllLines(filename, new[] { "str2", "str3" }); // добавляем еще две строки
            //string fileText = File.ReadAllText(filename);
            //Console.WriteLine(fileText);
            //string[] fileLines = File.ReadAllLines(filename);
            //Console.WriteLine(fileLines[1]); // str2

            ////JSON сериализация
            //Building house = new Building(9, 3);
            //house.Address = "ул. Ленина, 12";
            //string json = JsonSerializer.Serialize(house);
            //File.WriteAllText("house.json", json);
            ////JSON десериализация
            //string json2 = File.ReadAllText("house.json");
            //Building house2 = JsonSerializer.Deserialize<Building>(json2);

            ////XML - сериализация
            //Building house = new Building(12, 4);
            //house.Address = "ул. Мира, 24";
            //house.IsHeatable = true;
            //StringWriter stringWriter = new StringWriter();
            //XmlSerializer serializer = new XmlSerializer(typeof(Building));
            //serializer.Serialize(stringWriter, house);
            //string xml = stringWriter.ToString();
            //File.WriteAllText("house.xml", xml);

            ////XML - десериализация
            //string xmlText = File.ReadAllText("house.xml");
            //StringReader stringReader = new StringReader(xmlText);
            //XmlSerializer serializer2 = new XmlSerializer(typeof(Building));
            //Building house2 = (Building)serializer2.Deserialize(stringReader);

            ////Бинарная сериализация
            //Building house = new Building(5, 2);
            //house.Address = "ул. Победы, 14";
            //BinaryFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(new FileStream("house.bin",
            //    FileMode.OpenOrCreate), house);

            ////Бинарная десериализация
            //BinaryFormatter formatter2 = new BinaryFormatter();
            //Building building = (Building)formatter2.Deserialize(new FileStream("house.bin",
            //    FileMode.Open));
            //Console.WriteLine(building.Address); // ул. Победы, 14

            ////Операции с файлами и директориями
            //string workDir = @"E:\ExampleDir";
            //Console.WriteLine(Directory.Exists(workDir)); // Проверяет, существует ли заданная директория
            //string notesDir = Path.Combine(workDir, "Notes"); // "E:\ExampleDir\Notes"
            //Directory.CreateDirectory(notesDir); // Создаем вложенную директорию
            //string noteText = "Этот файл создан автоматически";
            //string notePath = Path.Combine(notesDir, "Note 1.txt"); //"E:\ExampleDir\Notes\Note 1.txt"
            //File.WriteAllText(notePath, noteText);
            //string copyOfNotePath = Path.Combine(workDir, "Copy of Note 1.txt"); //"E:\ExampleDir\Copy of Note 1.txt"
            //File.Copy(notePath, copyOfNotePath); // Копируем созданную заметку в "E:\ExampleDir\Copy of Note 1.txt"
            //Console.WriteLine(File.Exists(copyOfNotePath)); // Проверяет, существует ли заданный файл
            //File.Move(copyOfNotePath, Path.Combine(notesDir, "Note 2.txt")); // Перемещаем заметку в "E:\ExampleDir\Notes\Note 2.txt"
            //// Создаем директорию "E:\ExampleDir\Documents" и перемещаем в нее директорию Notes
            //Directory.CreateDirectory(Path.Combine(workDir, "Documents"));
            //Directory.Move(notesDir, Path.Combine(workDir, "Documents", "Notes"));
            //// Перечень всех файлов и папок, вложенных в workDir
            //string[] entries = Directory.GetFileSystemEntries(workDir, "*",
            //    SearchOption.AllDirectories);
            //for (int i = 0; i < entries.Length; i++)
            //{
            //    Console.WriteLine(entries[i]);
            //}
            ////Методы классов Directory и Path позволяют получать необходимые фрагменты из пути к файлу или каталогу:
            //string note = @"E:\ExampleDir\Documents\Notes\Note 1.txt";
            //Console.WriteLine(Path.GetFileName(note)); // Note 1.txt
            //Console.WriteLine(Path.GetFileNameWithoutExtension(note)); // Note 1
            //Console.WriteLine(Path.GetExtension(note)); // .txt
            //Console.WriteLine(Directory.GetParent(note)); // D:\ExampleDir\Documents\Notes
            #endregion

            ReadAndSaveToFile();
            AppendTimeToFile();
            WriteToBinary();
        }

        #region Задание №1
        static void ReadAndSaveToFile()
        {
            Console.WriteLine("Укажите имя файла для записи данных: ");

            string path = Console.ReadLine();
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Введен неверный путь");
                return;
            }

            if (!path.EndsWith(".txt")) path += ".txt";

            Console.WriteLine("Введите строку");
            string data = Console.ReadLine();

            File.WriteAllText(path, data);
        }
        #endregion

        #region Задание №2
        static void AppendTimeToFile()
        {
            string filename = "startup.txt";
            string date = DateTime.Now.ToString("T");
            File.AppendAllText(filename, date + Environment.NewLine);
        }
        #endregion

        #region Задание №3
        static void WriteToBinary()
        {
            string path = "numbers.bin";

            Console.WriteLine("Введите произвольный набор чисел от 0 до 255 через пробел");
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            byte[] byteArr = new byte[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (int.TryParse(input[i], out int number))
                {
                    if (number > 0 && number < 255)
                    {
                        byteArr[i] = (byte)number;
                    }
                    else
                    {
                        Console.WriteLine($"Введено некорректное число: {input[i]}");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"Введенные данные не являются числом: {input[i]}");
                    return;
                }
            }
            File.WriteAllBytes(path, byteArr);

            //проверка
            byte[] newByteArr = File.ReadAllBytes(path);
        }
        #endregion
    }
}
