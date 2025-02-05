using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.k = "İletişim";
            ViewBag.k2 = "Bize Ulaşın";
            ViewBag.k3 = "İletişim";
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDTO model)
        {
            if (ModelState.IsValid)
            {
            _contactUsService.AddToTable(new ContactUs()
            {
                Mail = model.Mail,
                MessageContent = model.MessageContent,
                MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                Name = model.Name,
                Subject = model.Subject
            });
            return RedirectToAction("Index","Default");
            }
            return View(model);
        }
    }
}
