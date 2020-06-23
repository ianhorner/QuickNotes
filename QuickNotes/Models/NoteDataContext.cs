using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickNotes.Models
{
    public class NoteDataContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NoteDataContext(DbContextOptions<NoteDataContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
