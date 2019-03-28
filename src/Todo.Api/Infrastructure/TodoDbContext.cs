using Microsoft.EntityFrameworkCore;

namespace Todo.Api.Infrastructure
{
  public class TodoSet : Todo.Service.TodoSet { }

  public class TodoDbContext : DbContext
  {
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

    public DbSet<TodoSet> Todos { get; set; }
  }
}