namespace _01_Logger
{
    using System;

    using _01_Logger.Enums;
    using _01_Logger.Models;
    using _01_Logger.Models.Formats;

    class Program
    {
        static void Main()
        {
            string path = "../../output.txt";

            var xml = new XmlFormat();
            var json = new JsonFormat();

            var consoleWriter = new ConsoleWriter(xml);
            var fileWriter = new FileWriter(json, path, LogLevel.Error);

            //logger can be initialized with different number of writers
            var logger = new Logger(consoleWriter, fileWriter);

            logger.Info("Message with level Info");
            logger.Warning("Message with level Warning");
            logger.Error("Message with level Error");
            logger.Critical("Message with level Critical");
            logger.Fatal("Message with level Fatal");

            Console.WriteLine("There should be a file named output.txt where all the json errors where logLevel >= Error went.");
        }
    }
}
