using Storage.Context;
using Storage.Entities;

namespace Storage.Repository
{
    public class PipesRepository : DbRepository<Pipe>
    {
        public PipesRepository(TmkDB db) : base(db) { }
    }
}
