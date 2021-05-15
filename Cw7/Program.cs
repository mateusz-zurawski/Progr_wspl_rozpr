using System;
using System.Threading;

namespace Cw7
{
    class Program
    {
        static object obiektSynchronizacjiMagazynu = new object();
        static Random r = new Random();
        static volatile bool watekProducentaAkywny = true;
        static volatile bool watekKonsumentaAktywny = true;
        static Thread watekProducenta = null;
        static Thread watekKonsumenta = null;

        const int maxCzasProdukcji = 1000;
        const int maxCzasKonsumpcji = 1000;
        const int maxCzasUruchomieniaProdukcji = 5000;
        const int maxCzasUruchomieniaKonsumpcji = 5000;

        static int pojemnoscMagazynu = 20;
        static int licznikElementowWMagazynie = 1;

        static void wyswietStanMagazynu() {
            Console.WriteLine("Liczba elementow w magazynie: " + licznikElementowWMagazynie.ToString());
        }
        static void Main(string[] args)
        {
            ThreadStart akcjaProducenta = () =>
            {
                Console.WriteLine("Wątek producenta jest uruchamiany");
                while (true)
                {
                    if (watekProducentaAkywny) {
                        Thread.Sleep(r.Next(maxCzasUruchomieniaProdukcji));
                    }
                    while (watekProducentaAkywny)
                    {

                        lock (obiektSynchronizacjiMagazynu)
                        {
                            licznikElementowWMagazynie++;
                            Console.WriteLine("Element dodany");
                        }
                        wyswietStanMagazynu();
                        if (licznikElementowWMagazynie >= pojemnoscMagazynu) {
                            watekProducentaAkywny = false;
                            Console.WriteLine("Wątek producenta został uśpiony");
                        }
                        if (!watekKonsumentaAktywny) {
                            Console.WriteLine("Wątek konsumenta jest wznawiany");
                            watekKonsumentaAktywny = true;
                        }
                        Thread.Sleep(r.Next(maxCzasProdukcji));
                    }
                }
            };

            ThreadStart akcjaKonsumenta = () =>
            {
                Console.WriteLine("Wątek konsumenta jest uruchamiany");
                while (true) {
                    if (watekKonsumentaAktywny) {
                        Thread.Sleep(r.Next(maxCzasUruchomieniaKonsumpcji));
                    }
                    while (watekKonsumentaAktywny) {
                        lock (obiektSynchronizacjiMagazynu) {
                            licznikElementowWMagazynie--;
                            Console.WriteLine("Element zebrany");
                        }
                        wyswietStanMagazynu();
                        if (licznikElementowWMagazynie <= 0) {
                            watekKonsumentaAktywny = false;
                            Console.WriteLine("Wątek konsumenta został uspiony");
                        }
                        if (!watekProducentaAkywny) {
                            Console.WriteLine("Wątek producenta jest wznawiany!");
                            watekProducentaAkywny = true;
                        
                        }
                        Thread.Sleep(r.Next(maxCzasKonsumpcji));
                    }
                }
            };

            watekProducenta = new Thread(akcjaProducenta);
            watekProducenta.IsBackground = true;
            watekProducenta.Start();
            watekKonsumenta = new Thread(akcjaKonsumenta);
            watekKonsumenta.IsBackground = true;
            watekKonsumenta.Start();

            Console.ReadLine();
            Console.WriteLine("Koniec. ");wyswietStanMagazynu();
        }
    }
}
