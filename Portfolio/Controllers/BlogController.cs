using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Portfolio.Controllers
{
    public class BlogController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index(int startPage = 0)
        {
            return View(_db.blogposts.OrderByDescending(m => m.Id).Skip(startPage).Take(10));
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(BlogPost newPost)
        {
            newPost.TimeStamp();
            _db.blogposts.Add(newPost);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}