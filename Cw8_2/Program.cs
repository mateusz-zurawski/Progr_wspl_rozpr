using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cw8_2
{
    class Program
    {
        static Random r = new Random();

        static void waitTime(int ii,int watekNr)
        {
            for (int i = 0; i < ii; i++)
            {
                Console.WriteLine(@"Wątek {0} iteracja {1}", watekNr, i);
                Thread.Sleep(r.Next(1000) + 1000);
            }
        }
        
        static void Main(string[] args)
        {
            Action a = ( ) =>
            {
                Console.WriteLine($"{0} {1}", Task.CurrentId);
                waitTime(5,0);  
            };

            Task t1 = new Task(() => {
                waitTime(5,1);
            });

            Task t2 = new Task(() => {
                waitTime(5, 2);
            });

            Task t3 = t1.ContinueWith(a => 
            {
                waitTime(5, 3);
                Console.WriteLine("End task 1-3");
            });

            Task t4 = t2.ContinueWith(a =>
            {
                waitTime(5, 4);
                Console.WriteLine("End task 2-4");
            });
            t1.Start();
            t2.Start();

            Task.WaitAll();
            Console.ReadKey();
        }
    }
}
