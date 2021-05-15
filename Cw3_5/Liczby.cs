using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Cw3_5
{
    class Liczby
    {
        static object obj = new object();
        static int counter = 0;
        static int row_nr = 2;

        public static bool check_number_is_perfect(int number)
        {
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
        public static void test1()
        {
            using (var reader = new StreamReader(@"C:\Users\Dell\Desktop\ProgWspRozp\ProgWspRozCw\Cw3_5\liczby.csv"))
            {
                while (!reader.EndOfStream)
                {
                    ++counter;
                    var line = reader.ReadLine();
                    int liczba = Convert.ToInt32(line);
                    if (check_number_is_perfect(liczba))
                    {

                        lock (obj)
                        {
                            row_nr += 2;
                            Console.SetCursorPosition(10, row_nr);
                            Console.Write("Liczba doskonala: {0} pozycja: {1}\n", liczba, counter);
                        }
                        
                    }
                }
            }
        }
        public static void test2()
        {
            while (true)
            {
                lock (obj)
                {
                    double progres = 1.0 * counter / 1000;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Postęp {0} z 100.000 {1}%", counter, progres);
                }
            }
        }
    }
}
