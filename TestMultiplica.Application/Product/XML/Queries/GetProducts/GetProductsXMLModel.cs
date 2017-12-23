using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultiplica.Application.Product.XML.Queries.GetProducts
{
    public class GetProductsXMLModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Stock { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
