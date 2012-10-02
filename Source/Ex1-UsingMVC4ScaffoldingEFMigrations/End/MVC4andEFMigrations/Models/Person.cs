using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC4andEFMigrations.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}