using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Cw7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new BlockingCollection<int>();

            var producerTask = Task.Run(() => Produce(buffer));
            var consumeTask = Task.Run(() => Consume(buffer));

            Task.WaitAll(producerTask, consumeTask);
        }

        private static void Produce(BlockingCollection<int> buffer)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Producing {0}", i);
                Thread.Sleep(10);

                buffer.Add(i);
            }

            buffer.CompleteAdding();
        }

        private static void Consume(BlockingCollection<int> buffer)
        {
            foreach (var i in buffer.GetConsumingEnumerable())
            {
                Console.WriteLine("Consuming {0}.", i);
                Thread.Sleep(20);
            }
        }
    }
}
