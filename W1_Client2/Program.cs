using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace W1_Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var c = new ChannelFactory<IHelloWorld>(""))
            {
                var s = c.CreateChannel();
                Console.WriteLine(s.Hello());
                Console.ReadKey();
            }

        }
    }
}
