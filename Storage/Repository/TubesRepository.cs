using Microsoft.EntityFrameworkCore;
using Storage.Context;
using Storage.Entities;
using System.Linq;

namespace Storage.Repository
{
    public class TubesRepository : DbRepository<Tube>
    {
        public TubesRepository(TmkDB db) : base(db) { }
        public override IQueryable<Tube> Items => base.Items.Include(x => x.Bundle).Include(x => x.SteelMark);
    }
}
