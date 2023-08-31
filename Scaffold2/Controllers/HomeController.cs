using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scaffold2.Models;
using System.Diagnostics;

namespace Scaffold2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        [HttpGet("/map/markers")]
        public IActionResult Markers()
        {
            return Ok(
                new List<MapMarker>() 
                    {
                        new MapMarker { title = "Marker from DB # 1", lat = "50.45", lng = "30.52" },
                        new MapMarker { title = "Marker from DB # 2", lat = "50.46", lng = "30.53" },
                        new MapMarker { title = "Marker from DB # 3", lat = "50.47", lng = "30.54" },
                }) ;
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