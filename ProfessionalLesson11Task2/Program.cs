using System;
using System.IO;
using System.Threading;

namespace ProfessionalLesson11Task2
{
    class Program
    {
        static object obj = new object();
        static void Main(string[] args)
        {
            string r1 = @"Read1.txt";
            string r2 = @"Read2.txt";
            string w = @"Write.txt";

            Thread t1 = new Thread(() => ReadWrite(r1, w));
            Thread t2 = new Thread(() => ReadWrite(r2, w));
            t1.Start();
            t2.Start();
        }

        static void ReadWrite(string readFP, string writeFP)
        {
            if (new FileInfo(readFP).Exists)
            {
                if (new FileInfo(writeFP).Exists) File.Delete(writeFP);
                
                    using (StreamReader sr = new StreamReader(readFP))
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} has opened StreamReader");
                    lock (obj)
                    {
                        using (StreamWriter sw = new StreamWriter(writeFP, true))
                        {
                            Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} has opened StreamWriter");
                            while (sr.Peek() > -1)
                            {
                                string line = sr.ReadLine();
                                Console.WriteLine($"Thread {Thread.CurrentThread.GetHashCode()} writes {line}");
                                sw.WriteLine(line);
                            }
                        }
                    }
                }
            }
        }

    }
}
