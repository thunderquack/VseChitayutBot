using System;
using System.IO;
using System.Threading;

namespace VseChitayutBot
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = File.ReadAllText("apikey.txt");
            Bot bot = new Bot(apiKey);
            bot.StartReceiving();
            while (!bot.Exit)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
