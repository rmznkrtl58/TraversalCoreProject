using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper= mapper;
        }
        public IActionResult Index()
        {   //duyurular listemde istediğim verileri görüntülemek için 
            //AnnouncementListViewModel oluşturdum sonra gerekli atamaları
            //yaparak view'de models değerlerimi çağırdım
            //List<Announcement> announcementList = _announcementService.TGetListAll();
            //List<AnnouncementListDTO>models = new List<AnnouncementListDTO>();
            //foreach(var x in announcementList)
            //{
            //    AnnouncementListDTO m= new AnnouncementListDTO();
            //    m.Title= x.Title;
            //    m.Content= x.Content;
            //    models.Add(m);
            //}

            //_mapper.Map metodu,bir nesneyi başka bir nesneye dönüştürmek için kullanılır.
             //ilerde DTO tarafına bağlayacağım
                                    //yol-hedef           //kaynak
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetListAll());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.AddToTable(new Announcement()
                {
                    AnnouncementDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                    DeleteStatus = true,
                    Content = model.Content,
                    Title = model.Title

                });
                return RedirectToAction("Index", "Announcement");    
            }
            return View(model);
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var findAnnouncement=_announcementService.TGetById(id);
            findAnnouncement.DeleteStatus = false;
            _announcementService.UpdateTheTable(findAnnouncement);
            return RedirectToAction("Index", "Announcement");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {                                    //hedef-yol              //kaynak
            var findAnnouncement = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetById(id));
            return View(findAnnouncement);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.UpdateTheTable(new Announcement()
                {
                    AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    AnnouncementId = model.AnnouncementId,
                    Content = model.Content,
                    DeleteStatus = true,
                    Title = model.Title
                });
                return RedirectToAction("Index", "Announcement");
            }
            return View(model);
        }
    }
}
