﻿using System;
using System.Collections.Generic;

namespace SoftUni.Models
{
    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }

        public int TownId { get; set; }

        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
