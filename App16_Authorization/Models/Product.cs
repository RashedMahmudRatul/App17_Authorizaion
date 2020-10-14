using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App16_Authorization.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
    }
}
