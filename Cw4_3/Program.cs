using System;
using System.Threading;

namespace Cw4_3
{
    class Program
    {
        static object obj = new object();
        static String wiadomosc = "";
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Czytaj));
            Thread t2 = new Thread(new ThreadStart(Pisz));
            t1.Start();
            t2.Start();

            Console.ReadKey();
        }
        public static void Czytaj()
        {
            Monitor.Enter(obj);
            if (wiadomosc == "")
            {
                Console.WriteLine("Wątek czytający: brak wiadomosci");
                Monitor.Wait(obj);
            }
            Console.WriteLine("Wątek czytający: {0}", wiadomosc);
            Monitor.Exit(obj);
        }
        public static void Pisz()
        {
            Monitor.Enter(obj);
            if (wiadomosc == "")
            {
                wiadomosc = "Pozdrawiam !";
                Console.WriteLine("Wątek piszący Wiadomość została posłana");
                Monitor.Pulse(obj);
            }
            Monitor.Exit(obj);

        }
    }
}
