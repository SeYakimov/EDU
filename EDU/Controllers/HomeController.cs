using EDU.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace EDU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IList<string> roles = new List<string> { "unknown user" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            ViewBag.Roles = roles;
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult TeacherTools()
        {
            if (HttpContext.User.IsInRole("teacher"))
            {
                return View();
            }
            return Redirect("Index");
        }

        public ActionResult AdminTools()
        {
            if (HttpContext.User.IsInRole("admin"))
            {
                return View();
            }
            return Redirect("Index");
        }
    }
}