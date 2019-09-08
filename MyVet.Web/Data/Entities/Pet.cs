 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [Display(Name = "Pet Name")]
        [MaxLength(50, ErrorMessage = "the field {0} should have {1} characters")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Race")]
        [MaxLength(50, ErrorMessage = "the field {0} should have {1} characters")]
        public string Race { get; set; }

        [Display(Name = "Born")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }

        public string Remarks { get; set; }

        public PetType PetType { get; set; }

        public Owner Owner { get; set; }

        public ICollection<Agenda> Agendas { get; set; }

        public ICollection<History> Histories { get; set; }

        [Display(Name = "Date")]
        public DateTime BornLocal => Born.ToLocalTime();

        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)?
            null: $"https://TBD.azurewebsites.net{ImageUrl.Substring(1)}";
    }
}
