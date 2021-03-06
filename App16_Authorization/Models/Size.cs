﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App16_Authorization.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        public string SizeName { get; set; }
        [Required]
        public string SizeSymbol { get; set; }
        public List<Product> Products { get; set; }
    }
}
