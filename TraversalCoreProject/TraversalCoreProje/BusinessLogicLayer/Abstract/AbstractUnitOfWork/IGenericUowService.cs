using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract.AbstractUnitOfWork
{
    public interface IGenericUowService<T>
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TMultiUpdate(List<T> t);//Aynı anda birden fazla kaydı
                                     //güncellemek için kullandığım metod
        public T TGetById(int id);
    }
}
