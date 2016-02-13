namespace _01_Logger.Models.Formats
{
    using System;
    using System.Text;

    using _01_Logger.Enums;

    using IFormatter = _01_Logger.Interfaces.IFormatter;

    public class XmlFormat : IFormatter
    {
        private const string LOG_OPPENING_TAG = "<log>";
        private const string LOG_CLOSING_TAG = "</log>";
        private const string DATE_OPPENING_TAG = "<date>";
        private const string DATE_CLOSING_TAG = "</date>";
        private const string LEVEL_OPPENING_TAG = "<level>";
        private const string LEVEL_CLOSING_TAG = "</level>";
        private const string MESSAGE_OPPENING_TAG = "<message>";
        private const string MESSAGE_CLOSING_TAG = "</message>";

        public string Format(string msg, DateTime date, LogLevel level)
        {
            var output = new StringBuilder();

            output.AppendLine($"{LOG_OPPENING_TAG}");
            output.AppendLine($"/t{DATE_OPPENING_TAG}{date}{DATE_CLOSING_TAG}");
            output.AppendLine($"/t{LEVEL_OPPENING_TAG}{level}{LEVEL_CLOSING_TAG}");
            output.AppendLine($"/t{MESSAGE_OPPENING_TAG}{msg}{MESSAGE_CLOSING_TAG}");
            output.AppendLine($"{LOG_CLOSING_TAG}");

            return output.ToString();
        }
    }
}