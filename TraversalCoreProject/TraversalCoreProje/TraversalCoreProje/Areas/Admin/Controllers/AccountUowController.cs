using BusinessLogicLayer.Abstract.AbstractUnitOfWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AccountUowController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountUowController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountService.TGetById(model.SenderId);
            var valueReceiver=_accountService.TGetById(model.ReceiverId);
            //Göndericinin hesabındaki bakiye eksilip alıcının hesabındaki
            //bakiyeye geçiyor 
            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;
            List<Account>modifiedAccounts= new List<Account>()
            {   //güncellenmiş Account değerlerini liste 
                //formatında tutacak 
     
                valueSender,
                valueReceiver
                //valueSender ve valueReceiver değişkenlerimin
                //içerisinde AccounId,Name,Balance değerlerimin
                //güncellenmiş verileri bulunuyor
            };
            _accountService.TMultiUpdate(modifiedAccounts);
            return View();
        }
    }
}
