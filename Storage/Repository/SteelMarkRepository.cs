using Storage.Context;
using Storage.Entities;

namespace Storage.Repository
{
    public class SteelMarkRepository : DbRepository<SteelMark>
    {
        public SteelMarkRepository(TmkDB db) : base(db) { }
    }
}