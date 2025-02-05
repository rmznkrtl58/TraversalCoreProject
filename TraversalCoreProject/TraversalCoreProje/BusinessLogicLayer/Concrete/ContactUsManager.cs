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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void AddToTable(ContactUs t)
        {
            _contactUsDal.Insert(t);
        }

        public void DeleteFromTable(ContactUs t)
        {
            throw new NotImplementedException();
        }

        public ContactUs TGetById(int id)
        {
           return _contactUsDal.GetById(id);
        }

        public List<ContactUs> TGetListAll()
        {
           return _contactUsDal.GetListAll();
        }

        public void UpdateTheTable(ContactUs t)
        {
            throw new NotImplementedException();
        }
    }
}
