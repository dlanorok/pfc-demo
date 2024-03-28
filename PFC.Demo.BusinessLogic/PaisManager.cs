using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using PFC.Demo.BusinessLogic.Extensions;
using PFC.Demo.DataAccess.Entities;
using PFC.Demo.DataAccess.Json;
using PFC.Demo.Domain.Models;

namespace PFC.Demo.BusinessLogic
{
    public static class PaisManager
    {
        public static ResultModel<List<PaisModel>> GetPaises()
        {
            var result = PaisData
                         .GetPaises()
                         .ConvertTo<List<PaisModel>>();
            
            var model = new ResultModel<List<PaisModel>>
            {
                Result = result
            };
            
            return model;
        }
        
        public static ResultModel<List<ProvinciaModel>> GetProvinciasByPaisId(string paisId)
        {
            var result = PaisData
                         .GetProvinciasByPaisId(paisId)
                         .ConvertTo<List<ProvinciaModel>>();
            
            var model = new ResultModel<List<ProvinciaModel>>
            {
                Result = result
            };
            
            return model;
        }
        
        public static ResultModel<List<CiudadModel>> GetCiudadesByProvinciaId(string provinciaId)
        {
            var result = PaisData
                         .GetCiudadesByProvinciaId(provinciaId)
                         .ConvertTo<List<CiudadModel>>();
            
            var model = new ResultModel<List<CiudadModel>>
            {
                Result = result
            };
            
            return model;
        }
    }
}