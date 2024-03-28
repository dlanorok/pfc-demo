using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PFC.Demo.Domain.Models
{
    public class CuentaBancariaModel
    {
        [DisplayName("Id")] [Required] public int Id { get; set; }

        [DisplayName("PersonaId")] [Required] public int PersonaId { get; set; }

        [DisplayName("Numero de Cuenta")]
        [Required]
        public string NumeroCuenta { get; set; }

        [DisplayName("Tipo")] [Required] public TipoCuentaEnum Tipo { get; set; }

        [DisplayName("Balance")] [Required] public decimal Balance { get; set; }

        [DisplayName("Comentarios")]
        [Required]
        public string Comentarios { get; set; }
    }
}