using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
    public class Inventory:ProductBase
    {
        public int ProductsId { get; set; }
        public int StoreLocation { get; set; }
        public int Category { get; set; }
        public int Suppliers { get; set; }
        public int UnitsSold { get; set; }
        public int Discount { get; set; }
        public int FinalPrice { get; set; }
       
       
    }
}
