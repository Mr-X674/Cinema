﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    internal class hall
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Hall { get; set; }
    }
}
