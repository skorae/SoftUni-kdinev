﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SULS.Models
{
    public class Submission
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public Problem Problem { get; set; }

        public User User { get; set; }
    }
}