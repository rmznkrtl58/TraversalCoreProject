using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IExcelService
    {
        //Excel controllerimdaki actionları mimariye uyguluyorum
        //byte dizi türünde çağırmamın sebebi excel byte türünde desteklediği için
        //dışarıdan t parametresi alacağım 
        public byte[] GetListDestinationExcel<T>(List<T> t) where T : class;
    }
}
