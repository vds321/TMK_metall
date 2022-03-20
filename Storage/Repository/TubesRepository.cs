using Storage.Context;
using Storage.Entities;

namespace Storage.Repository
{
    public class TubesRepository : DbRepository<Tube>
    {
        public TubesRepository(TmkDB db) : base(db) { }
    }
}
