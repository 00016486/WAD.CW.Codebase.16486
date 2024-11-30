namespace WAD.CW.Codebase._16486.Interfaces
{
    public interface IVisitorRepository : IGenericRepository<Visitor>
    {
        // Add additional Visitor-specific methods if needed
        Task<IEnumerable<Visitor>> GetVisitorsByReceptionistIdAsync(int receptionistId);
    }
}
