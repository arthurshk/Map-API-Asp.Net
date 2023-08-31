using Microsoft.AspNetCore.Mvc;
using Scaffold2.Models;

namespace Scaffold2.Controllers
{
    public class MapController : Controller
    {
        public readonly MapDBContext db;
        public MapController(MapDBContext mapDBContext)
        {
            db = mapDBContext;
        }
        [HttpGet("/map")]
        public IActionResult Index()
        {
            return View(db.News.ToList());
        }
        [HttpGet("/map/create/{lat}/{lng}")]
        public IActionResult Create(string lat, string lng)
        {
            return View(new MapMarker
            {
                lat=lat,
                lng=lng
            });
        }
        [HttpPost("/map/create")] 
        public IActionResult Create(MapMarker marker)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(marker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", marker);
        }
    }
}
