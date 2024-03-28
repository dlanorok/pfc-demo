namespace PFC.Demo.DataAccess.Entities
{
    public class CuentaBancariaUpdateEntity
    {
        public int     PersonaId    { get; set; }
        public string  NumeroCuenta { get; set; }
        public short   Tipo         { get; set; }
        public decimal Balance      { get; set; }
        public string  Comentarios  { get; set; }
    }
}