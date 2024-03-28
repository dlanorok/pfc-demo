using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PFC.Demo.Domain.Models
{
    public class CuentaBancariaModel
    {
        [DisplayName("Id")] [Required] public int Id { get; set; }

        [DisplayName("PersonaId")] [Required] public int PersonaId { get; set; }

        [DisplayName("Numero de Cuenta")]
        [Required(ErrorMessage = "El numero de cuenta es requerido")]
        [MinLength(5, ErrorMessage = "El número de cuenta debe tener minimo 5 caracteres")]
        [MaxLength(36, ErrorMessage = "El número de cuenta no puede exceder el tamano requerido")]
        public string NumeroCuenta { get; set; }

        [DisplayName("Tipo")]
        [Required(ErrorMessage = "Por favor seleccione el tipo de cuenta")]
        public TipoCuentaEnum Tipo { get; set; }

        [DisplayName("Balance")]
        [Required(ErrorMessage = "Debe ingresar el valor del balance")]
        public decimal Balance { get; set; }

        [DisplayName("Comentarios")]
        [Required(ErrorMessage = "Debe ingresar los comentarios de la cuenta")]
        public string Comentarios { get; set; }
    }
}