using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasico.Models
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTurno { get; set; }

        public int? IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int? IdTurnera { get; set; }
        public virtual Turnera Turnera { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha turno")]
        [Required(ErrorMessage = "Por favor ingresar la fecha del turno.")]
        public DateTime FechaTurno { get; set; }
    }
}
