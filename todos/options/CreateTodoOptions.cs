using CommandLine;

namespace todos.options 
{
  [Verb("create", HelpText = "Create a new todo.")]
  public class CreateTodoOptions
  {
    [Option('t', "title", Required = true, HelpText = "the title of the todo.")]
public string Title { get; set; }

    [Option('d', "description")]
public string Description { get; set; } = string.Empty;
  }
}