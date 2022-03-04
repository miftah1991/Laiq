using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }  
    }
}