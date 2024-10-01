using TodoList.Application.Repositories;
using Npgsql;
using TodoList.Domain.Entities;
using System.Data.Common;

namespace TodoList.Infrastructure.Repositories;

public class CategoryRepository(/*IConfiguration configuration*/) : ICategoryRepository
{
    private readonly string _connectionString = "Host=localhost; Database=TodoList; Username=postgres; Password=postgres";
    // private readonly string? ConnectionString = configuration.GetConnectionString("TodoListDatabase");
    private readonly string _tableName = "Category"; // TODO das hier so sinnvoll?

    public async Task<bool> AddCategory(Category category)
    {
        if (!string.IsNullOrWhiteSpace(_connectionString))
        {
            await using var dataSource = NpgsqlDataSource.Create(_connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();
            // TODO den Table Name noch ersetzen. Schein nicht so einfach zu gehen: https://stackoverflow.com/questions/37752836/postgresql-npgsql-returning-42601-syntax-error-at-or-near-1
            await using var command = new NpgsqlCommand("INSERT INTO \"Category\" (\"Name\", \"Color\") VALUES (@name, @color)", connection)
            {
                Parameters =
                {
                     new("tableName", _tableName),
                     new("name", category.Name),
                     new("color", category.Color)
                }
            };

            try
            {
                // TODO: Use number of changed rows
                await command.ExecuteNonQueryAsync();
            }
            catch (DbException dbEx)
            {
                // TODO Error loggen (An error occurred while executing the command.)
                Console.WriteLine("DB Ex");
                Console.WriteLine(dbEx.Message);
                return false;
            }
            catch (Exception ex) {
                // TODO Error loggen
                Console.WriteLine("DB Ex");
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;

        }
        // TODO Error loggen
        return false;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        List<Category> categories = [];
        if (!string.IsNullOrWhiteSpace(_connectionString))
        {
            await using var dataSource = NpgsqlDataSource.Create(_connectionString);
            await using var command = dataSource.CreateCommand("SELECT * FROM \"Category\"");
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                //TODO: Das hier vielleicht noch so machen dass ich hier keine Magic Numbers habe. ORM oder Dapper
                categories.Add(
                    new Category()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Color = reader.GetString(2)
                    });
            }
        }
        return categories;
    }

    public async Task<bool> UpdateCategory(Category category)
    {
        if (!string.IsNullOrWhiteSpace(_connectionString))
        {
            await using var dataSource = NpgsqlDataSource.Create(_connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var command = new NpgsqlCommand("UPDATE \"Category\" SET \"Name\" = @name, \"Color\" = @color WHERE \"Id\" = @id", connection)
            {
                Parameters =
                {
                     new("id", category.Id),
                     new("name", category.Name),
                     new("color", category.Color),
                }
            };
            try
            {
                // TODO: Use number of changed rows
                await command.ExecuteNonQueryAsync();
            }
            catch (DbException dbEx)
            {
                // TODO Error loggen (An error occurred while executing the command.)
                Console.WriteLine("DB Ex");
                Console.WriteLine(dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                // TODO Error loggen
                Console.WriteLine("DB Ex");
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;

        }
        return false;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        if (!string.IsNullOrWhiteSpace(_connectionString))
        {
            await using var dataSource = NpgsqlDataSource.Create(_connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var command = new NpgsqlCommand("DELETE FROM \"Category\" WHERE \"Id\" = (@id)", connection)
            {
                Parameters =
                {
                     new("id", id),
                }
            };
            try
            {
                // TODO: Use number of changed rows
                await command.ExecuteNonQueryAsync();
            }
            catch (DbException dbEx)
            {
                // TODO Error loggen (An error occurred while executing the command.)
                Console.WriteLine("DB Ex");
                Console.WriteLine(dbEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                // TODO Error loggen
                Console.WriteLine("DB Ex");
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;

        }
        return false;
    }
}
