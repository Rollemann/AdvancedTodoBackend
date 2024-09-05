using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Repositories;
using TodoList.Domain;
using Npgsql;

namespace TodoList.Infrastructure.Repositories
{
    internal class TodoListRepository : ITodoListRepository
    {
        public Task<bool> AddTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> DeleteTodoItem(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            throw new NotImplementedException();
        }
        
        public Task<bool> UpdateTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
