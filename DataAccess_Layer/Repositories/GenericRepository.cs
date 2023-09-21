using DataAccess_Layer.Abstract;
using DataAccess_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Repositories
{
    public  abstract class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly Context _context;


        Context c = new Context();

        public GenericRepository(Context context)
        {
            _context = context;
           
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            //c.Remove(t);
            //c.SaveChanges();
            
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            c.Add(t);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
           return c.Set<T>().Where(filter).ToList();
        }

        public void Update(T t)
        {
            c.Update(t);
            c.SaveChanges();
        }
    }
}
