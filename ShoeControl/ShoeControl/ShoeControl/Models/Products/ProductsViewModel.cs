using ShoeControl.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoeControl.Models.Products
{
   
    public class ProductsBaseModel
    {
        [Display(Name = "Product id")]
        public int? ProductId { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* A valid name is required.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* A valid id is required.")]
        public string Id { get; set; }

        public string Description { get; set; }

        [Required]
        public int Stock { get; set; }

        public decimal Discount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "* A valid size is required.")]
        public string Size { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* A valid size is required.")]
        public string Colour { get; set; }
    }
    public class ProductsViewModel : ProductsBaseModel
    {


        public string Suppliers { get; set; }
        public string Category { get; set; }
        public string Store { get; set; }

    }
    public class ProductsRowModel : ProductsBaseModel
    {
        [Required]
        public int Suppliers { get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        public int Store { get; set; }

        [Required]
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }


    }
}