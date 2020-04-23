using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic
{
    public interface IBaseRepository<T, U> where T: Base where U: struct
    {
        List<T> GetAll();
        T GetDetails(int id);
        U Create(T entity);
        U Delete(int id);
        U Update(T entity, int id);

       
    }
}
