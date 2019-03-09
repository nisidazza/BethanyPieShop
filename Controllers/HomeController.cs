using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShop.Models;
using Microsoft.Extensions.DependencyInjection;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller //HomeController is a class that inherits from the base Controller class
    {
        private Func<IPieRepository> _pieRepository;
        private IPieRepository PieRepository => _pieRepository();

        // in the constructor we initialize the pieReposirtory in this way -  _pieRepository = new MockPieRepository(); - if we don't have a dependency injection
        // the dependency injection will automatically inject an instance of the MockPieRepository here --> CONSTRUCTOR INJECTION
        public HomeController(Func<IPieRepository> pieRepository) 
        {
            _pieRepository = pieRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Pie Overview"; // ViewBag is dynamic so I can add any property I want;

            //I want to retrieve all the pies to build up that list of pies; I do that by using the injected instance of the pieRepository
            //I am going to call the GetAllPies method and I want them to be ordered by name
            var pies = PieRepository.GetAllPies().OrderBy(p => p.Name);
            //This list of pay that is currently an IOrderedEnumerable is then going to be passed to the View method
            return View(pies);
        }
    }
}
