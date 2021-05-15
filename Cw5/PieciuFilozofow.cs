using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Cw5
{
    class PieciuFilozofow
    {
        private Semaphore[] widelce;
        private Semaphore lokaj;
        private Thread[] filozofowie;

        public PieciuFilozofow()
        {
            widelce = new Semaphore[5];

            for (int i = 0; i < 5; i++)
            {
                widelce[i] = new Semaphore(1, 1);
            }
            lokaj = new Semaphore(4, 4);
            filozofowie = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                filozofowie[i] = new Thread(new ParameterizedThreadStart(Filozof));
                filozofowie[i].Name = "Filozof " + i;
            }
        }

        public void Zacznij()
        {
            for (int i = 0; i < 5; i++)
            {
                filozofowie[i].Start(i);
            }
        }
        public void Zakoncz()
        {
            foreach (Thread t in filozofowie)
            {
                t.Interrupt();
            }
        }
        public void Filozof(object n)
        {
            try
            {
                int number = (int)n;
                Random rand = new Random();
                while (true)
                {
                    Console.WriteLine("{0} myśli", Thread.CurrentThread.Name);
                    Thread.Sleep(rand.Next(100, 500));

                    lokaj.WaitOne();
                    widelce[number].WaitOne();
                    widelce[(number + 1) % 5].WaitOne();
                    Console.WriteLine("{0} je", Thread.CurrentThread.Name);
                    Thread.Sleep(rand.Next(100, 300));
                    widelce[number].Release();
                    widelce[(number + 1) % 5].Release();
                    lokaj.Release();
                }
            }
            catch (ThreadInterruptedException)
            {

            }
        }
    }
}
