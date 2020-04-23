using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
    public interface IProductsRepository
    {
        List<ProductsForView> GetAll();
    }
}
