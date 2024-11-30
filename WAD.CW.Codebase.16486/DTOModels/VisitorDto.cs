namespace WAD.CW.Codebase._16486.DTOModels
{
    public class VisitorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime VisitDate { get; set; }
        public int ReceptionistId { get; set; }
        public string ReceptionistName { get; set; } // Derived field for display
    }
}
