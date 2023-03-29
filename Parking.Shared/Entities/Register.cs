using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parking.Shared.Entities
{
    public class Register
    {
        public int Id { get; set; }
        public int IdParking{ get; set; }

        [Display(Name = "Placa")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Car { get; set; } = null;
        public DateTime Fecha{ get; set; }
    }
}
