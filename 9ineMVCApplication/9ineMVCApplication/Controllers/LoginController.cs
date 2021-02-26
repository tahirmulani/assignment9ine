using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _9ineMVCApplication.Models;

namespace _9ineMVCApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View(new StudentModel());
        }
        [HttpPost]
        public ActionResult SignIn(string username, string password) {
            return RedirectToAction("Index", "Student");
        }
    }
}