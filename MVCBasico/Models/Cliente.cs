using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasico.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Por favor ingresar el nombre.")]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Apellido:")]
        [Required(ErrorMessage = "Por favor ingresar el apellido.")]
        public string Apellido { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Edad:")]
        [Required(ErrorMessage = "Por favor ingresar la edad.")]
        public int Edad { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Saldo:")]
        [Required(ErrorMessage = "Por favor ingresar el saldo.")]
        public double Saldo { get; set; }

        //
        public virtual ICollection<Turno> historialTurnos { get; set; }

        public string NombreApellidoCliente
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }




        public void AgregarTurno(Turno turno)
        {
            // aca agrego el turno a mi historial de turnos
            Console.WriteLine(turno);
        }

        public void IngresarSaldo(double saldo)
        {
            // aca agrego el saldo a mi saldo correspondiente
            Console.WriteLine(saldo);
        }

        public void RestarSaldo(double saldo)
        {
            // aca resto el saldo a mi saldo correspondiente
            // Console.WriteLine(saldo);
            this.Saldo -= saldo;
        }

        public bool TengoSaldo()
        {
            // aca verifico si tengo saldo para el turno solicitado
            return this.Saldo > 100;
        }
    }
}
