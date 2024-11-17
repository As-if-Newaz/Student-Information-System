using Mid_Term_Project.Auth;
using Mid_Term_Project.DTO;
using Mid_Term_Project.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mid_Term_Project.Controllers
{
    [Logged]
    public class DashboardController : Controller
    {
        SchoolEntities1 db = new SchoolEntities1();

        // GET: Dashboard
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            var converted = Convert(data);
            return View(converted);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new StudentDTO());
        }
        [HttpPost]
        public ActionResult Create(StudentDTO c)
        {
            
            if (ModelState.IsValid)
            {
                var cs = Convert(c);
                db.Students.Add(cs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {

            var exobj = db.Students.Find(id);

            return View(Convert(exobj));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var exobj = db.Students.Find(id);

            return View(Convert(exobj));
        }

        [HttpPost]

        public ActionResult Edit(Student c)
        {
            
            var exobj = db.Students.Find(c.Id);
            exobj.Name = c.Name;
            exobj.Age = c.Age;
            exobj.Grade = c.Grade;
            exobj.Address = c.Address;
            exobj.PId = c.PId;
            exobj.AId = c.AId;
            exobj.SId = c.SId;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Parent(int id)
        {

            var user = (from u in db.Parents
                        where u.SId.Equals(id) 
                        select u).SingleOrDefault();
            if (user == null)
            {
                return View(new ParentDTO());
            }
            else
            {
                return View(ConvertParent(user));
            }

        }
        [HttpPost]
        public ActionResult Parent(ParentDTO c)
        {

            if (ModelState.IsValid)
            {
                var cs = ConvertParent(c);
                db.Parents.Add(cs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Schedule(int id)
        {

            var user = (from u in db.Schedules
                        where u.SId.Equals(id)
                        select u).SingleOrDefault();
            if (user == null)
            {
                return View(new ScheduleDTO());
            }
            else
            {
                return View(ConvertSchedule(user));
            }

        }
        [HttpPost]
        public ActionResult Schedule(ScheduleDTO c)
        {

            if (ModelState.IsValid)
            {
                var cs = ConvertSchedule(c);
                db.Schedules.Add(cs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Attendence(int id)
        {

            var user = (from u in db.Attendences
                        where u.SId.Equals(id)
                        select u).SingleOrDefault();
            if (user == null)
            {
                return View(new ScheduleDTO());
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var exobj = db.Students.Find(id);

            return View(Convert(exobj));
        }

        [HttpPost]

        public ActionResult Delete(StudentDTO c)
        {
            var exobj = db.Students.Find(c.Id);
            exobj.Valid = 0;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public static Student Convert(StudentDTO c)

        {
            return new Student()
            {
                Name = c.Name,
                Age = c.Age,
                Grade = c.Grade,
                Address = c.Address,
                Valid = c.Valid,
                Parent  = c.Parent,
                Schedule = c.Schedule,
                Attendences = c.Attendences,
            };
        }

        public static StudentDTO Convert(Student c)

        {
            return new StudentDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Grade = c.Grade,
                Address = c.Address,
                Valid  = c.Valid,
                Parent = c.Parent,
                Schedule = c.Schedule,
                Attendences = c.Attendences,
            };
        }


        public static List<StudentDTO> Convert(List<Student> students)
        {
            var list = new List<StudentDTO>();
            foreach (var cs in students)
            {
                var css = Convert(cs);
                list.Add(css);
            }
            return list;
        }

        public static Parent ConvertParent(ParentDTO c)

        {
            return new Parent()
            {
                Name = c.Name,
                Phone = c.Phone,
                SId = c.SId,
            };
        }

        public static ParentDTO ConvertParent(Parent c)

        {
            return new ParentDTO()
            {
                Name = c.Name,
                Phone = c.Phone,
                SId = c.SId,
            };
        }

        public static List<ParentDTO> ConvertParent(List<Parent> parents)
        {
            var list = new List<ParentDTO>();
            foreach (var cs in parents)
            {
                var css = ConvertParent(cs);
                list.Add(css);
            }
            return list;
        }

        public static Schedule ConvertSchedule(ScheduleDTO c)

        {
            return new Schedule()
            {
                
                SId= c.SId,
                First = c.First,    
                Second = c.Second,
                Third = c.Third,
                Fourth = c.Fourth,
                Fifth = c.Fifth,
            };
        }

        public static ScheduleDTO ConvertSchedule(Schedule c)

        {
            return new ScheduleDTO()
            {
                Id = c.Id,
                SId = c.SId,
                First = c.First,
                Second = c.Second,
                Third = c.Third,
                Fourth = c.Fourth,
                Fifth = c.Fifth,
            };
        }
    }
}