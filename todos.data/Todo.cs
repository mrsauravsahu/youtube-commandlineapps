using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace todos.data
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }

    [NotMapped]
    public bool IsComplete => CompletedAt is not null;
  }
}
