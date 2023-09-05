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
        [HttpGet("/map/edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var marker = db.News.FirstOrDefault(x => x.Id == Id);
            return View(marker);
        }
        [HttpPost("/map/edit/{Id}")]
        public IActionResult Edit(int Id,MapMarker marker)
        {
            var varmarker = db.News.FirstOrDefault(x => x.Id == Id);
            varmarker.title = marker.title;
            varmarker.lat = marker.lat;
            varmarker.lng = marker.lng;
            if (!ModelState.IsValid)
            {
                return View("Index", marker);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost("/map/delete/{Id}")]
        public IActionResult Delete(int id)
        {
            var varmarker = db.News.First(x => x.Id == id);
            db.News.Remove(varmarker);
            db.SaveChanges();
            return Ok(new {Ok=true});
        }
    }
}
