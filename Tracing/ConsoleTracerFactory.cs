namespace TodoApi.Tracing;

using Microsoft.Extensions.Options;

public class ConsoleTracerFactory : TracerFactory
{
    protected override ITracer CreateTracer(string operationName, string environment)
    {
        return new ConsoleTracer(operationName, environment);
    }
}
