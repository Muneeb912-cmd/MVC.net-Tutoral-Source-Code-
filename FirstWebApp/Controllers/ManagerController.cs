using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApp.Controllers
{
    public class ManagerController : Controller
    {
        UseEntities DB = new UseEntities();
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAllUsers()
        {
            var Data = DB.Tables.ToList();
            return View(Data);
        }
        public ActionResult Delete(string Email)
        {
            var del = DB.Tables.Where(x => x.Email == Email).First();
            DB.Tables.Remove(del);
            DB.SaveChanges();
            var List = DB.Tables.ToList();
            return View("ViewAllUsers", List);

        }
        public ActionResult EditUserDataForm(Table t)
        {
            return View();
        }
        public ActionResult UserdataEdit(string firstname, string lastname, string email, string phone, string password, string birthday)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Table t = new Table();
                    t.FirstName = firstname;
                    t.LastName = lastname;
                    t.Email = email;
                    t.Phone = phone;
                    t.Password = password;
                    t.BirthDay = birthday;
                    DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();

                }
                ModelState.Clear();
            }
            catch (DbEntityValidationException)
            {

                return View("EditUserDataForm");
            }
            var users = DB.Tables.ToList();
            return View("ViewAllUsers" , users);

        }
        public ActionResult Adduser(string firstname, string lastname, string email, string phone, string password, string birthday)
        {
            try
            {
                UseEntities db = new UseEntities();
                Table t = new Table();
                t.FirstName = firstname;
                t.LastName = lastname;
                t.Email = email;
                t.Phone = phone;
                t.Password = password;
                t.BirthDay = birthday;
                db.Tables.Add(t);
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return View("Adduser");

            }
            return View("Index");
        }
        public ActionResult CreateUser() {
            return View();
        }
        public ActionResult ViewUsers()
        {
            var Data = DB.Tables.ToList();
            return View(Data);
        }
        public ActionResult Details(string search)
        {
            try
            {
                var list = DB.Tables.Where(x => x.Email.Equals(search)).ToList();
                return View(list);
            }
            catch (Exception)
            {

                return View("ViewUsers");
            }
            
        }
        public ActionResult ListOfUsers()
        {
            var list = DB.Tables.ToList();
            return View(list);
        }
        public ActionResult ContactView(Table t)
        {
            return View();
        }
        public ActionResult SendEmail(string email, string subject,string message )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("dukocommunity@gmail.com","DeukoWheels");
                    var receiverEmail = new MailAddress(email);
                    var password = "Incredebols7@duko";
                    var Subject = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    }
                    )
                    {
                        smtp.Send(mess);
                    }
                }
            }
            catch (Exception)
            {
                return View("ContactView");
            }
            return View("ListOfUsers");
        }
    }
}