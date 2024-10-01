﻿using TodoList.Domain.Entities;

namespace TodoList.Application.Repositories
{
    public interface ITodoListRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<bool> AddTodoItem(TodoItem todoItem);
        Task<bool> UpdateTodoItem(TodoItem todoItem);
        Task<TodoItem> DeleteTodoItem(int id);

    }
}
