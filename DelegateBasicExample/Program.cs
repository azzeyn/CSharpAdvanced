using System;
using System.IO;

namespace DelegateBasicExample
{
    public class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();
            LogDel logDel = new LogDel(log.LogTextToScreen);

            Console.WriteLine("Please enter your name: ");

            var name = Console.ReadLine();

            logDel(name);

            LogDel logDelFile = new LogDel(log.LogTextToFile);

            logDelFile(name);

            Console.ReadKey();
        }

    }

    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }

    }


}