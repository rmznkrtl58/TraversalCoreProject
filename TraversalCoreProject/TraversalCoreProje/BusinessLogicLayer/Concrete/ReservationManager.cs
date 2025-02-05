using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void AddToTable(TblReservation t)
        {
            _reservationDal.Insert(t);
        }

        public void DeleteFromTable(TblReservation t)
        {
            _reservationDal.Delete(t);
        }
        //Onaylanan rezervasyon
        public List<TblReservation> GetListReservationsByActive(int id)
        {
            return _reservationDal.ListReservationByCondition(x => x.DeleteStatus == true && x.Status == "Onaylandı" && x.AppUserId == id);
        }
        //Pasif rezervasyon
        public List<TblReservation> GetListReservationsByPassive(int id)
        {
            return _reservationDal.ListReservationByCondition(x => x.DeleteStatus == true && x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id);
        }
        //Onay Bekleyen
        public List<TblReservation> GetListReservationsWaitingConfirmation(int id)
        {
            return _reservationDal.ListReservationByCondition(x => x.Status == "Onay Bekliyor" && x.AppUserId == id&&x.DeleteStatus == true);
        }

        public TblReservation TGetById(int id)
        {
           return _reservationDal.GetById(id);
        }

        public List<TblReservation> TGetListAll()
        {
            return _reservationDal.GetListAll(x=>x.DeleteStatus==true);
        }

        public void UpdateTheTable(TblReservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
