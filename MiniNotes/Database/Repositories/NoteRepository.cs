using Microsoft.EntityFrameworkCore;
using MiniNotes_TodoList.Data.Database;
using MiniNotes_TodoList.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniNotes_TodoList.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly DatabaseContext _dbContext;

        public NoteRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            return await _dbContext.Notes.ToListAsync();
        }

        public async Task<Note> GetNoteById(int noteId)
        {
            return await _dbContext.Notes
                .Where(n => n.Id == noteId)
                .FirstOrDefaultAsync();
        }

        public async Task AddNote(Note note)
        {
            await _dbContext.AddAsync(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNote(Note note)
        {
            _dbContext.Update(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNote(Note note)
        {
            _dbContext.Remove(note);
            await _dbContext.SaveChangesAsync();
        }
    }
}