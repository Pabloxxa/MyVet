using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class ActivityLogs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Empleado")]
        public Employee Employee { get; set; }
        [Required]
        [Display(Name = "Actividad")]
        public Activity Activity { get; set; }
    }
}
