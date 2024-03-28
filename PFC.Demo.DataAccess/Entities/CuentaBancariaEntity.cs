namespace PFC.Demo.DataAccess.Entities
{
    public class CuentaBancariaEntity
    {
        public int     Id           { get; set; }
        public int     PersonaId    { get; set; }
        public string  NumeroCuenta { get; set; }
        public short   Tipo         { get; set; }
        public decimal Balance      { get; set; }
        public string  Comentarios  { get; set; }
    }
}