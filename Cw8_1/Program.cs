using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cw8_1
{
    class Program
    {
        const int ileWatkow = 10;
        //static Barrier b = new Barrier(ileWatkow);
        static Barrier b = new Barrier(ileWatkow, (Barrier b)=> { Console.WriteLine(); });  // Klasa Barrier umozliwia okreslenia dzialania jakie ma byc wykonane po kazdej fazie

        static void Main(string[] args)
        {
            Action metodaWatku = () =>
            {
                for (char znak = 'A'; znak <= 'G'; znak++)
                {
                    Console.Write(znak);
                    
                    b.SignalAndWait();
                }
            };
            List<Task> lista = new List<Task>();
            for (int i = 0; i < ileWatkow; i++)
            {
                lista.Add(new Task(metodaWatku));
                //tab[i] = new Thread(metodaWatku);

            }
            lista.ForEach(t => t.Start());
            //lista.ForEach(t => t.Wait());
            Console.ReadKey();
        }
    }
}
