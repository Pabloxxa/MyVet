using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}
