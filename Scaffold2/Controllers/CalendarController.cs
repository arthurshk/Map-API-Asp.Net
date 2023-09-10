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
        [HttpGet("/calendar/create")]
        public IActionResult Create(CalendarModel calendarModel)
        {
            return View(calendarModel);
        }

        [HttpPost("/calendar/create")]
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
        [HttpGet("/calendar/edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var calEvent = db.Calendar.FirstOrDefault(x => x.Id == Id);
            return View(calEvent);
        }
        [HttpPost("/calendar/edit/{Id}")]
        public IActionResult Edit(int Id, [FromBody]CalendarModel calendarModel)
        {
            var calEvent = db.Calendar.FirstOrDefault(x => x.Id == Id);
            calEvent.eventTitle = calendarModel.eventTitle;
            calEvent.eventDate = calendarModel.eventDate;
            calEvent.eventDescription = calendarModel.eventDescription;
            if (!ModelState.IsValid)
            {
                return View("Index", calendarModel);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpDelete("/calendar/delete/{Id}")]
        public IActionResult DeleteEvent(int id)
        {
            var calEvent = db.Calendar.First(x => x.Id == id);
            db.Calendar.Remove(calEvent);
            db.SaveChanges();
            return Ok(new { Ok = true });
        }
    }
}
