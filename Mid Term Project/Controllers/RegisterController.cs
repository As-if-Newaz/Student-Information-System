using Mid_Term_Project.DTO;
using Mid_Term_Project.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mid_Term_Project.Controllers
{
    public class RegisterController : Controller
    {
        SchoolEntities1 db = new SchoolEntities1();

        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View(new RegisterDTO());
        }
        [HttpPost]
        public ActionResult Index(UserDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Uname.Equals(l.Uname) &&
                            u.Password.Equals(l.Password)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    var cs = Convert(l);
                    db.Users.Add(cs);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    return View("Index");
                }
                
            }
            else 
            {
                return View(); 
            }
        }
        public static User  Convert(UserDTO c)
            
        {
            return new User()
            {
                Uname = c.Uname,
                Password = c.Password
            };
        }

        public static UserDTO Convert(User u)
        {
            return new UserDTO()
            {
                Uname = u.Uname,
                Password = u.Password
            };
        }

        public static List<UserDTO> Convert(List<User> courses)
        {
            var list = new List<UserDTO>();
            foreach (var cs in courses)
            {
                var css = Convert(cs);
                list.Add(css);
            }
            return list;
        }

    }
}