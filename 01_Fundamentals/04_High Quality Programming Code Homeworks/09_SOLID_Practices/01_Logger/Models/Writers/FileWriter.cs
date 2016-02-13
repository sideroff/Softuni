namespace _01_Logger.Models
{
    using System;
    using System.IO;

    using _01_Logger.Enums;
    using _01_Logger.Interfaces;
    public class FileWriter : Writer
    {
        private string path;

        public FileWriter(
            IFormatter formatter,
            string path,
            LogLevel level = LogLevel.Info)
            : base(formatter,level)
        {
            this.Path = path;
        }

        public override void Write(string msg, DateTime date, LogLevel level)
        {
            if (level >= this.LogLevel)
            {
                var output = this.Formatter.Format(msg, date, level);
                using (StreamWriter writer = new StreamWriter(this.path, true))
                {
                    writer.WriteLine(output);
                }
            }
        }
        
        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("File path cannot be null");
                }
                this.path = value;
            }
        }
    }
}