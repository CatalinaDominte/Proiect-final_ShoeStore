using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Project.BusinessLogic
{
    public class ManageAccounts:Base
    {
     
        public string Password { get; set; }
        public int? Role_id { get; set; }
       
    }
}
