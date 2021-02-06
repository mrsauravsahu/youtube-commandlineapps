using todos.data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using todos.dto;
using System;

namespace todos
{
  public class TodosService
  {
  private readonly TodosContext todosContext;

    public TodosService(TodosContext todosContext) => this.todosContext = todosContext;

    public async Task<IEnumerable<Todo>> GetTodosAsync() => await todosContext.Todos.ToListAsync();

    public Task<long> GetCountAsync() => todosContext.Todos.LongCountAsync();

    public async Task<Todo> CreateTodoAsync(CreateTodo todoToCreate) {
      var todoToAdd = new Todo
      {
        Id = Guid.NewGuid(),
        Title = todoToCreate.Title,
        Description = todoToCreate.Description
      };

      var addResult = await todosContext.Todos.AddAsync(todoToAdd);
      await todosContext.SaveChangesAsync();
      return addResult.Entity;
    }
  }
}