using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PFC.Demo.Domain.Models
{
    public class PersonaModel
    {
        [DisplayName("Id")] public int Id { get; set; }

        [Required(ErrorMessage="El Numero de Identificación es requerido")]
        [DisplayName("Identificación")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage="Por favor ingrese los nombres del cliente")]
        [DisplayName("Nombres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage="Por favor ingrese los apellidos del cliente")]
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage="Por favor ingrese la direccion completa")]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage="Por favor escriba una referencia")]
        [DisplayName("Referencia")]
        public string Referencia { get; set; }

        [Required(ErrorMessage="Por favor seleccione una ciudad")]
        [DisplayName("Ciudad")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage="Por favor seleccione una provincia")]
        [DisplayName("Provincia")]
        public string Provincia { get; set; }

        [Required(ErrorMessage="Por favor seleccione el pais")]
        [DisplayName("País")] public string Pais         { get; set; }
        
        [DisplayName("Código Postal")]   public string CodigoPostal { get; set; }

        [Required(ErrorMessage="Por favor ingrese su fecha de nacimiento")]
        [DisplayName("Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; } = new DateTime(DateTime.Now.Year - 16, 1, 1);
    }
}