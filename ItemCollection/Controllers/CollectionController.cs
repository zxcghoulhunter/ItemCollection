using ItemCollection.Data;
using ItemCollection.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ItemCollection.Controllers
{
    public class CollectionController : Controller
    {
        public ApplicationDbContext _db { get; set; }
        public readonly IWebHostEnvironment _hostEnvironment;

        public CollectionController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)

        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index(int id)
        {
            var obj = _db.Find<Collection>(id);
            var img = _db.Images.Find(obj.Id);
            if (img is null)
            {
                img = new Image();
            }

            obj.Image = img;
            var items = _db.Items.ToList();
            items = items.Where(p => p.CollectionId == obj.Id).ToList();
            obj.ItemList = items;
            var comments = _db.Comments.ToList();
            return View(obj);
        }
        [Authorize]
        public IActionResult DeleteCollection(int id)
        {
            var obj = _db.Find<Collection>(id);
            _db.Remove<Collection>(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ItemPage(int id)
        {
            var obj = _db.Find<Item>(id);          
            obj.Comments = _db.Comments.Where(p => p.ItemId == obj.Id).ToList();
            obj.ItemTags = _db.Tags.Where(p => p.ItemId == obj.Id).ToList();
            ViewBag.Fields = CheckFields(_db.Find<Collection>(obj.CollectionId));
            return View(obj);
        }
        
        public PartialViewResult GetPartial(int id)
        {
            var item = _db.Find<Item>(id);
            var comments = _db.Comments.ToList();
            return PartialView("_Partial",comments.Where(p => p.ItemId == item.Id));            
        }
        public PartialViewResult OnGetModelPartial()   
        {
            int id = 6;
            var obj = _db.Find<Item>(id);
            var comments = _db.Comments.Where(p => p.ItemId == obj.Id).ToList();
            return new PartialViewResult
            {
                ViewName = "_Partial",
                ViewData = new ViewDataDictionary<List<Comment>>(ViewData, comments)
            };
        }
        [Authorize]
        public IActionResult AddItem(int id)
        {
            var fields = new List<string>();
            var obj = _db.Find<Collection>(id);
            fields = CheckFields(obj);
            ViewBag.Fields = fields;
            return View();
        }
        public JsonResult CommentDetail()
        {
            var comments = _db.Comments.ToList();
           
            return Json(comments);
        }

        public int SaveComment(string comment, int item)
        {
            Comment obj = new Comment();
            obj.Date = DateTime.Now.ToString();
            obj.ItemId = item;
            obj.UserName = User.Identity.Name;
            obj.Description = comment;
            _db.Add<Comment>(obj);
            _db.SaveChanges();
            return 1;
        }
        public List<string> CheckFields(Collection obj)
        {
            var fields = new List<string>();
            if (!(obj.IntFieldOneName is null))
            {
                fields.Add(obj.IntFieldOneName + "(i1)");
            }
            if (!(obj.IntFieldTwoName is null))
            {
                fields.Add(obj.IntFieldTwoName + "(i2)");
            }
            if (!(obj.IntFieldThreeName is null))
            {
                fields.Add(obj.IntFieldThreeName + "(i3)");
            }
            if (!(obj.StringFieldOneName is null))
            {
                fields.Add(obj.StringFieldOneName + "(s1)");
            }
            if (!(obj.StringFieldTwoName is null))
            {
                fields.Add(obj.StringFieldTwoName + "(s2)");
            }
            if (!(obj.StringFieldThreeName is null))
            {
                fields.Add(obj.StringFieldThreeName + "(s3)");
            }
            if (!(obj.BoolFieldOneName is null))
            {
                fields.Add(obj.BoolFieldOneName + "(b1)");
            }
            if (!(obj.BoolFieldTwoName is null))
            {
                fields.Add(obj.BoolFieldTwoName + "(b2)");
            }
            if (!(obj.BoolFieldThreeName is null))
            {
                fields.Add(obj.BoolFieldThreeName + "(b3)");
            }
            return fields;
        }
        [HttpPost]
        public IActionResult AddItem(Item item, int id)
        {
            var obj = _db.Find<Collection>(id);
            
            var tags = item.Tags.Split(' ').ToList();
           
            item.Collection = obj;
            item.Id = 0;
            _db.Items.Add(item);
            
            _db.SaveChanges();
            foreach (var str in tags)
            {
                var tag = new Tag();
                
                tag.ItemId = item.Id;
                tag.TagName = str;
                _db.Tags.Add(tag);
            }
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}
