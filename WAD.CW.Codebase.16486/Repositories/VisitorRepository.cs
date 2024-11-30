using Microsoft.EntityFrameworkCore;
using WAD.CW.Codebase._16486.Data;
using WAD.CW.Codebase._16486.Interfaces;

namespace WAD.CW.Codebase._16486.Repositories
{
    public class VisitorRepository : GenericRepository<Visitor>, IVisitorRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Visitor>> GetVisitorsByReceptionistIdAsync(int receptionistId)
        {
            return await _context.Visitors
                .Where(v => v.ReceptionistId == receptionistId)
                .ToListAsync();
        }
    }
}
