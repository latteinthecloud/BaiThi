using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TH.Models;
using TH.Models;
using TH.Models.Authentication;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        QuanLySanPhamContext db = new QuanLySanPhamContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authentication]
        public IActionResult Index()
        {
            var sanpham = db.Products.ToList();
            return View(sanpham);
        }
        [Authentication]
        public IActionResult ProInfo(string ProductCode)
        {
            var sanpham = db.Products.SingleOrDefault(x => x.ProductCode == ProductCode);
            ViewBag.sanpham = sanpham;
            return View(sanpham);
        }
        [Authentication]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authentication]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
