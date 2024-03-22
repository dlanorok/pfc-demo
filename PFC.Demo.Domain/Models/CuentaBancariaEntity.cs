using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFC.Demo.Domain.Models
{
    public class CuentaBancariaEntity
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string NumeroCuenta { get; set; }
        public TipoCuentaEnum Tipo { get; set; }
        public decimal Balance { get; set; }
        public string Comentarios { get; set; }
    }
}
