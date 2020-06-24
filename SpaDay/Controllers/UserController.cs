using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [Route("/user/add")]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [Route("/user/add")]
        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            if (verify != newUser.Password)
            {
                ViewBag.error = "Passwords should match!";
                ViewBag.name = newUser.Name;
                ViewBag.email = newUser.Email;
                return View("Add");
            }
            else
            {
                ViewBag.user = newUser;
            }
            return View("Index");
        }
    }
}
