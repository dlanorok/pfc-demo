using System.Collections.Generic;

namespace PFC.Demo.DataAccess.Entities
{
    public class PaisEntity
    {
        public string                   Id         { get; set; }
        public string                Nombre     { get; set; }
        public List<ProvinciaEntity> Provincias { get; set; }
    }
}