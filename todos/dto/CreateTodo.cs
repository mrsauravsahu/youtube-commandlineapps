namespace todos.dto
{
  public class CreateTodo
  {
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
  }
}