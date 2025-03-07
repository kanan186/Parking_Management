using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParkingManagement.Models;
using System;
using ParkingManagement.Data;
using ParkingManagement.Migrations;

namespace ParkingManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext context;

        public HomeController(DataContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Process the search query here
                ViewBag.SearchTerm = searchQuery;
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (!ModelState.IsValid)
            {
                var user = context.Users
                    .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserRole", user.Role);

                    if (user.Role == "Admin")
                        return RedirectToAction("userDashboard", "UserDashboard");

                    return RedirectToAction("userDashboard", "UserDashboard");
                }

                ViewBag.Error = "Invalid email or password.";
            }

            return View("Index");
        }

        //[HttpPost]
        //    public IActionResult Login(Login model)  // Ensure 'Admin' class has an int Role
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = context.Logins.SingleOrDefault(a => a.Email == model.Email && a.Password == model.Password);

        //        if (user != null)
        //        {
        //            // Store user role as string in session
        //            HttpContext.Session.SetString("UserRole", user.Role.ToString());
        //            HttpContext.Session.SetString("UserEmail", user.Email);

        //            // Convert back to int and redirect based on role
        //            if (user.Role == 1)  // 1 = Admin
        //            {
        //                return RedirectToAction("Dashboard", "Admin");
        //            }
        //            else if (user.Role == 2)  // 2 = User
        //            {
        //                return RedirectToAction("UserHome", "User");
        //            }
        //        }

        //        ModelState.AddModelError("", "Invalid Email or Password");
        //    }
        //    return View(model);
        //}


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = context.Users.Any(u => u.Email == model.Email);
                if (existingUser)
                {
                    ViewBag.Error = "Email is already registered.";
                    return View("Index");
                }

                // Automatically assign "User" role
                model.Role = "User";
                context.Users.Add(model);
                context.SaveChanges();

                TempData["Success"] = "Registration successful! Please login.";
                return RedirectToAction("Login");
            }

            return View("Index");
        }

        public IActionResult why_us()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail")))
                return RedirectToAction("Login");

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public IActionResult Price()
        {
            return View();
        }
        public IActionResult Read_More()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
