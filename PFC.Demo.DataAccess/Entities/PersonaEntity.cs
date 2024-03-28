using System;

namespace PFC.Demo.DataAccess.Entities
{
    public class PersonaEntity
    {
        public int      Id              { get; set; }
        public string   Identificacion  { get; set; }
        public string   Nombre          { get; set; }
        public string   Apellidos       { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string   Direccion       { get; set; }
        public string   Referencia      { get; set; }
        public string   Ciudad          { get; set; }
        public string   Provincia       { get; set; }
        public string   Pais            { get; set; }
        public string   CodigoPostal    { get; set; }
    }
}