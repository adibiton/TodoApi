namespace TodoApi.Tracing
{
    public interface ITracer
    {
        void Log(string message);
        void Error(string message);
    }
}