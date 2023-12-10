using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SongDiaryV1._0.Domain;

namespace SongDiaryV1._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}