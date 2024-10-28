using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TH.Models;

namespace Test.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QuanLySanPhamContext db = new QuanLySanPhamContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {

            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham()
        {
            var lstSanpham = db.Products.ToList();
            return View(lstSanpham);
        }
        [Route("themsanphammoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.CatalogId = new SelectList(db.Catalogs.ToList(), "Id", "CatalogName");
            return View();
        }
        [Route("themsanphammoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(Product sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanpham);
        }
        [Route("suasanpham")]
        [HttpGet]
        public IActionResult SuaSanPham(int id)
        {
            ViewBag.CatalogId = new SelectList(db.Catalogs.ToList(), "Id", "CatalogName");
            var sanPham = db.Products.Find(id);

            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(Product sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanpham);
        }
        [Route("xoasanpham")]
        [HttpGet]
        public IActionResult XoaSanPham(int id)
        {
            TempData["Message"] = "";
            db.Remove(db.Products.Find(id));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("danhmucsanpham");
        }



    }
}
