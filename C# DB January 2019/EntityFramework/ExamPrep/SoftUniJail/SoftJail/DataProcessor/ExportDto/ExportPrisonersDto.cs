namespace SoftJail.DataProcessor.ExportDto
{
    public class Rootobject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CellNumber { get; set; }
        public Officer[] Officers { get; set; }
        public decimal TotalOfficerSalary { get; set; }
    }

    public class Officer
    {
        public string OfficerName { get; set; }
        public string Department { get; set; }
    }
}

