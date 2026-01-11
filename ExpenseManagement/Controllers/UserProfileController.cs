using Microsoft.AspNetCore.Mvc;
using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;


namespace ExpenseManagement.Controllers
{
    public class UserProfileController : Controller
    {

        public readonly DbContextExpMgmt _context;

        public UserProfileController(DbContextExpMgmt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string EmailAddress, string Password)
        {
            ViewBag.LoginStatus = "";
            if (ModelState.IsValid)
            {
                var userCheck = _context.UserProfile.FirstOrDefault
                    (u => u.EmailAddress == EmailAddress && u.Password == Password);

                if (userCheck is null)
                {
                    ViewBag.LoginStatus = "Invalid Login. User not found.";
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public IActionResult Registration(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                _context.UserProfile.Add(userProfile);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
