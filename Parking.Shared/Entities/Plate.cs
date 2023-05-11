using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parking.Shared.Entities
{

    public class Plate
    {

        public int Id { get; set; }

        [Display(Name = "Placas")]  //{0}
        [MaxLength(100, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; } = null;

        [Display(Name = "ID Propietario")]  //{0}
        [MaxLength(20, ErrorMessage = "Cuidado el campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Owner { get; set; } = null;

        public Owner? OwnerFK { get; set; }

    }
}
