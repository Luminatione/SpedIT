﻿using Microsoft.AspNetCore.Mvc;

namespace SpedIT_Interface.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
