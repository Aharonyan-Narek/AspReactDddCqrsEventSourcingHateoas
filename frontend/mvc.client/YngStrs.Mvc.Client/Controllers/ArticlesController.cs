﻿using Microsoft.AspNetCore.Mvc;

namespace YngStrs.Mvc.Client.Controllers
{
    public class ArticlesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}