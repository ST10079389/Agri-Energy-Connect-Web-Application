using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ST10079389_Kaushil_Dajee_PROG7311.Models;

namespace ST10079389_Kaushil_Dajee_PROG7311.Controllers
{
    public class ProductController : Controller
    {
        private readonly AgriEnergyWebsiteDbContext _context;
        Encrypt encrypt = new Encrypt();    

        public ProductController(AgriEnergyWebsiteDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            //string? UserId = Request.Cookies["UserID"];
            int? ID = Convert.ToInt32(Request.Cookies["UserID"]);
            var agriEnergyWebsiteDbContext = _context.Products.Where(data => data.UserId == ID).Include(p => p.Category).Include(p => p.User);//used this so that only the farmer who logged in can see thier products
            return View(await agriEnergyWebsiteDbContext.ToListAsync());
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductionDate,CategoryId,UserId")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.UserId = Convert.ToInt32(Request.Cookies["UserID"]);//ensuring it belongs to a farmer
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        public  IActionResult FilterView(DateTime? start, DateTime? end, int? CategoryId, int? UserId)
        {
            if (start != null && end != null && CategoryId == 1 && UserId == 1)
            {//error handling so that if it set on nothing but to view all then it displays all the details
                List<Category> categories = _context.Categories.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");//ensuring that categories are shown by name
                List<User> user = _context.Users.Where(i => i.RoleId == 2).ToList();
                ViewBag.User = new SelectList(user, "UserId", "Name");//ensuring names are shown not ids
                var agriEnergyWebsiteDbContext = _context.Products.Where(user => user.ProductionDate >= start && user.ProductionDate <= end).Include(p => p.Category).Include(p => p.User);//linq list to show important information based on certain conditions
                return View(agriEnergyWebsiteDbContext);
            }
            else if (start != null && end != null && CategoryId > 1 && UserId > 1)
            {//will filter based on what the category or user has been selected
                List<Category> categories = _context.Categories.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                List<User> user = _context.Users.Where(i => i.RoleId == 2).ToList();
                ViewBag.User = new SelectList(user, "UserId", "Name");
                var agriEnergyWebsiteDbContext = _context.Products.Where(user => user.ProductionDate >= start && user.ProductionDate <= end && user.CategoryId == CategoryId && user.UserId == UserId).Include(p => p.Category).Include(p => p.User);
                return View(agriEnergyWebsiteDbContext);
            }
            else if(start.Equals(null) && end.Equals(null) && CategoryId > 1 && UserId > 1)
            {//will filter when user is looking for a specific product
                List<Category> categories = _context.Categories.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                List<User> user = _context.Users.Where(i => i.RoleId == 2).ToList();
                ViewBag.User = new SelectList(user, "UserId", "Name");
                var agriEnergyWebsiteDbContext = _context.Products.Where(user => user.CategoryId == CategoryId && user.UserId == UserId).Include(p => p.Category).Include(p => p.Category).Include(p => p.User);
                return View(agriEnergyWebsiteDbContext);
            }
            else if (start.Equals(null) && end.Equals(null) && CategoryId > 1 && UserId == 1)
            {//error handling when dates and categories are chosen
                List<Category> categories = _context.Categories.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                List<User> user = _context.Users.Where(i => i.RoleId == 2).ToList();
                ViewBag.User = new SelectList(user, "UserId", "Name");
                var agriEnergyWebsiteDbContext = _context.Products.Where(user => user.CategoryId == CategoryId).Include(p => p.Category).Include(p => p.Category).Include(p => p.User);
                return View(agriEnergyWebsiteDbContext);
            }
            else if (start.Equals(null) && end.Equals(null) && CategoryId == 1 && UserId > 1)
            {//error handling when the dates and user are chosen
                List<Category> categories = _context.Categories.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                List<User> user = _context.Users.Where(i => i.RoleId == 2).ToList();
                ViewBag.User = new SelectList(user, "UserId", "Name");
                var agriEnergyWebsiteDbContext = _context.Products.Where(user => user.UserId == UserId).Include(p => p.Category).Include(p => p.Category).Include(p => p.User);
                return View(agriEnergyWebsiteDbContext);
            }
            else if (start != null && end != null && CategoryId == 1 && UserId > 1)
            {//error handling for when only the user is selected
                List<Category> categories = _context.Categories.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                List<User> user = _context.Users.Where(i => i.RoleId == 2).ToList();
                ViewBag.User = new SelectList(user, "UserId", "Name");
                var agriEnergyWebsiteDbContext = _context.Products.Where(user => user.ProductionDate >= start && user.ProductionDate <= end && user.UserId == UserId).Include(p => p.Category).Include(p => p.User);
                return View(agriEnergyWebsiteDbContext);
            }
            else if (start != null && end != null && CategoryId > 1 && UserId == 1)
            {//error handling for when only the category is selected
                List<Category> categories = _context.Categories.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                List<User> user = _context.Users.Where(i => i.RoleId == 2).ToList();
                ViewBag.User = new SelectList(user, "UserId", "Name");
                var agriEnergyWebsiteDbContext = _context.Products.Where(user => user.ProductionDate >= start && user.ProductionDate <= end && user.CategoryId == CategoryId).Include(p => p.Category).Include(p => p.User);
                return View(agriEnergyWebsiteDbContext);
            }
            else
            {//if all else it will show all the neccessary information
                List<Category> categories = _context.Categories.ToList();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                List<User> user = _context.Users.Where(i => i.RoleId == 2).ToList();
                ViewBag.User = new SelectList(user, "UserId", "Name");
                var agriEnergyWebsiteDbContext = _context.Products.Include(p => p.Category).Include(p => p.User);
                return View(agriEnergyWebsiteDbContext);
            }      
        }
    }
}

