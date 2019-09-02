﻿namespace Cinema.Data.Models
{
    using Cinema.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public Movie()
        {
            this.Projections = new HashSet<Projection>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength =3)]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Range(1,10)]
        public double Rating { get; set; }

        [Required]
        [StringLength(20,MinimumLength =3)]
        public string Director { get; set; }

        public ICollection<Projection> Projections { get; set; }
    }
}