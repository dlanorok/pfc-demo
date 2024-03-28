using System.ComponentModel.DataAnnotations;

namespace PFC.Demo.Domain.Models.Request
{
    public class CuentaBancariaUpdateModel
    {
        [Required(ErrorMessage = "Debe especificar el propietario de la cuenta")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Debe especificar el numero de cuenta")]
        public string NumeroCuenta { get; set; }

        [Required(ErrorMessage = "Debe especificar el tipo de cuenta")]
        public TipoCuentaEnum Tipo { get; set; }

        [Required(ErrorMessage = "Debe indicar un valor del saldo")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Debe especificar algun comentario")]
        public string Comentarios { get; set; }
    }
}