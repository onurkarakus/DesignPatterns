namespace DesignPatterns.ProxyPattern
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            message = $"Logged Message [{DateTime.Now}] {message}";
            Console.WriteLine(message);
        }
    }

    public class ConsoleLoggerProxy : ILogger
    {
        private readonly int logCount;
        private readonly ConsoleLogger fileLogger;
        private List<string> logs;

        public ConsoleLoggerProxy(int logCount)
        {
            this.logCount = logCount;
            this.fileLogger = new ConsoleLogger();
            logs = new List<string>();
        }

        public void Log(string message)
        {
            logs.Add(message);

            if (logCount < logs.Count)
            {
                foreach (var log in logs)
                {
                    fileLogger.Log(log);
                }

                logs.Clear();
            }
        }
    }

    public static class LoggerExample
    {
        public static void RunSample()
        {
            var logger = new ConsoleLoggerProxy(3);

            logger.Log("First log");
            Console.WriteLine("First Log Sent");
            logger.Log("Second log");
            Console.WriteLine("Second Log Sent");
            logger.Log("Third log");
            Console.WriteLine("Third Log Sent");
            logger.Log("Fourth log");
            Console.WriteLine("Fourth Log Sent");
        }

    }
}
