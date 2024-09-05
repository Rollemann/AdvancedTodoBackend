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
    public class CategoryRepository : ICategoryRepository
    {
        private const string CONNECTIONSTRING = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";
        public async Task<bool> AddCategory(Category category)
        {
            await using var dataSource = NpgsqlDataSource.Create(CONNECTIONSTRING);
            await using var command = dataSource.CreateCommand("SELECT some_field FROM some_table");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Console.WriteLine(reader.GetString(0));
            }

            throw new NotImplementedException();
        }

        public async Task<Category> DeleteCategory(string id)
        {
            await using var dataSource = NpgsqlDataSource.Create(CONNECTIONSTRING);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            await using var dataSource = NpgsqlDataSource.Create(CONNECTIONSTRING);
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            await using var dataSource = NpgsqlDataSource.Create(CONNECTIONSTRING);
            throw new NotImplementedException();
        }
    }
}
