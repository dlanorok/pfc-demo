using System;
using System.ComponentModel.DataAnnotations;

namespace PFC.Demo.Domain.Models.Request
{
    public class PersonaUpdateModel
    {
        [Required(ErrorMessage = "Debe especificar la identificacion")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Debe especificar los nombres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe especificar los apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Debe especificar la fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe especificar la direccion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe especificar alguna referencia")]
        public string Referencia { get; set; }

        [Required(ErrorMessage = "Debe especificar la ciudad")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Debe especificar la provincia")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Debe especificar el pais")]
        public string Pais { get; set; }

        public string CodigoPostal { get; set; }
    }
}