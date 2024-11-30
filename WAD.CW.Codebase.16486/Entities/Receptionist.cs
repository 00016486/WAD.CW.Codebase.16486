namespace WAD.CW.Codebase._16486
{
    public class Receptionist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Visitor> Visitors { get; set; } // Navigation property
    }
}
