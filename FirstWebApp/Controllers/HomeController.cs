using FirstWebApp.Models;
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
    public class HomeController : Controller
    {
        UseEntities DB = new UseEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult News()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Signup()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Adduser(string firstname,string lastname, string email,string phone,string password,string birthday)
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
                return View("Signup");
                
            }
            return View("Index");
        }
        public ActionResult ManagerView()
        {
            return View();
        }
        public ActionResult CeoView()
        {
            return View();
        }
        public ActionResult Login(string email,string password)
        {
            using (var context=new UseEntities()) 
            {
                bool isValid = context.Tables.Any(x => x.Email.Equals(email) && x.Password.Equals(password));
                if (isValid)
                {
                    return View("Home");
                }
                bool isValid1 = email.Equals("ceo@dukowheels.com") && password.Equals("CEO12345");
                if (isValid1)
                {
                    return View("CeoView");
                }
            }
            using (var context = new UserEntities())
            {
                bool isValid = context.Table1.Any(x => x.Email.Equals(email) && x.Password.Equals(password));
                if (isValid)
                {
                    return View("ManagerView");
                }
                return View("Index");
            }
           

        }
        public ActionResult AccountRecovery()
        {
            return View();
        }
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                var data = DB.Tables.Select(x => x.Email.Equals(email)).ToList();

               
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("#Your name here#", "#Your brand name #");
                    var receiverEmail = new MailAddress(email);
                    var password = "#Your email password here#";
                    var Subject = "Account Recovery";
                    var body = "Your account Password is given below use the password to login again \n" + data;
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
                        Subject = "Account Recovery",
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

                return View("AccountRecovery");
            }
            return View("AccountRecovery");
        }
        

    }
}