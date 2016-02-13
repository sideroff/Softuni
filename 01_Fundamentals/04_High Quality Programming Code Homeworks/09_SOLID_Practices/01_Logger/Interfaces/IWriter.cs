namespace _01_Logger.Interfaces
{
    using System;

    using _01_Logger.Enums;

    public interface IWriter
    {
        void Write(string msg, DateTime date, LogLevel level);

        IFormatter Formatter { get; set; }

        LogLevel LogLevel { get; set; }
    }
}