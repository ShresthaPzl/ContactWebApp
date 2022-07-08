using ContactWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContactWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactRepository _iContactRepository;
        public HomeController(IContactRepository iContactRepository)
        {
            _iContactRepository = iContactRepository;
        }
        public IActionResult Index()
        {
            ViewBag.ContactCount = _iContactRepository.ContactCount();
            ViewBag.LastContact = _iContactRepository.LastEmployee().FirstName ;
            ViewBag.RandomContact = _iContactRepository.RandomContact().FirstName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
