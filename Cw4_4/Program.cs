using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Cw4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Wypisujemy logi. Id procesu " + Process.GetCurrentProcess().Id;
            Process currentProcess = Process.GetCurrentProcess();
            string pid = currentProcess.Id.ToString();

            bool createdNew;

            Mutex mutex = new Mutex(true, "my_mutex",out createdNew);

            if (createdNew) {
                Console.WriteLine("Wypisuje");
                processTask(pid);
                mutex.ReleaseMutex();
            }
            else {
                Console.WriteLine("Czekam");
                mutex.WaitOne();
                Console.WriteLine("Wpisuje");
                processTask(pid);
                mutex.ReleaseMutex();
            }
            Console.ReadLine();
            mutex.ReleaseMutex();

            Console.ReadKey();
        }
        static void processTask(string pid) {
            using (var stream = File.Open("test.log", FileMode.Append))
            {
                for (int i = 0; i < 100; i++) {
                    DateTime localDate = DateTime.Now;
                    Byte[] info = new UTF8Encoding(true).GetBytes(i + "; Id: " + pid + " Time: " + localDate.ToString() + "\n");
                    Thread.Sleep(500);
                    Console.Write(".");
                    stream.Write(info, 0, info.Length);
                }
                System.Console.Write("\nKoniec");
            }
        }
    }
}
