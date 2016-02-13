namespace _01_Logger.Interfaces
{
    public interface ILogger
    {
        void Info(string msg);

        void Warning(string msg);

        void Error(string msg);

        void Critical(string msg);

        void Fatal(string msg);
    }
}