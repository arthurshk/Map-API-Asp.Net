using Microsoft.AspNetCore.Mvc;
using Scaffold2.Models;

namespace Scaffold2.Controllers
{
    public class CalendarController : Controller
    {
        public readonly CalendarDBContext db;
        public CalendarController(CalendarDBContext calendarDBContext)
        {
            db = calendarDBContext;
        }
        [HttpGet("/calendar")]
        public IActionResult Index()
        {
            return View(db.Calendar.ToList());
        }
        [HttpGet("calendar/create")]
        public IActionResult Create(CalendarModel calendarModel)
        {
            return View(calendarModel);
        }

        [HttpPost("calendar/create")]
        public IActionResult CreateEvent(CalendarModel calendarModel)
        {
            if (ModelState.IsValid)
            {
                db.Calendar.Add(calendarModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", calendarModel);
        }
        //[HttpDelete("calendar/delete")]
        //public IActionResult DeleteEvent(CalendarModel calendarModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Calendar.Add(calendarModel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View("Create", calendarModel);
        //}
    }
}
