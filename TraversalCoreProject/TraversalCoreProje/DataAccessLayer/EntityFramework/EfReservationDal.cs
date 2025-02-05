using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<TblReservation>, IReservationDal
    {
        public List<TblReservation> ListReservationByCondition(Expression<Func<TblReservation, bool>> filter)
        {
            using (var ent = new Context())
            {
                return ent.TblReservations.Include(x => x.Destination).Where(filter).ToList();
            }
        }

        
    }
}
