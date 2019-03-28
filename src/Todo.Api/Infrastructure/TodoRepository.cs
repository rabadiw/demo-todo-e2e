using System.Linq;

namespace Todo.Api.Infrastructure
{
  public class TodoRepository : Service.ITodoRepository
  {
    private readonly TodoDbContext _todoDbContext;

    public TodoRepository(TodoDbContext todoDbContext)
    {
      _todoDbContext = todoDbContext;
    }

    public IQueryable<Service.TodoSet> GetAll()
    {
      return _todoDbContext.Todos;
    }

    public Service.TodoSet Find(long id)
    {
      return this._todoDbContext.Todos.SingleOrDefault(t => t.ID == id);
    }
  }
}