using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
    public interface IProductsCreateRepository:IBaseRepository<ProductsForAdmin, int>
    {
        

        //void Update(int id, T item);
    }
}
