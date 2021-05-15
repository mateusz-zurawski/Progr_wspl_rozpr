using System;
using System.IO;
using System.Threading;

namespace Cw3_5
{
    class Program
    {
        static int counter = 0;
        static void Main(string[] args)
        {
            // Watki dodatkowe
            Thread t1 = new Thread(new ThreadStart(Liczby.test1));
            t1.Start();
            t1.IsBackground = true;
            Thread t2 = new Thread(new ThreadStart(Liczby.test2));
            t2.IsBackground = true;
            t2.Start();
            
            

            // Watek glowny
            Console.CursorVisible = false;
            Console.Title = "Szukam liczb doskonalych";

            while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

        }
        public static bool check_number_is_perfect(int number) {
            int n;
            int suma = 0;
            n = number;

            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    suma = suma + i;
                    if (suma == n)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static void test1() {
            using (var reader = new StreamReader(@"C:\Users\Dell\Desktop\ProgWspRozp\ProgWspRozCw\Cw3_5\liczby.csv"))
            {
                while (!reader.EndOfStream)
                {
                    ++counter;
                    var line = reader.ReadLine();
                    int liczba = Convert.ToInt32(line);
                    if (check_number_is_perfect(liczba)) {
                        Console.WriteLine("Liczba doskonala: {0} pozycja: {1}",liczba,counter);
                    }
                }
            }
        }
        public static void test2() { 
            Console.WriteLine("Postęp {0}",counter); 
        }
    }
}
