using Microsoft.EntityFrameworkCore;
using MiniNotes_TodoList.Models;

namespace MiniNotes_TodoList.Data.Database
{
    public class DatabaseContext : DbContext
    {
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){ }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }

}