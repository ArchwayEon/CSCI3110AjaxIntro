using Microsoft.AspNetCore.Mvc;

namespace CSCI3110AjaxIntro.Controllers;

public class JQueryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
