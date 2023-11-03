using System.Collections.Generic;
using System.Text;

namespace Laba2_Alg
{
    class Program
    {
        public static int ReadInt(string message, Func<int, bool> validator)
        {
            int result;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out result) || !validator(result));
            return result;
        }
        public static string ReadString(string message)
        {
            string result = null;
            bool isValid = false;

            do
            {
                Console.Write(message);
                try
                {
                    result = Console.ReadLine();
                    isValid = true;
                }
                catch
                {
                    Console.WriteLine("Помилка! Будь ласка, введіть рядок ще раз.");
                }
            } while (!isValid);

            return result;
        }

        public static int DivisionHash(int key, int tableSize)
        {
            int hash = key % tableSize;
            return hash;
        }

        public static int MultiplicationHash(int key, int tableSize)
        {
            const double A = 0.61803398874989484820458683436564; // Константа A, де 0 < A < 1
            double doubleHash = (key * A) % 1;

            return (int)Math.Floor(tableSize * doubleHash);
        }

        public static int StringKeyHash(string key, int tableSize)
        {
           unchecked
            {
                int sum = 0;
                int i = 0;
                foreach (char c in key)
                    sum += c * 31 ^ i++;
                return sum % tableSize;
            }
        }


        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;


            Console.WriteLine("1 - Hashing by division");
            Console.WriteLine("2 - Hashing by multiplication");
            Console.WriteLine("3 - Hashing using the string key method");
            Console.WriteLine("4 - Shutdown\n");
            while (true) 
            {
                int choice = ReadInt("Оберіть потрібну дію: ", x => x > 0 && x < 5);
                if (choice == 4)
                    return;

                int tableSize = ReadInt("\nВведіть максимальний розмір хеш ключа: ", x => x > 0);

                switch (choice)
                {
                    case 1:
                        int key1 = ReadInt("Число для шифрування шляхом розподілу: ", x => x >= 0);
                        Console.WriteLine($"Хэш-ключ: {DivisionHash(key1, tableSize)}");
                        break;
                    case 2:
                        int key2 = ReadInt("Число для шифрування методом множення: ", x => x >= 0);
                        Console.WriteLine($"Хэш-ключ: {MultiplicationHash(key2, tableSize)}");
                        break;
                    case 3:
                        string key3 = ReadString("Рядок для хешування методом малих ключів: ");
                        Console.WriteLine($"Хэш-ключ: {StringKeyHash(key3, tableSize)}");
                        break;
                }
            }
            

        }
    }
}