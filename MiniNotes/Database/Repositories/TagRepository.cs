using Microsoft.EntityFrameworkCore;
using MiniNotes_TodoList.Data.Database;
using MiniNotes_TodoList.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniNotes_TodoList.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DatabaseContext _dbContext;

        public TagRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Tag>> GetTags()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<Tag> GetTagById(int tagId)
        {
            return await _dbContext.Tags
                .Where(t => t.Id == tagId)
                .FirstOrDefaultAsync();
        }

        public async Task AddTag(Tag tag)
        {
            await _dbContext.AddAsync(tag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTag(Tag tag)
        {
            _dbContext.Update(tag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTag(Tag tag)
        {
            _dbContext.Remove(tag);
            await _dbContext.SaveChangesAsync();
        }
    }
}