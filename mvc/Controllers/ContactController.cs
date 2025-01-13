using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers;

public class ContactController : Controller
{
    public IActionResult GetAllContact()
    {
        return View();
    }
    
    public IActionResult GetOneContact()
    {
        return View();
    }

    public IActionResult AddContact()
    {
        return View();
    }
}