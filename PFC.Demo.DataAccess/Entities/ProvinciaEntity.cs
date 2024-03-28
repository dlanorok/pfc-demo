using System.Collections.Generic;

namespace PFC.Demo.DataAccess.Entities
{
    public class ProvinciaEntity
    {
        public string                Id       { get; set; }
        public string             Nombre   { get; set; }
        public List<CiudadEntity> Ciudades { get; set; }
    }
}