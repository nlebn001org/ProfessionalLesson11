using System;
using System.Threading;

namespace ProfessionalLesson11Task1
{
    class Program
    {
        static int varint = 0;
        static object obj = new object();
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
                new Thread(Test).Start();

            Thread.Sleep(100);
            Console.WriteLine(varint);
        }

        static void Test()
        {
            lock (obj)
            {
                for (int i = 0; i < 10; i++)
                    Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()}. Varint: {++varint}");
            }

        }

    }
}
