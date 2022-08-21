using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21570869_HW04.Models
{
    public class Teacher : User
    {
        public override string Status { get; set; }

        public override bool IsBlocked { get; set; }

        public override string Gender { get; set; }
    }
}