namespace SoftJail.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ImportPrisonersDto
    {
        [Required]
        [StringLength(maximumLength:20, MinimumLength =3)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("^The [A-Z][a-z]+$")]
        public string Nickname { get; set; }

        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        [DataType(DataType.DateTime)]
        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public ImportMailDto[] Mails { get; set; }
    }

    public class ImportMailDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z0-9 ]+ str.$")]
        public string Address { get; set; }
    }
}