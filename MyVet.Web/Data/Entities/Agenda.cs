using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Agenda
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [Display(Name = "Pet Name")]
        [MaxLength(50, ErrorMessage = "the field {0} should have {1} characters")]
        public string Name { get; set; }

        [Display(Name = "Born")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "IsAvailable")]
        public string IsAvailable { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

        public Owner Owner { get; set; }

        public Pet Pet { get; set; }
    }
}
