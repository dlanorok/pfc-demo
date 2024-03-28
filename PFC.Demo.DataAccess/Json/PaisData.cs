using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using PFC.Demo.DataAccess.Entities;

namespace PFC.Demo.DataAccess.Json
{
    public static class PaisData
    {
        private static List<PaisEntity> _data = new List<PaisEntity>();

        static PaisData()
        {
            LoadPaises();
        }

        private static void LoadPaises()
        {
            var type = typeof(PaisData);
            var resourceFile = type.Assembly.GetManifestResourceNames()
                                        .FirstOrDefault(name => name.EndsWith("paises.json"));
            if (resourceFile != null)
            {
                var stream = type.Assembly.GetManifestResourceStream(resourceFile);
                using (var reader = new StreamReader(stream)) {
                    var json = reader.ReadToEnd();
                    var paises = JsonConvert.DeserializeObject<List<PaisEntity>>(json);

                    _data = paises;
                }
            }           
        }

        public static List<PaisEntity> GetPaises()
        {
            return _data?.Select(x => new PaisEntity
            {
                Id     = x.Id,
                Nombre = x.Nombre
            })?.ToList() ?? new List<PaisEntity>();
        }

        public static List<ProvinciaEntity> GetProvinciasByPaisId(string paisId)
        {
            return _data?.FirstOrDefault(x => x.Id == paisId || string.Equals(x.Nombre, paisId, StringComparison.OrdinalIgnoreCase))?
                .Provincias?
                .Select(x => new ProvinciaEntity
                {
                    Id     = x.Id,
                    Nombre = x.Nombre
                })?.ToList() ?? new List<ProvinciaEntity>();
        }

        public static List<CiudadEntity> GetCiudadesByProvinciaId(string provinciaId)
        {
            return _data.SelectMany(x => x.Provincias)?
                .FirstOrDefault(x => x.Id == provinciaId || string.Equals(x.Nombre, provinciaId, StringComparison.OrdinalIgnoreCase))?
                .Ciudades?
                .Select(x => new CiudadEntity
                {
                    Id     = x.Id,
                    Nombre = x.Nombre
                })?.ToList() ?? new List<CiudadEntity>();
        }
    }
}