using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21570869_HW04.Models
{
    public class User
    {
        public User()
        {

        }

        public User(string name, string type, string description, bool isBlocked)
        {
            Name = name;
            Type = type;
            Description = description;
            IsBlocked = isBlocked;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public virtual string Gender { get; set; }

        public virtual string Status { get; set; }
        public virtual bool IsBlocked { get; set; }

        public virtual string CustomD()
        {
            string msg = "Hello, I am a person. " + Description;
            return msg;
        }
    }
}