namespace TodoList.Domain.Entities;

public class Schedule
{
    public int Id { get; set; }

    public required string CronString { get; set; }

    public required int Repetitions { get; set; }
}
