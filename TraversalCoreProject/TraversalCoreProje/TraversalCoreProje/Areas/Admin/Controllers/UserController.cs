using BusinessLogicLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;
        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService= reservationService;
        }
        public IActionResult Index()
        {
            var values=_appUserService.TGetListAll();
            return View(values);
        }
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListReservationsByPassive(id);
            return View(values);
        }
    }
}
