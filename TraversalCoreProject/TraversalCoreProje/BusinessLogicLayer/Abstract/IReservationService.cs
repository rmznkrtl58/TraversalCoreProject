using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
   public interface IReservationService:IGenericService<TblReservation>
    {
        public List<TblReservation> GetListReservationsWaitingConfirmation(int id);
        public List<TblReservation> GetListReservationsByActive(int id);
        public List<TblReservation> GetListReservationsByPassive(int id);
    }
}
