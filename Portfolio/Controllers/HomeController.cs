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

        public async Task<PageInfo> GetMainInfo(bool ignoreProjects = false)
        {
            PageInfo info = _db.pageinfo.FirstOrDefault();

            info = info ?? new PageInfo
            {
                Id = -1,
                Title = "Programming Student",
                MainInfo = "I've been coding since 2013 where I started by writing games in Lua. I have a passion for creating robust and flexible systems to support accessibility and security. I'm excited to bring my experience from working on humble project into working on something completely new.",
                GitHub = "bizzclaw",
                LinkedIn = "jtomlinsonpdx"
            };
            if (!ignoreProjects)
            {
                info.Projects = await GitHub.GetProjects(info.GitHub, 3);
            }     
            return info;
        }

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await GetMainInfo());
        }

        public async Task<IActionResult> UpdateInfo()
        {
            return View(await GetMainInfo(true));
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
