using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rema1000.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Postcode { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
    }
}
