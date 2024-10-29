namespace TodoList.Domain.Entities;
public class TodoItem
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsCompleted { get; set; }

    public required string CronSchedule { get; set; }

    public required int Repetitions { get; set; }

    public Category Category { get; set; }

    public int CategoryId { get; set; }
}