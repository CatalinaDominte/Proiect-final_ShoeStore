using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoeControl.Models.Products
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }
    }
}