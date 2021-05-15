using System;
using System.Threading;

namespace Cw6_3
{
    class Program
    {
        static Thread[] czytelnik;
        static Semaphore[] czasopismo;
        static int []przeczytaneCzasopisma;
        static void Main(string[] args)
        {
            przeczytaneCzasopisma = new int[5];
            for (int i = 0; i < 5; i++)
            {
                przeczytaneCzasopisma[i] = 0;
            }
            czasopismo = new Semaphore[3];

            for (int i = 0; i < 3; i++)
            {
                czasopismo[i] = new Semaphore(1,1);
            }

            czytelnik = new Thread[5];
            for (int i = 0; i <5; i++)
            {
                czytelnik[i] = new Thread(new ParameterizedThreadStart(Czytaj));
                czytelnik[i].Name = "Czytelnik nr: " + i;
            }
            for (int i = 0; i < 5; i++)
            {
                czytelnik[i].Start(i);
            }
        }
        static void Czytaj(object nrCzytelnika)
        {
            int nr = (int)nrCzytelnika;
            while (przeczytaneCzasopisma[nr] < 3)
            {
                czasopismo[przeczytaneCzasopisma[nr]].WaitOne();
                Console.WriteLine("Czasopismo {0} czytelnik: {1}", przeczytaneCzasopisma[nr], nr);
                Thread.Sleep(1000);
                czasopismo[przeczytaneCzasopisma[nr]].Release();
                przeczytaneCzasopisma[nr]++;
            }

        }
    }
}
