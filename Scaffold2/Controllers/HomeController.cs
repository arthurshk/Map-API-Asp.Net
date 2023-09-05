using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scaffold2.Models;
using System.Diagnostics;

namespace Scaffold2.Controllers
{
    public class HomeController : Controller
    {
        public readonly MapDBContext db;
        public HomeController(MapDBContext mapDBContext)
        {
            db = mapDBContext;
        }
        [Authorize]
        [HttpGet("/map/markers")]
        public IActionResult Markers()
        {
            return Ok(db.News.ToList());
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}