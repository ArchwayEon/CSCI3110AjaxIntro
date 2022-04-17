using Microsoft.AspNetCore.Mvc;

namespace CSCI3110AjaxIntro.Controllers;

public class DOMController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
