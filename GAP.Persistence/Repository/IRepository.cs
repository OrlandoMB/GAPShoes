using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.WebApi.Persistence
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        T GetById(int id);
        void Delete(T entity);
    }
}
