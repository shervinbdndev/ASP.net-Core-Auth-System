using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AuthSystem.Controllers;

public class HomeController : Controller {

    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(UserManager<ApplicationUser> userManager) {

        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    [Authorize]
    public IActionResult Profile() {

        var userName = User.Identity?.Name;

        return View("Profile", userName);
    }    
}
