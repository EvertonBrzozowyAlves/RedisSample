using Microsoft.AspNetCore.Mvc;
using RedisCaching.Infrastructure.Persistence;
using RedisCaching.Models;

namespace RedisCaching.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    public TodoMockRepository TodoMockRepository { get; set; }

    public TodosController(TodoMockRepository todoMockRepository)
    {
        TodoMockRepository = todoMockRepository;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddTodo([FromBody] Todo todo)
    {
        await TodoMockRepository.Add(todo);
        return Ok();
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetTodoById([FromRoute] Guid id)
    {
        return Ok(await TodoMockRepository.GetById(id));
    }
}
