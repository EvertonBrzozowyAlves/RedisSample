namespace RedisCaching.Models;

public class Todo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }

    public Todo(Guid id, string name, string description, bool isDone)
    {
        Id = id;
        Name = name;
        Description = description;
        IsDone = isDone;
    }
}