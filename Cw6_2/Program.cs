using System;
using System.Threading;

namespace Cw6_2
{
    class Program
    {
        static Thread[] t;
        static int []visit;
        static Semaphore []sale;
        //static Semaphore seans;
        static void Main(string[] args)
        {
            visit = new int[30];

            for (int i = 0; i < 30; i++) {
                visit[i] = 0;    
            }

            sale = new Semaphore[4];

            for (int i = 0; i < 4; i++)
            {
                sale[i] = new Semaphore(4,4);
            }

            t = new Thread[30];
            for (int i = 0; i < 30; i++) {
                t[i] = new Thread(new ParameterizedThreadStart(startWatch));
                t[i].Name = "Widz nr: " + i;
            }
            for (int i = 0; i < 30; i++)
            {
                t[i].Start(i);
            }
            
        }
        static void startWatch(object nrPerson) {
            int nr = (int)nrPerson;
            while (visit[nr]<4) {
                sale[visit[nr]].WaitOne();
                Console.WriteLine("Sala {0} widz: {1}", visit[nr], nrPerson);
                Thread.Sleep(1000);
                int temp = visit[nr]++;
                sale[temp].Release();
                
            }
        }
    }
}
