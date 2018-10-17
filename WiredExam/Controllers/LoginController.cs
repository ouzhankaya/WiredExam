using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WiredExamDomain.Models;
using WiredExamServices;
namespace WiredExam.Controllers
{
    public class LoginController : Controller
    {
        AccountServices acs = new AccountServices();
        // GET: Login
        public ActionResult Login()
        {
            ViewBag.ErrorStatus = "0";
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserProfile userProfile)
        {
            ModelState.Remove("userId");
            if (ModelState.IsValid)
            {
                var ls = acs.UserLogin(userProfile);
                if (ls != null)
                {
                    return RedirectToAction("Index", "Exam", new RouteValueDictionary(ls));

                }
                else
                {
                    ViewBag.ErrorStatus = "1";
                    return View(ls);
                }
            }
            return RedirectToAction("Index", "Exam");
        }
    }
}