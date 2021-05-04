using System.Collections.Generic;

namespace MiniNotes.Models.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
