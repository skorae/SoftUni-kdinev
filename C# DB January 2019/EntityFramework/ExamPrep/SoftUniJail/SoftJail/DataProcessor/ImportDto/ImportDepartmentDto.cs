namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportDepartmentDto
    {
        [Required]
        [StringLength(25,MinimumLength =3)]
        public string Name { get; set; }

        [Required]
        public ImportCellDto[] Cells { get; set; }
    }
}
