using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository; // this controller will have a dependency on the FeedbackRepository
        //we inject the feedbackRepository  dependency via constructor injection into this controller;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        // GET: /<controller>/ --> [HttpGet] attribute is the default, so no needs to specify it
        public IActionResult Index()
        {
            return View();
        }

        // POST: /<controller>
        // I need to specify that this method is going to ba called when a post is being received by using an HttpPost attribute
        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddFeedback(feedback); //pass this feedback into the feedbackRepository
                return RedirectToAction("FeedbackComplete"); // I redirect the user to another action method - FeedbackComplete - that I have to create
            }
            return View(feedback); //redirect the user to the same page and pass the same data; user is going to see the page with a validation error (implemented in the view folder in order to be displayed)
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }


    }
}
