using RedisCaching.Infrastructure.Caching;
using RedisCaching.Models;
using System.Text.Json;

namespace RedisCaching.Infrastructure.Persistence;

public class TodoMockRepository : IRepository<Todo>
{
    private readonly List<Todo> Todos;

    private readonly ICachingService CachingService;

    public TodoMockRepository(ICachingService cachingService)
    {
        Todos = new()
        {
            new Todo(Guid.Empty, "Task1", "this is task 1", false),
            new Todo(Guid.Empty, "Task2", "this is task 2", false),
            new Todo(Guid.Empty, "Task3", "this is task 3", true),
            new Todo(Guid.Empty, "Task4", "this is task 4", false),
            new Todo(Guid.Empty, "Task5", "this is task 5", true),
        };
        CachingService = cachingService;
    }

    public async Task<Todo?> GetById(Guid id)
    {
        var cachedTodo = await CachingService.GetAsync(id.ToString());

        if (!string.IsNullOrEmpty(cachedTodo))
        {
            return JsonSerializer.Deserialize<Todo>(cachedTodo);
        }

        var todo = Todos.Find(x => x.Id == id);
        await CachingService.SetAsync(id.ToString(), JsonSerializer.Serialize(todo));

        return todo;
    }
    public async Task Add(Todo todo)
    {
        await CachingService.SetAsync(todo.Id.ToString(), JsonSerializer.Serialize(todo));
        Todos.Add(todo);
    }

    public Task<List<Todo>> GetAll()
    {
        return Task.FromResult(Todos);
    }
}