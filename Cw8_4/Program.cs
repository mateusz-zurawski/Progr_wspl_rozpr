using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cw8_4
{
    class Program
    {
        static int sizeTab = 5000;
        static int[] generateIntTable()
        {
            int[] tab = new int[sizeTab];
            Random r = new Random();
            for (int i = 0; i < sizeTab; i++)
            {
                tab[i] = r.Next(9999) + 1000;
            }
            return tab;
        }

        static int get_bezkwadratowa(int[] tab) {
            bool flag = true;
            for (int i = 0; i < sizeTab; i++) {
                for (int j = 2; j < Math.Sqrt(tab[i]);j++) {
                    if (tab[i] % Math.Pow(j, 2) == 0) {
                        flag = false;
                        break;
                    }
                }
                if (flag) {
                    return tab[i];
                }
            }
            return 0;
        }

        static void Main(string[] args)
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < 10; i++) {
                list.Add(generateIntTable());
            }
            Task<int> t1 = new Task<int>(() => get_bezkwadratowa(list[0]));
            Task<int> t2 = new Task<int>(() => get_bezkwadratowa(list[1]));
            Task<int> t3 = new Task<int>(() => get_bezkwadratowa(list[2]));
            Task<int> t4 = new Task<int>(() => get_bezkwadratowa(list[3]));
            Task<int> t5 = new Task<int>(() => get_bezkwadratowa(list[4]));

            List<Task> tasks = new List<Task>() { t1, t2, t3, t4, t5 };
            tasks.ForEach(t => t.Start());

            Task.WaitAll(tasks.ToArray());
            foreach (Task<int> t in tasks.ToArray()) {
                Console.WriteLine( t.Result);
            }
            Console.ReadLine();
        }
    }
}
