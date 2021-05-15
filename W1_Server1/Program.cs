using System;
using System.ServiceModel;

namespace W7_HelloServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri adres = new Uri("http://localhost:2222/Hello");
            ServiceHost host = new ServiceHost(typeof(HelloWorld), adres);
            // punkt końcowy      <-        kontrakt           wiązanie          adres
            host.AddServiceEndpoint(typeof(IHelloWorld), new BasicHttpBinding(), adres);
            host.Open();
            Console.WriteLine("Serwer uruchomiony");
            Console.ReadKey();

        }
    }
}
