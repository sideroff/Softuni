namespace _01_Logger.Interfaces
{
    using System;

    using _01_Logger.Enums;

    public interface IFormatter
    {
        string Format(string msg, DateTime date, LogLevel level);
    }
}