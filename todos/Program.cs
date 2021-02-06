using System;
using System.Text.Json;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using todos.data;
using todos.dto;
using todos.options;

namespace todos
{
    class Program
    {
        static async Task Main(string[] args)
        {
      // data <- dbcontext <- services <- cmd/webapi/
      var optionsBuilder = new DbContextOptionsBuilder<TodosContext>();
      optionsBuilder.UseSqlite("Data Source=todos.db");

      using var todosContext = new TodosContext(optionsBuilder.Options);
      await todosContext.Database.EnsureCreatedAsync();
      var todosService = new TodosService(todosContext);

      Parser.Default.ParseArguments<ListTodosOptions, CreateTodoOptions>(args)
      .WithParsed<ListTodosOptions>(async (listOption) =>
      {
        var todos = await todosService.GetTodosAsync();
        Console.WriteLine(JsonSerializer.Serialize(todos, new JsonSerializerOptions
        {
          WriteIndented = true
        }));
      })
      .WithParsed<CreateTodoOptions>(async createTodoOption =>
      {
        var todo = new CreateTodo
      {
        Title = createTodoOption.Title,
        Description = createTodoOption.Description
      };

      var addedTodo = await todosService.CreateTodoAsync(todo);
      Console.WriteLine(JsonSerializer.Serialize(addedTodo, new JsonSerializerOptions
      {
        WriteIndented = true
      }));
      });

      // Console.WriteLine($"Number of todos = {await todosService.GetCountAsync()}");

      // var todo = new CreateTodo
      // {
      //   Title = "get groceries"
      // };

      // var addedTodo = await todosService.CreateTodoAsync(todo);
      // Console.WriteLine(JsonSerializer.Serialize(todo, new JsonSerializerOptions
      // {
      //   WriteIndented = true
      // }));

      // Console.WriteLine("All todos");
      // var todos = await todosService.GetTodosAsync();
      // Console.WriteLine(JsonSerializer.Serialize(todos, new JsonSerializerOptions
      // {
      //   WriteIndented = true
      // }));
    }
    }
}
