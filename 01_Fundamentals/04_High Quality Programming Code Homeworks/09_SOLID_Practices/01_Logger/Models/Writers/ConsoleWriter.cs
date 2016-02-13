namespace _01_Logger.Models
{
    using System;

    using _01_Logger.Enums;
    using _01_Logger.Interfaces;

    public class ConsoleWriter : Writer
    {
        public ConsoleWriter(IFormatter formatter, LogLevel level = LogLevel.Info)
            : base(formatter, level)
        {
        }

        public override void Write(string msg, DateTime date, LogLevel level)
        {
            if (level >= this.LogLevel)
            {
                var output = this.Formatter.Format(msg, date, level);
                Console.WriteLine(output);
            }
        }
    }
}