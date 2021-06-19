using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
