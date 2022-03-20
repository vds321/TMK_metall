using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Context
{
    public partial class TmkDB : DbContext
    {
        public TmkDB(DbContextOptions<TmkDB> options) : base(options) { }

        public DbSet<Tube> Tubes { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<SteelMark> SteelMarks { get; set; }
    }
}
