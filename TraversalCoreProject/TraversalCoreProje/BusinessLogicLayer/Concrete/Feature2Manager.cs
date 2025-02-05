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
    public class Feature2Manager : IFeature2Service
    {
        IFeature2Dal _feature2Dal;

        public Feature2Manager(IFeature2Dal feature2Dal)
        {
            _feature2Dal = feature2Dal;
        }

        public void AddToTable(Feature2 t)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromTable(Feature2 t)
        {
            throw new NotImplementedException();
        }

        public Feature2 TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feature2> TGetListAll()
        {
           return _feature2Dal.GetListAll();
        }

        public void UpdateTheTable(Feature2 t)
        {
            throw new NotImplementedException();
        }
    }
}
