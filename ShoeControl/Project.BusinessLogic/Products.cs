using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
    public class Products:ProductBase
    {
        [Display(Name = "Model Id")]
        public string ModelId { get; set; }

        [Display(Name = "Product Description")]
        public string ProductsDescription { get; set; }

        [Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }
        public decimal Discount { get; set; }

        [Display(Name = "Final Price")]
        public decimal FinalPrice { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
    }
}
