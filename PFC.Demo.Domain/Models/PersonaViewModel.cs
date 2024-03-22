using System.Collections.Generic;

namespace PFC.Demo.Domain.Models
{
    public class PersonaViewModel : PersonaEntity
    {
        public List<CuentaBancariaEntity> CuentasBancarias { get; set; } = new List<CuentaBancariaEntity>();
    }
}
