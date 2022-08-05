using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai5.Models;

namespace Bai5.Controllers
{
    public class StudentRegistrationController : Controller
    {
        // GET: StudentRegistration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Regis(Student s)
        {
            return View(s);
        }

        public ActionResult Regis2(FormCollection f)
        {
            Student s = new Student();
            s.name = f["name"];
            s.gender = f["gender"];
            s.email = f["email"];
            s.address = f["address"];

            string temp = "";
            if(f["Java Core"] == "true,false")
            {
                temp = "Java Core";
            }
            if (f["SQL Server"] == "true,false")
            {
                temp += "SQL Server";
            }
            if (f["PHP"] == "true,false")
            {
                temp += "PHP";
            }

            s.subjects = temp;
            s.username = f["username"];
            s.password = f["password"];
            s.comment = f["comment"];

            return View("Regis", s);
        }
    }
}