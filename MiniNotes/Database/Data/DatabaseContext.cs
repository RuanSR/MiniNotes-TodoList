using Microsoft.EntityFrameworkCore;
using MiniNotes_TodoList.Models;

namespace MiniNotes_TodoList.Data.Database
{
    public class DatabaseContext : DbContext
    {
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){ }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }

}