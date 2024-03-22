using System;
using System.ComponentModel.DataAnnotations;

namespace PFC.Demo.Domain.Models
{
    public class PersonaEntity
    {
        public int Id { get; set; }
        [Required] public string Identificacion { get; set; }
        [Required] public string Nombre { get; set; }
        [Required] public string Apellidos { get; set; }
        [Required] public DateTime FechaNacimiento { get; set; }
        [Required] public string Direccion { get; set; }
        [Required] public string Referencia { get; set; }
        [Required] public string Ciudad { get; set; }
        [Required] public string Provincia { get; set; }
        [Required] public string Pais { get; set; }
        public string CodigoPostal { get; set; }
    }
}