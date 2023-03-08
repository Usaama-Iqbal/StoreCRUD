using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class StoreEntity
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public string Weight { get; set; }

        public int Price { get; set; }

        public string Date { get; set; }

    }
}
