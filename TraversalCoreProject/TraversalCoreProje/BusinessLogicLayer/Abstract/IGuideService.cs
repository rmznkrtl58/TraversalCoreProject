using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IGuideService : IGenericService<Guide>
    {
        public List<Guide> TGetLast5GuideList();
    }
}
