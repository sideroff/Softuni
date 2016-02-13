namespace _01_Logger.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using _01_Logger.Enums;
    using _01_Logger.Interfaces;
    public class Logger : ILogger
    {
        private IList<IWriter> writers;

        public Logger(params IWriter[] writers)
        {
            this.Writers = new List<IWriter>();

            writers.ToList().ForEach(this.AddWriter);
        }

        private IEnumerable<IWriter> Writers
        {
            get
            {
                return this.writers;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("writers collection cant be null");
                }
                this.writers = (IList<IWriter>)value;
            }
        }

        public void AddWriter(IWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("cannot add null as writer");
            }
            this.writers.Add(writer);
        }

        public void Info(string msg)
        {
            this.Writers.ToList().ForEach(w => w.Write(msg, DateTime.Now, LogLevel.Info));
        }
        
        public void Warning(string msg)
        {
            this.Writers.ToList().ForEach(w => w.Write(msg, DateTime.Now, LogLevel.Warning));
        }

        public void Error(string msg)
        {
            this.Writers.ToList().ForEach(w => w.Write(msg, DateTime.Now, LogLevel.Error));
        }

        public void Critical(string msg)
        {
            this.Writers.ToList().ForEach(w => w.Write(msg, DateTime.Now, LogLevel.Critical));
        }

        public void Fatal(string msg)
        {
            this.Writers.ToList().ForEach(w => w.Write(msg, DateTime.Now, LogLevel.Fatal));
        }
    }
}