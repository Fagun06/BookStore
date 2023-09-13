using Microsoft.AspNetCore.Mvc;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Controllers
{
    public class HomeController : Controller
    {
      
        public ViewResult index()
        {
            ViewData["property1"] = "Fagun";
           
            return View();

        }
        public ViewResult AboutUs()
        {
            
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }

    }
}
