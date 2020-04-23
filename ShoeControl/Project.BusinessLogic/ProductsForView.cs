using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
    public class ProductsForView: Products
    {
        public string Suppliers { get; set; }
        public string Category { get; set; }
        public string StoreLocation { get; set; }
        
       
    }
}
