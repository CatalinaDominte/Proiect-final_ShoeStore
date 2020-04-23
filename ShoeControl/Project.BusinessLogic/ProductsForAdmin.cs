using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
    public class ProductsForAdmin:Products
    {
        [Display(Name = "Suppliers")]
        public int SuppliersId { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Store Location")]
        public int StoreLocationId { get; set; }
        
    }
}
