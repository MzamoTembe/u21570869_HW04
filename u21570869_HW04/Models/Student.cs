using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21570869_HW04.Models
{
    public class Student : User
    {
        public override string Status { get; set; }
        public Student()
        {

        }
        public override bool IsBlocked { get; set; }
        public override string Gender { get; set; }

        public void BlockStudent(string status)
        {
            if (status == "Block")
            {
                IsBlocked = true;
            }
            else if (status == "Unblock")
            {
                IsBlocked = false;
            }
        }
    }
}