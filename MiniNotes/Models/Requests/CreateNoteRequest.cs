﻿namespace MiniNotes.Models.Requests
{
    public class CreateNoteRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }
    }
}
