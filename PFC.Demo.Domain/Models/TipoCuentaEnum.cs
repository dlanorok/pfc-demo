using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public enum TipoCuentaEnum : short
{
    [Display(Name = "Cuenta Corriente")]
    Corriente,
    [Display(Name = "Cuenta de ahorros")]
    Ahorros,
    [Display(Name = "Tarjeta de Credito")]
    TarjetaCredito,
    [Display(Name = "Inversion")]
    Inversion
}