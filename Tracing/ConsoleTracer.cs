namespace TodoApi.Tracing
{
    public class ConsoleTracer : ITracer
    {
        public string OperationName { get; set; }
        public string Environment { get; set; }
        public ConsoleTracer(string operationName, string environment)
        {
            this.OperationName = operationName;
            this.Environment = environment;
        }

        public void Log(string message)
        {
            Console.WriteLine($"[{Environment}] - {message}");
        }

        public void Error(string message)
        {
            Console.WriteLine($"[{Error}] - {message}");
        }
    }
}