using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rema1000.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Unit { get; set; }
        public int UnitCount { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int Stock { get; set; }
        public Supplier Supplier { get; set; }
    }
}
