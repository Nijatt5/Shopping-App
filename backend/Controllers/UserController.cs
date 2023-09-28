using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using backend.Models;

namespace backend.Controllers
{
    public class UserController : Controller
    {
        private readonly nicatContext _sql;
        public UserController(nicatContext sql)
        {
            _sql = sql;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Insan u)
        {
            var user = _sql.Insans.SingleOrDefault(x => x.InsanName == u.InsanName && x.InsanPassword == u.InsanPassword);
            if (user != null)
            {
                List<Claim> claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user.InsanName),
                    new Claim(ClaimTypes.Sid,user.InsanId.ToString()),
                };

                var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var prins = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, prins, props).Wait();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Insan m)
        {
            _sql.Insans.Add(m);
            _sql.SaveChanges();
            return RedirectToAction("Login", "User");
        }

        public IActionResult Loglist()
        {
            ViewBag.Category = _sql.Category2s.ToList();
            ViewBag.say = _sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi").Count();
            return View(_sql.Insans.ToList());
        }

        public IActionResult LoglistRemove(int id)
        {
            var a = _sql.Courses.Where(x => x.CourseInsanId == id);
            var b = _sql.Insans.SingleOrDefault(x => x.InsanId == id);
            _sql.Courses.RemoveRange(a);
            _sql.Insans.Remove(b);
            _sql.SaveChanges();
            return RedirectToAction("Loglist","User");
        }

        public IActionResult Products(int id)
        {
            ViewBag.Category = _sql.Category2s.ToList();
            ViewBag.say = _sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi").Count();
            return View(_sql.Courses.Where(x => x.CourseInsanId == id).ToList());
        }


    }
}
