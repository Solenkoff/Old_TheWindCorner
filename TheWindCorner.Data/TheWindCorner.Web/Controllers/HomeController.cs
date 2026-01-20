using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheWindCorner.Data.Models.User;


namespace TheWindCorner.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> _userManager)
        {
            this.userManager = _userManager;
        }

        

        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to the TheWindCorner App";

            return View();
        }

        
    }
}
 