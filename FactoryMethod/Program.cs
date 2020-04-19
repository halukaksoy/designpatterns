using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerCreator loggerFactory = new LoggerCreator();
            List<Logger> loggerList = new List<Logger>();
            loggerList.Add(loggerFactory.CreateLogger(LogType.Database));
            loggerList.Add(loggerFactory.CreateLogger(LogType.Text));
            loggerList.Add(loggerFactory.CreateLogger(LogType.Cloud));
            foreach (var item in loggerList)
            {
                item.Configuration();
                item.WriteLog($"Date: {DateTime.Now}");
                Console.WriteLine("********************************");
            }
            Console.ReadLine();

        }
    }
    //Abstract Product
    abstract class Logger
    {
        public abstract void Configuration();
        public abstract void WriteLog(string logMessage);
    }
    //Concrete Product
    class DatabaseLogger : Logger
    {
        public override void Configuration()
        {
            Console.WriteLine($"Database Configuration Completed");
        }

        public override void WriteLog(string logMessage)
        {
            Console.WriteLine($"I'm Database Logger {logMessage}");
        }
    }
    //Concrete Product
    class TextLogger : Logger
    {
        public override void Configuration()
        {
            Console.WriteLine($"Text Configuration Completed");
        }

        public override void WriteLog(string logMessage)
        {
            Console.WriteLine($"I'm Text Logger {logMessage}");
        }
    }
    //Concrete Product
    class CloudLogger : Logger
    {
        public override void Configuration()
        {
            Console.WriteLine($"CLoud Configuration Completed");
        }

        public override void WriteLog(string logMessage)
        {
            Console.WriteLine($"I'm Cloud Logger {logMessage}");
        }
    }
    //Abstract Creator
    abstract class Creator
    {
        public abstract Logger CreateLogger(LogType logType);
    }

    //Concrete Creator
    class LoggerCreator : Creator
    {
        public override Logger CreateLogger(LogType logType)
        {
            switch (logType)
            {
                case LogType.Database:
                    return new DatabaseLogger();
                case LogType.Text:
                    return new TextLogger();
                case LogType.Cloud:
                    return new CloudLogger();
                default:
                    break;
            }
            return null;
        }

    }
    enum LogType
    {
        Database,
        Text,
        Cloud
    }
}
