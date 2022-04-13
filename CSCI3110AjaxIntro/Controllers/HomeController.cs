using CSCI3110AjaxIntro.Models;
using CSCI3110AjaxIntro.Models.Entities;
using CSCI3110AjaxIntro.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSCI3110AjaxIntro.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserRepository _userRepo;
    private readonly Random _random = new();
    public HomeController(IUserRepository userRepo, ILogger<HomeController> logger)
    {
        _logger = logger;
        _userRepo = userRepo;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> GetRandomNumbers()
    {
        var numbers = await GenerateNumbersAsync(20);
        return Json(numbers);
    }

    private Task<int[]> GenerateNumbersAsync(int amount)
    {
        int[] numbers = new int[amount];
        // Launch as a thread
        return Task.Run(() => {
            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = _random.Next(100) + 1;
            }
            Thread.Sleep(1000); // Pretend this is a long process
            return numbers;
        });
    }

    public IActionResult ListUsers()
    {
        return View(_userRepo.ReadAll());
    }

    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUserAjax(User createdUser)
    {
        var checkUser = _userRepo
            .ReadAll()
            .FirstOrDefault(u => u.UserName == createdUser.UserName);
        if (checkUser != null)
        {
            ModelState.AddModelError("", 
                "There was an error.");
            ModelState.AddModelError("UserName", 
                "This username already exists.");
        }
        if (ModelState.IsValid)
        {
            await _userRepo.CreateAsync(createdUser);
            return Json("created");
        }
        return Json(ModelState);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
