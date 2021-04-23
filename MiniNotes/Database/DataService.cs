using MiniNotes_TodoList.Data.Database;

namespace MiniNotes.Database
{
    public class DataService
    {
        private readonly DatabaseContext _dbContext;
        public DataService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeDatabase()
        {
            _dbContext.Database.EnsureCreated();
        }
    }
}
