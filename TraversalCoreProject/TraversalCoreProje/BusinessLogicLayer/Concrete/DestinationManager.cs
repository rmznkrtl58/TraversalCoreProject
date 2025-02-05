using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Routing.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void AddToTable(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public void DeleteFromTable(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public Destination TGetById(int id)
        {
            return _destinationDal.GetById(id);
        }

        public Destination TGetDestinationWithGuide(int id)
        {
            return _destinationDal.GetDestinationWithGuide(id);
        }

        public List<Destination> TGetLast4DestinationList()
        {
            return _destinationDal.GetLast4DestinationList();
        }

        public List<Destination> TGetListAll()
        {
          return _destinationDal.GetListAll(x=>x.Status==true);
        }

        public void UpdateTheTable(Destination t)
        {
            _destinationDal.Update(t);
        }
    }
}
