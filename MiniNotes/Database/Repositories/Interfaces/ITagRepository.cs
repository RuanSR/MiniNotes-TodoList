using MiniNotes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniNotes.Data.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetTags();
        Task<Tag> GetTagById(int tagId);
        Task AddTag(Tag tag);
        Task UpdateTag(Tag tag);
        Task DeleteTag(Tag tag);
    }
}