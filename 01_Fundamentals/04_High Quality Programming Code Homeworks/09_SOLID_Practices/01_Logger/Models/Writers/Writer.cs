namespace _01_Logger.Models
{
    using System;

    using _01_Logger.Enums;
    using _01_Logger.Interfaces;
    public abstract class Writer : IWriter
    {
        private IFormatter formatter;

        protected Writer(IFormatter formatter, LogLevel logLevel = LogLevel.Info)
        {
            this.Formatter = formatter;
            this.LogLevel = logLevel;
        }
        public virtual void Write(string msg, DateTime date, LogLevel level)
        {
            throw new NotImplementedException();
        }

        public IFormatter Formatter
        {
            get
            {
                return this.formatter;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Format cannot be null");
                }
                this.formatter = value;
            }
        }

        public LogLevel LogLevel { get; set; }
    }
}