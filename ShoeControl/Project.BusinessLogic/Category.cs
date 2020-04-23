using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
    public class Category:Base
    {
        [Display(Name = "Description")]
        public string CategoryDescription { get; set; }
    }
}
