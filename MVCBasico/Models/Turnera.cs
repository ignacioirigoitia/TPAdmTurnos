using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCBasico.Models
{
    public class Turnera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTurnera { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Por favor ingresar el nombre.")]
        public string Nombre { get; set; }

        // public virtual ICollection<Cupcake> Cupcakes { get; set; }

        public virtual ICollection<Cliente> clientes { get; set; }

        // public virtual ICollection<Cupcake> Cupcakes { get; set; }
        public virtual ICollection<Turno> turnos { get; set; }








        public bool SolicitarTurno(Cliente cliente, DateTime fecha)
        {
            // primero verifico que tengo disponibilidad en esa fecha
            VerificarDisponibilidad(fecha);
            // luego verifico si el cliente tiene saldo para el turno solicitado
            VerificarSaldo(cliente);
            // una vez cumplidas esas condiciones asigno el turno
            AsignarTurno(cliente, fecha);
            return true;
        }

        private bool VerificarDisponibilidad(DateTime fecha)
        {
            // verifico en mi lista de turnos solicitados si ya tengo ocupada esa fecha
            Console.WriteLine(fecha);
            return true;
        }

        private bool VerificarSaldo(Cliente cliente)
        {
            // verifico en el saldo del cliente que me envian por parametro si tiene saldo disponible para el turno
            Console.WriteLine(cliente);
            return true;
        }

        private void AsignarTurno(Cliente cliente, DateTime fecha)
        {
            // creo el turno, lo agrego a mi lista de turnos solicitados y se lo agrego al historial de turnos del cliente
            Console.WriteLine(cliente);
            Console.WriteLine(fecha);
        }

        public void IngresarCliente(Cliente cliente)
        {
            // aca agrego al cliente en mi lista de clientes
            Console.WriteLine(cliente);
        }

        public void CancelarTurno(Turno turno)
        {
            // aca cancelo el turno eliminandolo de la lista y asi liberando esa fecha
            Console.WriteLine(turno);
        }

    }

}
