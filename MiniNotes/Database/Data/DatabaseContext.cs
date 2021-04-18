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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("users");
                u.HasKey(u => u.Id);
                u.Property(u => u.Id).HasColumnName("id");
                u.Property(u => u.Name).HasColumnName("name").IsRequired();
                u.Property(u => u.UserName).HasColumnName("user_name").IsRequired();
                u.Property(u => u.Email).HasColumnName("email").IsRequired();
                u.Property(u => u.Password).HasColumnName("password").IsRequired();

                u.HasMany(u => u.Notes)
                    .WithOne(n => n.User);

            });

            modelBuilder.Entity<Note>(n =>
            {
                n.ToTable("notes");
                n.HasKey(n => n.Id);
                n.Property(n => n.Id).HasColumnName("id");
                n.Property(n => n.Title).HasColumnName("title").IsRequired();
                n.Property(n => n.Description).HasColumnName("description").IsRequired();
                n.Property(n => n.Content).HasColumnName("content").IsRequired();
                n.Property(n => n.UserId).HasColumnName("user_id").IsRequired();

                n.HasMany(n => n.Tags);

            });

            modelBuilder.Entity<Tag>(t =>
            {
                t.ToTable("tags");
                t.HasKey(t => t.Id);
                t.Property(t => t.Id).HasColumnName("id");
                t.Property(t => t.Name).HasColumnName("name").IsRequired();

            });
        }


    }

}