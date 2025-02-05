using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/")]
    public class ReservationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager= userManager;
        }
        ReservationManager rm = new ReservationManager(new EfReservationDal());
        [HttpGet]
        public IActionResult NewReservation()
        {
            ViewBag.v1 = "Rezervasyonlar";
            ViewBag.v2 = "Yeni Rezervasyon";
            ViewBag.v3 = "Rezervasyonlar";
            DestinationManager dm = new DestinationManager(new EfDestinationDal());
            List<SelectListItem>destinations=(from x in dm.TGetListAll()
                                              select new SelectListItem
                                              {
                                                  Text=x.City
                                              }).ToList();
            ViewBag.d=destinations;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewReservation(TblReservation r)
        {
           
            r.Status ="Onay Bekliyor";//admin tarafına onaylanmadı olarak gelecek
            //admin onaylacak
            r.DeleteStatus = true;
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name); 
            r.AppUserId= findUser.Id;
            rm.AddToTable(r);
            return RedirectToAction("NewReservation","Reservation");
        }
        [HttpGet]
        public async Task<IActionResult> MyReservationsWaitingConfirmation()
        {
            ViewBag.v1 = "Rezervasyonlar";
            ViewBag.v2 = "Onay Bekleyen Rezervasyonlar";
            ViewBag.v3 = "Rezervasyonlar";
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            var values= rm.GetListReservationsWaitingConfirmation(id);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> MyActiveReservation()
        {
            ViewBag.v1 = "Rezervasyonlar";
            ViewBag.v2 = "Aktif Rezervasyonlar";
            ViewBag.v3 = "Rezervasyonlar";
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            var values = rm.GetListReservationsByActive(id);
            return View(values);
        }
        [HttpGet]
        public async  Task<IActionResult> MyOldReservation()
        {
            ViewBag.v1 = "Rezervasyonlar";
            ViewBag.v2 = "Geçmiş Rezervasyonlar";
            ViewBag.v3 = "Rezervasyonlar";
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            int id = findUser.Id;
            var values=rm.GetListReservationsByPassive(id);
            return View(values);
        }
    }
}
//Onay Bekliyor
//Onaylandı
//Müsteri iptal Etti
//Kontenjan Doldu
//Onaylanmadı