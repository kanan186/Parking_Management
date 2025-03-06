using Microsoft.AspNetCore.Mvc;

namespace ParkingManagement.Controllers
{
    public class UserDashboard : Controller
    {
        [Route("UserDashboard")]

        public IActionResult userDashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail")))
                return RedirectToAction("Login");
            

            return View();
        }
    }
}
