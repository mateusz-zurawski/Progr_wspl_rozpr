using System;
using System.Threading;

namespace Cw3_1
{
    public class Program
    {
        public static void Main()
        {
            Thread t2 = new Thread(new ParameterizedThreadStart(Obliczaj));   // definicja w¹tku
            t2.Start(ConsoleColor.White);

            Obliczaj(ConsoleColor.Red);    // Wywolanie metody odliczajacej w pierwszym watku

            Console.ReadKey();
        }

        public static void Obliczaj(object color) {
            ConsoleColor choose_color = (ConsoleColor)color;
            for (int i = 1000; i > 0; i--) {
                lock (color) {
                    Console.ForegroundColor = choose_color;
                    Console.Write(i.ToString() + " ");
                }
            }

        }

        public static void OdliczajBiale()
        {
            for (int i = 1000; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(i.ToString() + " ");
            }
        }

        public static void OdliczajCzerowone()
        {
            for (int i = 1000; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(i.ToString() + " ");
            }
        }
    }
}
