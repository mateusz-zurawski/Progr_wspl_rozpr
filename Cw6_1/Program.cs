using System;
using System.Threading;

namespace Cw6_1
{
    class Program
    {
        static string[] pytania = { "pyt1", "pyt2", "pyt3", "pyt4" };
        static string[] odpowiedzi = { "odp1", "odp2", "odp3", "odp4" };
        static Semaphore gra;
        static int ask = -1;
        static object obj = new object();
        static void Main(string[] args)
        {
            gra = new Semaphore(1, 1);
            Thread t1 = new Thread(new ThreadStart(Pytaj));
            Thread t2 = new Thread(new ThreadStart(Odpowiadaj));
            t1.Start();
            t2.Start();
            Thread.Sleep(10000);
        }
        static void Pytaj()
        {
            Random rand = new Random();
            while (true)
            {
                //New
                Monitor.Enter(obj);
                if (ask != -1) {
                    Console.WriteLine("Czekam na odp");
                    Monitor.Wait(obj);
                }
                int nr = rand.Next(0, 4);
                Console.WriteLine(pytania[nr]);
                ask = nr;
                Thread.Sleep(500);
                //gra.WaitOne();
                Monitor.Pulse(obj);
                Monitor.Exit(obj);


            }
        }
        static void Odpowiadaj()
        {
            while (true)
            {
                Monitor.Enter(obj);
                if (ask == -1)
                {
                    Console.WriteLine("Czekam na pytanie");
                    Monitor.Wait(obj);
                }

                Console.WriteLine(odpowiedzi[ask]);
                ask = -1;
                Thread.Sleep(500);
                //gra.Release();
                Monitor.Pulse(obj);
                Monitor.Exit(obj);
            }
        }
    }
}
