using ItemCollection.Data;
using ItemCollection.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ApplicationDbContext _db { get; set; }
        public readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var collections = _db.Collections.ToList();
            foreach(var obj in collections)
            {
               var img = _db.Images.Find(obj.Id);
                if(img is null)
                {
                    img = new Image();
                }

                obj.Image = img;
            }
            var tags = _db.Tags.ToList();
            var fixedTags = new List<Tag>();
            for (int i =0; i<3; i++)
                {
                fixedTags.Add(tags[new Random().Next(tags.Count)]);
                }
            ViewBag.Tags = fixedTags;
            return View(collections);
        }
        public IActionResult SearchTag(string name)
        {
            var cls = new List<Collection>();
            var tag = _db.Tags.Where(p => p.TagName == name);
            var items = new List<Item>();
            foreach (var obj in tag)
            {
                items.Add(_db.Items.Find(obj.ItemId));
            }
            foreach (var obj in items)
            {
                cls.Add(_db.Collections.Find(obj.CollectionId));
            }
            return View(cls);
        }
        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var collections = _db.Collections.ToList();
            var tags = _db.Tags.ToList();
            var fixedTags = new List<Tag>();
            for (int i = 0; i < 3; i++)
            {
                fixedTags.Add(tags[new Random().Next(tags.Count)]);
            }
            ViewBag.Tags = fixedTags;
            if (!String.IsNullOrEmpty(searchString))
            {
                collections = collections.Where(s => s.Name!.Contains(searchString)).ToList();
            }
            foreach (var obj in collections)
            {
                var img = _db.Images.Find(obj.Id);
                if (img is null)
                {
                    img = new Image();
                }

                obj.Image = img;
            }
            return View(collections);
        }

        public IActionResult AccountPage()
        {
            var collections = _db.Collections.ToList();
            return View(collections);
        }



        public IActionResult Create()
        {

            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Collection obj)
        {

            string wwwPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(obj.Image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(obj.Image.ImageFile.FileName);
            obj.Image.Name = fileName;
            string path = Path.Combine(wwwPath + "/Image", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                obj.Image.ImageFile.CopyTo(fileStream);
            }
            obj.Owner = User.Identity.Name;
            _db.Collections.Add(obj);
            _db.SaveChanges();
            obj.Image.Name = fileName;
            _db.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
