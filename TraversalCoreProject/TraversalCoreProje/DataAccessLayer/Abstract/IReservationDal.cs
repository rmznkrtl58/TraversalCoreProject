using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal:IGenericDal<TblReservation>
    {
        public List<TblReservation> ListReservationByCondition(Expression<Func<TblReservation,bool>>filter);
        //public List<TblReservation> listReservationsPendingConfirmation(Expression<Func<TblReservation, bool>> filter);
    }
}
