using System;
using System.Threading.Tasks;

namespace Cw8_3
{
    class Program
    {
        static int sizeTab = 1000000;
        static int[] generateIntTable() {
            int[] tab = new int[sizeTab];
            Random r = new Random();
            for (int i = 0; i < sizeTab; i++) {
                tab[i] = r.Next(999999) + 100000;
            }
            return tab;
        }

        static string checked_palindorm(bool first, object tab) {
            int[] table = (int[])tab;
            bool flag = true;

            int iStart;
            int iEnd;

            if (first) {
                iStart = 0;
                iEnd = sizeTab / 2;
            } 
            else {
                iStart = sizeTab / 2;
                iEnd = sizeTab / 2;
            }

            for (int i = iStart; i < iEnd; i++)
            {
                //Console.WriteLine(i);
                flag = true;
                string str = table[i].ToString();
                for (int j = 0; j < str.Length / 2; j++)
                {
                    if (str[j] != str[str.Length - j - 1])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {

                    return $"Znaleziono {str} index {i}";

                }
            }
            return "Brak";
        }

        static void Main(string[] args)
        {
            int[] tab = new int[sizeTab];
            tab = generateIntTable();


            object obj = tab;
            Task<string> tBegin = new Task<string>( () => {
                return checked_palindorm(true, obj);
            });
            Task<string> tEnd = new Task<string>(() => {
                return checked_palindorm(false, obj);
            });




            Task[] taskTab = new Task[2] { tBegin,tEnd};
            taskTab[0].Start();
            taskTab[1].Start();

            int index = Task.WaitAny(taskTab);
            Task<string> ts = (Task<string>)taskTab[index];
            Console.WriteLine(ts.Result);
            Console.ReadKey();

        }
    }
}
