using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{   //Unit Of Work Yapımı Generic Hale Getiriyorum
    public interface IGenericUowDal<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void MultiUpdate(List<T> t);//Aynı anda birden fazla kaydı
                                    //güncellemek için kullandığım metod
        T GetById(int id);
    }
}
