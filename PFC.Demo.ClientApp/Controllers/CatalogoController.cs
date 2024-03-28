using PFC.Demo.ClientApp.Services;
using PFC.Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PFC.Demo.ClientApp.Controllers
{
    public class CatalogoController : Controller
    {
        private ResultModel<List<PaisModel>> _paises_cache = null;
        // GET: Catalogo/GetPaises
        public async Task<ActionResult> GetPaises()
        {
            if (_paises_cache == null || !_paises_cache.Success)
            {
                _paises_cache = await CatalogoService.GetAllPaises();
            }

            return Json(_paises_cache, JsonRequestBehavior.AllowGet);
        }

        // GET: Catalogo/GetProvinciasByPaisId/{id}
        public async Task<ActionResult> GetProvinciasByPaisId(string id)
        {
            var result = await CatalogoService.GetProvinciasByPaisId(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Catalogo/GetCiudadesByProvinciaId/{id}
        public async Task<ActionResult> GetCiudadesByProvinciaId(string id)
        {
            var result = await CatalogoService.GetCiudadesByProvinciaId(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}