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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void AddToTable(Announcement t)
        {
            _announcementDal.Insert(t);
        }

        public void DeleteFromTable(Announcement t)
        {
            _announcementDal.Delete(t);
        }

        public Announcement TGetById(int id)
        {
            return _announcementDal.GetById(id);
        }

        public List<Announcement> TGetListAll()
        {
            return _announcementDal.GetListAll(x=>x.DeleteStatus==true);
        }

        public void UpdateTheTable(Announcement t)
        {
            _announcementDal.Update(t);
        }
    }
}
