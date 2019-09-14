using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class User: IdentityUser
    {
        [MaxLength(30, ErrorMessage = "the field {0} should have {1} characters")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        public string Document { get; set; }

        [Required(ErrorMessage = "the field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "the field {0} should have {1} characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "the field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "the field {0} should have {1} characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(20, ErrorMessage = "the field {0} should have {1} characters")]
        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [MaxLength(20, ErrorMessage = "the field {0} should have {1} characters")]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        [MaxLength(100, ErrorMessage = "the field {0} should have {1} characters")]
        public string Address { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{ FirstName } { LastName }";

        [Display(Name = "First Name")]
        public string FullNameWithDocument => $"{ FullName } - { Document }";
    }
}
