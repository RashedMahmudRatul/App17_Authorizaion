using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App16_Authorization.Models
{
    public class Color
    {
        public int Id { get; set; }
        [Required]
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public List<Product> Products { get; set; }
    }
}
