using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Todo.Service;

namespace Todo.Api.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class TodosController : Controller
  {
    private readonly ITodoService _todoService;
//    private readonly TodoDbContext _todoDbContext;

    public TodosController(ITodoService todoService)
    {
      _todoService = todoService;
    }

//    public TodosController(TodoDbContext todoDbContext)
//    {
//      _todoDbContext = todoDbContext;
//    }

    // GET api/todos
    [HttpGet]
    public ActionResult<IEnumerable<TodoContract>> Get()
    {
//      var results = _todoDbContext.Todos.Select(t =>
//        new TodoContract()
//        {
//          ID = t.ID,
//          IsCompleted = t.IsCompleted,
//          Title = t.Title
//        });

      var results = _todoService.GetAll()
        .SelectAs<Todo.Service.TodoSet, TodoContract>();

      return results.ToArray();
    }

    // GET api/todos/{id}
    [HttpGet("{id}")]
    public ActionResult<TodoContract> Get(long id)
    {
//      var results = _todoDbContext.Todos
//        .Where(t => t.ID == id)
//        .Select(t =>
//          new TodoContract()
//          {
//            ID = t.ID,
//            IsCompleted = t.IsCompleted,
//            Title = t.Title
//          });

      var results = _todoService
        .Find(id)
        .As<Todo.Service.TodoSet, TodoContract>();

      return results;
    }
  }

  public class TodoContract
  {
    public long ID { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
  }

  internal static class TodosMapper
  {
    public static TResult As<TSource, TResult>(
      this TSource source)
      where TSource : Todo.Service.TodoSet
      where TResult : TodoContract, new()
    {
      var results = new[] {source}
        .AsQueryable()
        .SelectAs<TSource, TResult>()
        .SingleOrDefault();

//        new TResult()
//        {
//          ID = (source as dynamic).ID ?? string.Empty,
//          IsCompleted = (source as dynamic).IsCompleted ?? false,
//          Title = (source as dynamic).Title ?? string.Empty
//        };

      return results;
    }

    public static IQueryable<TResult> SelectAs<TSource, TResult>(
      this IQueryable<TSource> source)
      where TSource : Todo.Service.TodoSet
      where TResult : TodoContract, new()
    {
      var results = source.Select(r =>
        new TResult()
        {
          ID = r.ID,
          IsCompleted = r.IsCompleted,
          Title = r.Title
        });

      return results;
    }
  }
}