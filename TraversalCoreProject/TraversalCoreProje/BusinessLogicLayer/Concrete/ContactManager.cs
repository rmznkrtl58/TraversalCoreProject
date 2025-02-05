using BusinessLogicLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class ContactManager : IContactService
    {
        public void AddToTable(Contact t)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromTable(Contact t)
        {
            throw new NotImplementedException();
        }

        public Contact TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void UpdateTheTable(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
