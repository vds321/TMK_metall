using Microsoft.EntityFrameworkCore;
using Storage.Context;
using Storage.Entities;
using System.Linq;

namespace Storage.Repository
{
    public class BundleRepository : DbRepository<Bundle>
    {
        public BundleRepository(TmkDB db) : base(db) { }
        public override IQueryable<Bundle> Items => base.Items.Include(item => item.Tubes);
    }
}