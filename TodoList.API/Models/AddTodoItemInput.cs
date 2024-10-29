namespace TodoList.API.Models;

public record AddTodoItemInput(string Title, string Description, string CronSchedule, int Repetitions, int CategoryId);