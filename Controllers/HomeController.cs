using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller //HomeController is a class that inherits from the base Controller class
    {
        private readonly IPieRepository _pieRepository;

        // in the constructor we initialize the pieReposirtory in this way -  _pieRepository = new MockPieRepository(); - if we don't have a dependency injection
        // the dependency injection will automatically inject an instance of the MockPieRepository here --> CONSTRUCTOR INJECTION
        public HomeController(IPieRepository pieRepository) 
        {
            _pieRepository = pieRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
