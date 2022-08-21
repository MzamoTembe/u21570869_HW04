using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21570869_HW04.Models;

namespace u21570869_HW04.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            //Reteieves data from form
            string name = Request["name"];
            string type = Request["membertype"].ToString();
            string gender = Request["gender"].ToString();
            string description = Request["description"];

            //Checks type then creates object for storage in repository
            if (type == "student")
            {
                Student student = new Student();
                student.Name = name;
                student.Type = type;
                student.Description = description;
                student.Status = "";
                student.Gender = gender;
                student.IsBlocked = true;
                //if theres an object then it won't duplicate'
                if (Repository.Users.Contains(student) == true)
                {
                    return View("Chat", student);
                }
                else
                {
                    Repository.Students.Add(student);
                    Repository.Users.Add(student);
                    return View("Chat", student);
                }
            }
            else if (type == "teacher")
            {
                Teacher teacher = new Teacher();
                teacher.Name = name;
                teacher.Type = type;
                teacher.Description = description;
                teacher.Status = "";
                teacher.Gender = gender;
                teacher.IsBlocked = false;
                //if theres an object then it won't duplicate'
                if (Repository.Users.Contains(teacher) == true)
                {
                    return View("Chat", teacher);
                }
                else
                {
                    Repository.Teachers.Add(teacher);
                    Repository.Users.Add(teacher);
                    return View("Chat", teacher);
                }
            }
            ViewBag.Message = "You have to enter your details in the form";
            return View("Error");
        }

        [HttpGet]
        public ActionResult Chat(User user)
        {
            return View(user);
        }

        //Retrieves name of current user
        public ActionResult Block(string username)
        {
            //Adds to Temps so it can be retrieved later when returnig to Chat View
            Repository.Temps.Clear();
            Temporary temppteacher = new Temporary();
            temppteacher.TempUser = username;
            Repository.Temps.Add(temppteacher);

            // Get list of students
            List<Student> students = new List<Student>();
            students = Repository.Students;

            //get type for to check if he/she is a student
            string type = Repository.Users.Find(x => x.Name == username).Type;
            //Checks
            if (type == "student")
            {
                ViewBag.Message = "Students cannot access this page.";
                return View("Error");
            }
            else
            {
                return View(students);
            }
        }

        [HttpGet]
        public ActionResult BlockStudent(string name)
        {
            //Gets blocked students 
            Student student = Repository.Students.Find(x => x.Name == name);
            return View(student);
        }
        [HttpPost]
        public ActionResult BlockStudent(Student student)
        {
            // Set new Student
            student.IsBlocked = true;
            Student updated = new Student();
            updated = student;

            //Delete old version
            string name = student.Name;
            Student old = Repository.Students.Find(x => x.Name == name);
            Repository.Students.Remove(old);
            Repository.Users.Remove(old);
            Repository.Users.Add(updated);
            Repository.Students.Add(updated);

            // Retrieving User Session data previously stored
            string usecase = Repository.Temps[0].TempUser;
            User sessiondata = new User();
            sessiondata = Repository.Users.Find(x => x.Name == usecase);
            return View("Chat", sessiondata);
        }

        [HttpGet]
        public ActionResult UnblockStudent(string name)
        {
            //Gets Unblocked students 
            Student student = Repository.Students.Find(x => x.Name == name);
            return View(student);
        }
        [HttpPost]
        public ActionResult UnblockStudent(Student student)
        {
            // Set new Student
            student.IsBlocked = false;
            Student updated = new Student();
            updated = student;

            //Delete old version
            string name = student.Name;
            Student old = Repository.Students.Find(x => x.Name == name);
            Repository.Students.Remove(old);
            Repository.Users.Remove(old);
            Repository.Users.Add(updated);
            Repository.Students.Add(updated);

            // Retrieving User Session data previously stored
            string usecase = Repository.Temps[0].TempUser;
            User sessiondata = new User();
            sessiondata = Repository.Users.Find(x => x.Name == usecase);
            return View("Chat", sessiondata);
        }
    }
}