using Microsoft.AspNetCore.Mvc;

namespace PotfolioMain.Controllers;

public class Auth : Controller
{
    // GET
    public IActionResult Register()
    {
        return View();
    }
    
    public IActionResult LogIn()
    {
        return View();
    }
}