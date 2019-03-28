using System.Collections.Generic;
using System.Linq;

namespace Todo.Service
{
  public interface ITodoService
  {
    IQueryable<TodoSet> GetAll();
    TodoSet Find(long id);
  }

  public class TodoService : ITodoService
  {
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
      _todoRepository = todoRepository;
    }

    public IQueryable<TodoSet> GetAll()
    {
      return _todoRepository.GetAll();
    }

    public TodoSet Find(long id)
    {
      return _todoRepository.Find(id);
    }
  }

  public interface ITodoRepository
  {
    IQueryable<TodoSet> GetAll();
    TodoSet Find(long id);
  }

  public class TodoSet
  {
    public long ID { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
  }
}