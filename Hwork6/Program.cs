using System;
using System.Text;
using System.IO;

namespace Hwork6
{
    class Program
    {
        static void Recording(string[] questions)
        {
            using (StreamWriter sw = new StreamWriter(@"D:\\Сотрудники.txt", true, Encoding.Unicode))
            {
                int a = 1;
                char key = 'д';
                do
                {
                    string timeNote = DateTime.Now.ToString("g");
                    string note = a+"#"+timeNote+"#";
                    for (int i = 2; i <questions.Length; i++)
                    {
                        Console.WriteLine($"Введите {questions[i]}");
                        if (i == 6)
                        {
                            note += Console.ReadLine();
                        }
                        else
                        {
                            note += Console.ReadLine() + "#";
                        }
                    }
                    sw.WriteLine($"{note}");
                    Console.WriteLine("Продолжить? д/н");
                    key = Console.ReadKey(true).KeyChar;
                    a++;
                }
                while (char.ToLower(key) == 'д');
                if (char.ToLower(key) == 'н')
                {
                    sw.Close();
                    Main();
                }
                    
            }
        }
        static void Reading(string[] questions)
        {
            using (StreamReader sr = new StreamReader(@"D:\\Сотрудники.txt", Encoding.Unicode))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    for (int i = 0; i < data.Length; i++)
                    {
                        Console.WriteLine($"{questions[i % questions.Length]}{data[i]}");
                    }
                }
                Console.WriteLine("Перейти в меню выбора? д/н");
                char choice = Console.ReadKey().KeyChar;
                if (char.ToLower(choice) == 'д')
                {
                    sr.Close();
                    Main();
                }    
            }
        }
        static void Main()
        {
            string coWorkers= @"D:\\Сотрудники.txt";
            if (File.Exists(coWorkers) == false)
            {
                File.Create(coWorkers).Close();
            }
            string[] questions = new string[] { "ID: ","Время записи:", "Фамилия,имя и отчество: ", "возраст: ", "рост: ", "дата рождения: ", "место рождения: " };
            Console.WriteLine("Чтение данных (1) или запись новых данных (2)?");
            char ch = Console.ReadKey().KeyChar;
            if (char.ToLower(ch) == '2')
            {
                Console.WriteLine();
                Recording(questions);
            }
            else if (char.ToLower(ch)=='1')
            {
                Console.WriteLine();
                Reading(questions);
            }
        }
    }
}
