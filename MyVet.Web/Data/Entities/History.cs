using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class History
    {
        public int Id { get; set; }
        [Display(Name = "Case Description")]
        [MaxLength(100, ErrorMessage = "the field {0} should have {1} characters")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        public string Description { get; set; }
        [Display(Name = "Date")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy/mm/dd}",ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Remarks{ get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy/mm/dd}",ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

        public ServiceType ServiceType { get; set; }
        
        public Pet Pet { get; set; }



    }
}
