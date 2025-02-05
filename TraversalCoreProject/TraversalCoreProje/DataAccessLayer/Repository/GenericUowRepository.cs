using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericUowRepository<T> : IGenericUowDal<T> where T : class
    {
        private readonly Context _context;

        public GenericUowRepository(Context context)
        {
            _context = context;
        }
        //Unit Of Workun amacı neydi işlemlerin hepsi yapılıp en son
        //save change yapılmasıydı ya bir sınıfla save change yapacaz 
        //yada metodla çağıracaz
        public void MultiUpdate(List<T> t)
        {
            _context.Set<T>().UpdateRange(t);
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
        }

        public void Insert(T t)
        {
            _context.Set<T>().Add(t);
        }

        public T GetById(int id)
        {
           return _context.Set<T>().Find(id);
        }
    }
}
