using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Context
{
    public partial class TmkDB : DbContext
    {
        public TmkDB(DbContextOptions<TmkDB> options) : base(options) { }

        public DbSet<Pipe> Pipes { get; set; }
        public DbSet<Bundle> Packages { get; set; }
        public DbSet<SteelMark> SteelMarks { get; set; }
    }
}
