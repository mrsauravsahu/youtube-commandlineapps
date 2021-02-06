using Microsoft.EntityFrameworkCore;

namespace todos.data
{
  public class TodosContext: DbContext
  {
    public TodosContext(DbContextOptions<TodosContext> options) : base(options) { }

    public DbSet<Todo> Todos { get; set; }
  }
}