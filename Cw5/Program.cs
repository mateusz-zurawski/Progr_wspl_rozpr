using System;
using System.Threading;

namespace Cw5
{
    class Program
    {
        static void Main(string[] args)
        {
            PieciuFilozofow fil = new PieciuFilozofow();
            fil.Zacznij();
            Thread.Sleep(10000);
            fil.Zakoncz();
            Console.ReadKey();
        }
    }
}
