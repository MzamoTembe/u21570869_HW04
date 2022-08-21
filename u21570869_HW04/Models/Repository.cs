using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21570869_HW04.Models
{
    public class Repository
    {
        public static readonly List<User> Users = new List<User>
        {
            new User{Name = "Itworks"}
        };

        public static readonly List<Student> Students = new List<Student>
        {
            new Student{Name = "3", Type = "Ok", Description = "Description", Status = "status"},
            new Student{Name = "4", Type = "Ok", Description = "Description", Status = "status"},
        };

        public static readonly List<Teacher> Teachers = new List<Teacher>
        {

        };

        public static readonly List<Temporary> Temps = new List<Temporary>
        {

        };
    }
}