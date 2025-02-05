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
    public class GuideManager : IGuideService
    {
        IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void AddToTable(Guide t)
        {
            _guideDal.Insert(t);
        }

        public void DeleteFromTable(Guide t)
        {
            _guideDal.Delete(t);
        }

        public Guide TGetById(int id)
        {
            return _guideDal.GetById(id);
        }

        public List<Guide> TGetLast5GuideList()
        {
            return _guideDal.GetLast5GuideList();
        }

        public List<Guide> TGetListAll()
        {
           return _guideDal.GetListAll(x=>x.Status==true);
        }

        public void UpdateTheTable(Guide t)
        {
            _guideDal.Update(t);
        }
    }
}
