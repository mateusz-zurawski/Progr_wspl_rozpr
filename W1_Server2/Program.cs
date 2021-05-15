using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace W1_Server2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(HelloWorld));
            host.Open();
            Console.WriteLine("Serwer uruchomiony");
            Console.ReadKey();

        }
    }
}
