using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using W7_HelloServer;

namespace W1_Client1
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri adres = new Uri("http://localhost:2222/Hello");
            using (var c = new ChannelFactory<IHelloWorld>(
              new BasicHttpBinding(),
              new EndpointAddress(adres)))
            {
                var s = c.CreateChannel();
                Console.WriteLine(s.Hello());
                Console.ReadKey();
            }

        }
    }
}
