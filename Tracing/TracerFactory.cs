namespace TodoApi.Tracing;

using Microsoft.Extensions.Options;

public enum TracerType
{
    Console,
    ConsoleWithSmiley,
}
public abstract class TracerFactory
{
    protected abstract ITracer CreateTracer(string operationName, string environment);
    public ITracer GetTracer(string operationName, string environment)
    {
        return this.CreateTracer(operationName, environment);
    }

}
