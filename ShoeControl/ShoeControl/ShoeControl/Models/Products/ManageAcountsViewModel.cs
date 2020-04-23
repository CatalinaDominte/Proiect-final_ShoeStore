using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoeControl.Models.Products
{
    public class ManageAcountsViewModel: LoginViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Role id")]
        public int? Role_id { get; set; }
    }
}