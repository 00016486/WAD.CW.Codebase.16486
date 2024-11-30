namespace WAD.CW.Codebase._16486
{
    public class Visitor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime VisitDate { get; set; }
        public int ReceptionistId { get; set; } // Foreign key
        public Receptionist Receptionist { get; set; } // Navigation property
    }
}
