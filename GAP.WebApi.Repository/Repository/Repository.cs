using GAP.WebApi.Persistence.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly GAPShoesDbContext _context;
        private DbSet<T> _entity;

        public Repository(GAPShoesDbContext context)
        {
            this._context = context;
            _entity = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entity.Remove(entity);
        }


        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.Entry(entity).State = EntityState.Modified;
        }
        
    }
}
