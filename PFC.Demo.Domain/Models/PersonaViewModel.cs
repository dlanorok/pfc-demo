using System.Collections.Generic;

namespace PFC.Demo.Domain.Models
{
    public class PersonaViewModel : PersonaModel
    {
        public List<CuentaBancariaModel> CuentasBancarias { get; set; } = new List<CuentaBancariaModel>();
    }
}
