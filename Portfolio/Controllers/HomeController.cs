using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/

        public PageInfo GetMainInfo()
        {
            PageInfo info = _db.pageinfo.FirstOrDefault();

            info = info ?? new PageInfo
            {
                Id = -1,
                Title = "Current Position",
                MainInfo = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            };
            return info;
        }

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {


            return View(GetMainInfo());
        }

        public IActionResult UpdateInfo()
        {
            return View(GetMainInfo());
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdateInfo(PageInfo info)
        {

            if (info.Id == -1)
            {
                info.Id = 1;
                _db.pageinfo.Add(info);
            }
            else
            {
                _db.Entry(info).State = EntityState.Modified;
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
