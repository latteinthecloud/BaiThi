using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TH.Models;

namespace TH.Controllers
{
    public class HomeAccessController : Controller
    {
        QuanLySanPhamContext db = new QuanLySanPhamContext();
        [HttpGet]

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("username") == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]

        public IActionResult Login(Account acc)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                var u = db.Accounts.Where(x => x.Username.Equals(acc.Username) && x.Password.Equals(acc.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
               
                var existingUser = db.Accounts.FirstOrDefault(x => x.Username == acc.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại.");
                    return View(acc);
                }

                acc.Role = "1";
                db.Accounts.Add(acc);
                db.SaveChanges();

               
                HttpContext.Session.SetString("Username", acc.Username);
                return RedirectToAction(".");
            }
            return View(acc);
        }
    }
}
