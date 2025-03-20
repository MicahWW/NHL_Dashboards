using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace NHL_Dashboards.Conventions;

public class CustomOperationProcessor(string ns) : IOperationProcessor
{
    private readonly string _namespace = ns;

    public bool Process(OperationProcessorContext context)
    {
        return context.ControllerType.FullName!.Contains("Controllers.Api");
    }

}