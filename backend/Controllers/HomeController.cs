using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using backend.Models;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly nicatContext _sql;
        public HomeController(nicatContext sql)
        {
            _sql = sql;
        }

        public IActionResult Index()
        {
            ViewBag.say = _sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi").Count();
            ViewBag.Category = _sql.Category2s.ToList();
            return View(_sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi").ToList());
        }

        public IActionResult Unconfirmed()
        {
            ViewBag.say = _sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi").Count();
            ViewBag.Category = _sql.Category2s.ToList();
            return View(_sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlenmedi").ToList());
        }

        public IActionResult Confirm(int id)
        {
            _sql.Courses.SingleOrDefault(x => x.CourseId == id).CourseConfirm = "Tesdiqlendi";
            _sql.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            ViewBag.say = _sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi").Count();
            ViewBag.Category = new SelectList(_sql.Category2s.ToList(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course c, IFormFile Sekil)
        {
            if (Sekil != null)
            {
                string random = Path.GetRandomFileName() + Path.GetExtension(Sekil.FileName);
                c.CourseImg = random;
                using (FileStream s = new FileStream("wwwroot/img/" + random, FileMode.Create))
                {
                    Sekil.CopyTo(s);
                }
            ViewBag.say = _sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi").Count();
            c.CourseConfirm = "Tesdiqlenmedi";
            c.CourseInsanId = int.Parse(User.FindFirst(ClaimTypes.Sid).Value);
            _sql.Courses.Add(c);
            _sql.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult ReadMore(int id)
        {
            ViewBag.Category = _sql.Category2s.ToList();
            ViewBag.say = _sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi").Count();
            var a = _sql.Courses.SingleOrDefault(x => x.CourseId == id);
            return View(a);
        }

        public IActionResult Remove(int id)
        {
            var a = _sql.Courses.SingleOrDefault(x => x.CourseId == id);
            _sql.Courses.Remove(a);
            _sql.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.say = _sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi").Count();
            ViewBag.Category = new SelectList(_sql.Category2s.ToList(), "CategoryId", "CategoryName");
            var a = _sql.Courses.SingleOrDefault(x => x.CourseId == id);
            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(Course c, int id, IFormFile Sekil)
        {
            var a = _sql.Courses.SingleOrDefault(x => x.CourseId == id);
            if (Sekil != null)
            {
                using Stream s = new FileStream("wwwroot/img/" + a.CourseImg, FileMode.Create);
                Sekil.CopyTo(s);
            }
            a.CourseCategoryId = c.CourseCategoryId;
            a.CourseName = c.CourseName;
            a.CourseDescription = c.CourseDescription;
            _sql.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Filter(int minprice, int maxprice)
        {
            ViewBag.Category = _sql.Category2s.ToList();

            var data = _sql.Courses.Where(x => x.CourseConfirm == "Tesdiqlendi");
            if ( minprice != null)
            {
                data = data.Where(x => x.CoursePrice >= minprice);
            }

            if (maxprice != null)
            {
                data = data.Where(x => x.CoursePrice <= maxprice);
            }
            return View(data.ToList());
        }
    }
}

