namespace TodoApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using TodoApi.Tracing;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private static readonly IList<Todo> todos = new List<Todo>
    {
        new Todo { Id = 1, Name = "Todo 1", IsComplete = false },
        new Todo { Id = 2, Name = "Todo 2", IsComplete = true },
        new Todo { Id = 3, Name = "Todo 3", IsComplete = false },
    };

    private readonly ILogger<TodoController> _logger;
    private readonly TracerFactory _tracerFactory;
    public TodoController(ILogger<TodoController> logger, TracerFactory tracerFactory)
    {
        _logger = logger;
        _tracerFactory = tracerFactory;
    }

    [HttpGet("{id}")]
    public ActionResult<Todo> Get(int id)
    {
        var tracer = _tracerFactory.GetTracer("GetTodo", "test");
        tracer.Log($"Get todo item: {id}");
        return new Todo
        {
            Id = id,
            Name = String.Empty,
            IsComplete = false
        };
    }

    [HttpGet(Name = "Todo/{id}")]
    public ActionResult<Todo> FindTodo(int id)
    {
        var tracer = _tracerFactory.GetTracer("GetTodo", "test");
        tracer.Log($"Get todo item: {id}");
        var todo = todos.FirstOrDefault(t => t.Id == id);

        if (todo is null)
        {
            tracer.Log($"Did not found todo item: {todo}");
            return NotFound();
        }
        tracer.Log($"Found todo item: {todo}");
        return todo;
    }
}
