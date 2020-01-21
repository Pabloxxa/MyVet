using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Fecha Actividad")]
        [Required(ErrorMessage = "the field {0} is mandatory")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd tt}", ApplyFormatInEditMode = true)]
        public DateTime FechaActividad { get; set; }

        [Display(Name = "Descripción Actividad")]
        public string TextoDescriptivo { get; set; }

        [Display(Name = "Hora Inicial Actividad")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd tt}", ApplyFormatInEditMode = true)]
        public DateTime Inicio { get; set; }

        [Display(Name = "Hora Cierre Actividad")]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd tt}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Cierre { get; set; }

        [Display(Name = "Duración")]
        public TimeSpan Duracion =>  Inicio - Cierre;

        [Display(Name = "Estado")]
        public bool Estado { get; set; }
    }
}
