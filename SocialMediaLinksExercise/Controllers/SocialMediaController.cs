﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SocialMediaLinksExercise.Models;
using Microsoft.AspNetCore.Hosting;
namespace SocialMediaLinksExercise.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly IConfiguration _configurations;
        private readonly IWebHostEnvironment _env;
        public SocialMediaController(IConfiguration configurations, IWebHostEnvironment env)
        {
            _configurations = configurations;
            _env = env;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.env = _env.EnvironmentName;
            Links links = new Links();
            _configurations.GetSection("SocialMediaLinks").Bind(links);
            return View(links);
        }
    }
}
