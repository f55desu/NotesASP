using Microsoft.EntityFrameworkCore;

namespace NotesASP
{
    public class NotesDBContext : DbContext
    {
        public NotesDBContext(DbContextOptions<NotesDBContext> options) : base(options) { }

        public DbSet<NoteDto> Notes { get; set; }
    }
}
