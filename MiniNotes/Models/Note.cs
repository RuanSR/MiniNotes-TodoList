using System.Collections.Generic;

namespace MiniNotes_TodoList.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}