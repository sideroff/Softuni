namespace _01_Logger.Models.Formats
{
    using System;
    using System.Text;

    using _01_Logger.Enums;
    using _01_Logger.Interfaces;

    public class JsonFormat : IFormatter
    {
        private const string MESSAGE_KEY = "Message";
        private const string DATE_KEY = "Date";
        private const string LEVEL_KEY = "Level";

        public string Format(string msg, DateTime date, LogLevel level)
        {
            var output = new StringBuilder();

            output.AppendLine($"{MESSAGE_KEY} : {msg}");
            output.AppendLine($"{DATE_KEY} : {date}");
            output.AppendLine($"{LEVEL_KEY} : {level}");

            return output.ToString();
        }
    }
}