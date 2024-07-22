using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST10079389_Kaushil_Dajee_PROG7311.Models;

namespace ST10079389_Kaushil_Dajee_PROG7311.Controllers
{
    public class UserController : Controller
    {
        private readonly AgriEnergyWebsiteDbContext _context;
        Encrypt encrypt = new Encrypt();

        public UserController(AgriEnergyWebsiteDbContext context)
        {
            _context = context;
        }

        // GET: User
        public IActionResult Login()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "Role1");
            return View();
        }
        [HttpPost]
        public IActionResult Login([Bind("Name,Password, RoleId")] User profile)
        {
            if (profile.Name == null || profile.Password == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid, Please enter your username or password.");//ensure none of the respected fields are blank
                return View(profile);
            }
            var user = _context.Users
           .FirstOrDefault(x => x.Name == profile.Name && x.Password == encrypt.Hash_Password(profile.Password) && x.RoleId == profile.RoleId);

            if (user != null && user.RoleId == 1) 
            {
                string username = profile.Name;
                string password = profile.Password;
                password = encrypt.Hash_Password(password);
                int UserID = encrypt.GetID(username, password);//i use it get the userid so i can set it as a cookie so anywhere in the application i can access it for when the user wants to login
                //Response.Cookies.Append("RoleID", 1.ToString());
                Response.Cookies.Append("UserID", UserID.ToString());//i use cookies because it allows me to easily access it anywhere on the websites application compared to a viewbag which only saves it temporarily for one page but with cookies it saves it throughout the web application
                return RedirectToAction("FilterView", "Product");//takes them to the home page
            }
            else if(user != null && user.RoleId == 2)
            {
                string username = profile.Name;
                string password = profile.Password;
                password = encrypt.Hash_Password(password);
                int UserID = encrypt.GetID(username, password);//i use it get the userid so i can set it as a cookie so anywhere in the application i can access it for when the user wants to login
                //Response.Cookies.Append("RoleID", 2.ToString());
                Response.Cookies.Append("UserID", UserID.ToString());//i use cookies because it allows me to easily access it anywhere on the websites application compared to a viewbag which only saves it temporarily for one page but with cookies it saves it throughout the web application
                return RedirectToAction("Index", "Product");//takes them to the home page
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid, Please enter the correct username or password.");//if they have the wrong credentials it throws a warning
                ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "Role1");
                return View(profile);
            }
        }
        // GET: Users/Create
        public IActionResult CreateFarmer()
        {
            //ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "Role1");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFarmer([Bind("UserId,Name,Password,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                user.RoleId = 2;//sets to farmer
                user.Password = encrypt.Hash_Password(user.Password);//password is hashed for security reasons
                _context.Add(user);
                await _context.SaveChangesAsync();//it is saved to the database
                int UserID = user.UserId;//i get the user id with ease
                Response.Cookies.Append("RoleID", 2.ToString());
                Response.Cookies.Append("UserID", UserID.ToString());//i use cookies because it allows me to easily access it anywhere on the websites application compared to a viewbag which only saves it temporarily for one page but with cookies it saves it throughout the web application
                return RedirectToAction("FilterView", "Product");
            }
            //ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId");
            return View(user);
        }
        // GET: User/Edit/5
        public IActionResult CreateEmployee()
        {
            //ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "Role1");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee([Bind("UserId,Name,Password,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                user.RoleId = 1;//sets to employee
                user.Password = encrypt.Hash_Password(user.Password);//password is hashed for security reasons
                _context.Add(user);
                await _context.SaveChangesAsync();//it is saved to the database
                int UserID = user.UserId;//i get the user id with ease
                Response.Cookies.Append("RoleID", 1.ToString());
                Response.Cookies.Append("UserID", UserID.ToString());
                return RedirectToAction("HomePageEmployee", "Home");
            }
            //ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId");
            return View(user);
        }
    }
}
