using BusinessLogicLayer.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] GetListDestinationExcel<T>(List<T> t) where T : class
        {   
            //EPPlus paketi-> busines-managenuget (exceli kullanmam için)
            ExcelPackage excel = new ExcelPackage();
            //Sayfa1 adında excel sayfası oluşturuyorum
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            //coleksiyondan yükle
            workSheet.Cells["A1"].LoadFromCollection(t,true,OfficeOpenXml.Table.TableStyles.Light7);
            return excel.GetAsByteArray();
        }
    }
}
