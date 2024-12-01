using WAD.CW.Codebase._16486.Data;
using WAD.CW.Codebase._16486.Interfaces;

namespace WAD.CW.Codebase._16486.Repositories
{
    public class ReceptionistRepository : GenericRepository<Receptionist>, IReceptionistRepository
    {
        public ReceptionistRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
