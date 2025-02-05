using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticUserPdf()
        {
            //path.combine dosya veya dizin
            //yollarını birleştirmek için kullanılır.
            //directory.getcurrentdirectory->aktif dosya yolunu alır
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/"+"dosya1.pdf");
            //stream->akış dosyanın ne olacağını nereye oluşturacağını belirler
            var stream = new FileStream(path, FileMode.Create);
            //document->using itextcharp
            Document document= new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            //bir PDF belgesi oluşturmak için bir PdfWriter nesnesi
            //örneği almayı sağlar.
            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);//3 sütunlu bir tablo yapısı
            pdfPTable.AddCell("Kullanicinin Adi:");
            pdfPTable.AddCell("Kullanicinin Soyadi:");
            pdfPTable.AddCell("Kullanicinin Telefon Numarasi:");

            pdfPTable.AddCell("Ramazan");
            pdfPTable.AddCell("Kartal");
            pdfPTable.AddCell("05300211258");

            pdfPTable.AddCell("Ali");
            pdfPTable.AddCell("Sahin");
            pdfPTable.AddCell("05369524521");

            pdfPTable.AddCell("Yusuf Emir");
            pdfPTable.AddCell("Alkan");
            pdfPTable.AddCell("05052142365");

            document.Add(pdfPTable);

            document.Close();
            //actionu file olarak geriye döndürüyoruz
            //wwwroot içerisindeki PdfReport klosörüne oluşan dosya1.pdf
            //dosyasını indir
            return File("/PdfReport/dosya1.pdf","application/pdf","dosya1.pdf");
        }
    }
}
