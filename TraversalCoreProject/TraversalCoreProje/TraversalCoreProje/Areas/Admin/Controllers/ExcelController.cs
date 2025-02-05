using BusinessLogicLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{   //Veri tabanından dinamik olarak veri çekip excel formatına getirmek için
    //1)areas-admin-models içine bir DestinationExcelModel diye class oluşturuyorum
    //2)list türünde bir metod oluşturuyorum
    [Area("Admin")]
    public class ExcelController : Controller
    {   
        //Mimariye uygun hale getirdim busines katmanımda bir incele 
        private readonly IExcelService _excelService;
        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }
        public IActionResult Index()
        {
            return View();
        }
        //aşağısı dinamik olarak çektiğim yer
        public List<DestinationExcelModel> DestinationListExcel()
        {
            List<DestinationExcelModel> destinationExcelModel=new List<DestinationExcelModel>();
            using (var ent=new Context())
            {
                destinationExcelModel = ent.Destinations.Select(x => new DestinationExcelModel
                {
                   capacity=x.Capacity,
                   city=x.City,
                   dayNight=x.DayNight,
                   price=x.Price,
                }).ToList();
            }
            return destinationExcelModel;
        }
        public IActionResult DestinationExcelReport()
        {
            return File(_excelService.GetListDestinationExcel(DestinationListExcel()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "rotaliste.xlsx");
        }
    }
}

//using (var workBook=new XLWorkbook())
//{
//    var workSheet = workBook.Worksheets.Add("Tur Listesi");
//    //1.satırımın sütunlarını belirliyorum
//    workSheet.Cell(1, 1).Value = "Şehir";
//    workSheet.Cell(1, 2).Value = "Konaklama Süresi";
//    workSheet.Cell(1, 3).Value = "Fiyat";
//    workSheet.Cell(1, 4).Value = "Kapasite";
//    //2.satırdan başlamak için 2'ye eşitliyorum
//    int rowCount = 2;
//    foreach(var x in DestinationListExcel())
//    {
//        workSheet.Cell(rowCount, 1).Value = x.city;
//        workSheet.Cell(rowCount,2).Value= x.dayNight;
//        workSheet.Cell(rowCount,3).Value= x.price;
//        workSheet.Cell(rowCount,4).Value= x.capacity;
//        rowCount++;
//    }
//    using (var stream=new MemoryStream())
//    {
//        workBook.SaveAs(stream);
//        var content=stream.ToArray();
//        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "rotaliste.xlsx");
//    }
//}