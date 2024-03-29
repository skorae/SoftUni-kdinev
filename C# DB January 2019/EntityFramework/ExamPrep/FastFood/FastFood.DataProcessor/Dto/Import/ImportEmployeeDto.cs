﻿namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    public class ImportEmployeeDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(15,80)]
        public int Age { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Position { get; set; }
    }
}
