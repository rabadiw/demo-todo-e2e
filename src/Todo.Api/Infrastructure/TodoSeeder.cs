using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Api.Infrastructure
{
  internal static class TodoSeeder
  {
    public static async void Seed(IServiceProvider serviceProvider)
    {
      // Style to enable extension
      var contextOptions = serviceProvider.GetRequiredService<DbContextOptions<TodoDbContext>>();
      using (var context = new TodoDbContext(contextOptions))
      {
        if (await context.Todos.AnyAsync())
        {
          return;
        }

        foreach (var i in Enumerable.Range(1, 10))
        {
          await context.Todos.AddAsync(
            new TodoSet {ID = i, Title = $"Todo item {i}", IsCompleted = false}
          );
        }

        await context.SaveChangesAsync();
      }
    }
  }
}