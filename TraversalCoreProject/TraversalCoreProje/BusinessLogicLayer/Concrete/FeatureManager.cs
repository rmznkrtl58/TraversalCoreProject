using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void AddToTable(Feature t)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromTable(Feature t)
        {
            throw new NotImplementedException();
        }

        public Feature TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feature> TGetListAll()
        {
           return _featureDal.GetListAll();
        }

        public void UpdateTheTable(Feature t)
        {
            throw new NotImplementedException();
        }
    }
}
