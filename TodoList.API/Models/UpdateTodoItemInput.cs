namespace TodoList.API.Models;

public record UpdateTodoItemInput(int Id, string Title, string Description, bool IsCompleted, string CronSchedule, int Repetitions, int CategoryId);