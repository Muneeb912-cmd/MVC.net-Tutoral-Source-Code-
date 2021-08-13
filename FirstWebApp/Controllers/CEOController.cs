using FirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApp.Controllers
{
    public class CEOController : Controller
    {
        UserEntities DB = new UserEntities();
        // GET: CEO
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManagerSignUp()
        {
            return View();
        }
        public ActionResult AddManager(Person data)
        {
            try
            {
                UserEntities db = new UserEntities();
                Table1 t = new Table1();
                t.Name = data.Name;
                t.Email = data.Email;
                t.CNIC = data.Cnic;
                t.Birthday = data.BirthDay;
                t.Phone = data.Phone;
                t.Password = data.Password;
                db.Table1.Add(t);
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return View("ManagerSignUp");

            }
            return View("Index");
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult ViewAllManagers()
        {
            var list = DB.Table1.ToList();
            return View(list);

        }
        public ActionResult ViewManagers()
        {
            var list = DB.Table1.ToList();
            return View(list);

        }
        public ActionResult ManagerListWithSerch()
        {
            var list = DB.Table1.ToList();
            return View(list);
        }
        public ActionResult SearchedManager(string search)
        {
            try
            {
                var list = DB.Table1.Where(x => x.Email.Equals(search)).ToList();
                return View(list);
            }
            catch (Exception)
            {

                return View("ViewManagers");
            }

        }

    }
}