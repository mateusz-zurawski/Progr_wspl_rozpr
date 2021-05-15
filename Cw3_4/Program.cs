using System;
using System.Threading;

namespace Cw3_4
{
    class Program
    {
        static object obj = new object();
        static int bilans = 0;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Dodaj));
            Thread t2 = new Thread(new ThreadStart(Odejmij));
            t1.Start();
            t2.Start();

            Console.ReadKey();
        }
        public static void Dodaj()
        {
            for (int i = 0; i < 20; i++)
            {
                Monitor.Enter(obj);
                bilans += 100;
                if (bilans > 0)
                    Monitor.Pulse(obj);
                Console.WriteLine("Dodaj iter {0} bilans: {1}", i, bilans);
                Monitor.Exit(obj);

            }
        }

        public static void Odejmij()
        {
            for (int i = 0; i < 20; i++)
            {
                Monitor.Enter(obj);
                if (bilans <= 0)
                    Monitor.Wait(obj);
                bilans -= 100;
                Console.WriteLine("Odejmij iter {0} bilans: {1}", i, bilans);
                Monitor.Exit(obj);

            }
        }
    }
}
