using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebApp.Controllers
{
    [Route("{controller}/{action}")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _iContactRepository;
        public ContactController(IContactRepository iContactRepository)
        {
            _iContactRepository = iContactRepository;
        }
        public IActionResult Index()
        {
            var contacts = _iContactRepository.GetAllContact();
            return View(contacts);
        }
        public IActionResult AddNewContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewContact(ContactModel model)
        {
            if (model.Id > 0)
            {
                var contactUpdate = _iContactRepository.UpdateContact(model);
                return RedirectToAction(nameof(Index), contactUpdate);
            }
            var contact = _iContactRepository.AddNewContact(model);
            return RedirectToAction(nameof(Index), contact);
        }

        [HttpGet("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _iContactRepository.DeleteContact(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public  JsonResult EditContact(int id)
        {
            var contact = _iContactRepository.GetContactById(id);
            var JsonContact = JsonConvert.SerializeObject(contact);
            return Json(JsonContact);
        }

        [HttpGet("{id}")]
        public JsonResult GetContactById(int id)
        {
            var contact = _iContactRepository.GetContactById(id);
            var JsonContact = JsonConvert.SerializeObject(contact);
            
            return Json(JsonContact);
        }
        
        public IActionResult ContactList()
        {
            return View();
        }

        public object ContactLists()
        {
            var list = _iContactRepository.GetAllContact();
            return Json(list);
        }

        //[HttpGet("search")]
        //public async Task<IActionResult> SearchContact(string term)
        //{
        //    var data = await _iContactRepository.SearchContact(term);
        //    return Ok(data);
        //}
    }

  
}
