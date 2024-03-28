using PFC.Demo.Domain.Models;
using PFC.Demo.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PFC.Demo.ClientApp.Controllers
{
    public class CuentaBancariaController : Controller
    {
        // GET: CuentaBancaria/Create
        public ActionResult Create(int personaId)
        {
            var model = new CuentaBancariaModel
            {
                PersonaId = personaId
            };
            return PartialView("Edit", model);
        }

        // GET: CuentaBancaria/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await Services.CuentaBancariaService.GetCuentaBancariaById(id);
            if (!model.Success)
            {
                throw new Exception(model.Message);
            }

            return PartialView("Edit", model.Result);
        }

        // POST: CuentaBancaria/Create
        [HttpPost]
        public async Task<ActionResult> Create(CuentaBancariaUpdateModel model)
        {
            try
            {
                var result = await Services.CuentaBancariaService.CrearCuentaBancaria(model);
                return Json(result);
            }
            catch
            {
                return Json(new ResultModel { Message = "Error al guardar la cuenta bancaria", Success = false });
            }
        }

        // POST: CuentaBancaria/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, CuentaBancariaUpdateModel model)
        {
            try
            {
                var result = await Services.CuentaBancariaService.ActualizarCuentaBancaria(id, model);
                return Json(result);
            }
            catch
            {
                return Json(new ResultModel { Message = "Error al guardar la cuenta bancaria", Success = false });
            }
        } 

        // POST: CuentaBancaria/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await Services.CuentaBancariaService.EliminarCuentaBancaria(id);
                return Json(result);
            }
            catch
            {
                return Json(new ResultModel { Message = "Error al eliminar la cuenta bancaria", Success = false });
            }
        }
    }
}
