using MiniNotes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniNotes.Data.Repositories
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<Note> GetNoteById(int noteId);
        Task AddNote(Note note);
        Task UpdateNote(Note note);
        Task DeleteNote(Note note);
    }
}