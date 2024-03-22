using Newtonsoft.Json;
using PFC.Demo.Domain.Models;
using PFC.Demo.ClientApp.Services;
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
    public class PersonaController : Controller
    {
        // GET: Persona
        public async Task<ActionResult> Index()
        {
            var model = new List<PersonaEntity>();
            var result = await Services.PersonaService.GetAllPersonas();
            if (result.Success)
            {
                model = result.Result;
            }
            else
            {
                ViewData["Message"] = result.Message;
            }
            return View(model);
        }

        // GET: Persona/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await Services.PersonaService.GetPersonaById(id);
            if (!model.Success)
            {
                ViewData["Message"] = model.Message;
                return RedirectToAction("Index");
            }
            model.Result.Id = id;
            return View(model.Result);
        }

        // GET: Persona/Create
        public async Task<ActionResult> Create()
        {
            var model = new PersonaUpdateModel();
            return View(model);
        }

        // POST: Persona/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                DateTime.TryParse(collection["FechaNacimiento"], out var fechaNacimiento);
                var model = new PersonaUpdateModel
                {
                    Identificacion = collection["Identificacion"],
                    Nombre = collection["Nombre"],
                    Apellidos = collection["Apellidos"],
                    FechaNacimiento = fechaNacimiento,
                    Direccion = collection["Direccion"],
                    Referencia = collection["Referencia"],
                    Ciudad = collection["Ciudad"],
                    Provincia = collection["Provincia"],
                    Pais = collection["Pais"],
                    CodigoPostal = collection["CodigoPostal"]                
                };
                
                var result = await Services.PersonaService.CrearPersona(model);
                if (!result.Success)
                {
                    ViewData["CreateForm"] = model;
                    throw new Exception(result.Message);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                var viewModel = ViewData["CreateForm"];
                return View(viewModel);
            }
        }

        // GET: Persona/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await Services.PersonaService.GetPersonaById(id);
            if (!model.Success)
            {
                ViewData["Message"] = model.Message;
                return RedirectToAction("Index");
            }
            model.Result.Id = id;
            return View(model.Result);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                DateTime.TryParse(collection["FechaNacimiento"], out var fechaNacimiento);
                var model = new PersonaUpdateModel
                {
                    Identificacion = collection["Identificacion"],
                    Nombre = collection["Nombre"],
                    Apellidos = collection["Apellidos"],
                    FechaNacimiento = fechaNacimiento,
                    Direccion = collection["Direccion"],
                    Referencia = collection["Referencia"],
                    Ciudad = collection["Ciudad"],
                    Provincia = collection["Provincia"],
                    Pais = collection["Pais"],
                    CodigoPostal = collection["CodigoPostal"]
                };

                if (!this.TryValidateModel(model))
                {
                    return View(model.ConvertTo<PersonaViewModel>());
                }

                var result = await Services.PersonaService.ActualizarPersona(id, model);
                if (!result.Success)
                {
                    ViewData["EditForm"] = model.ConvertTo<PersonaViewModel>();
                    throw new Exception(result.Message);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                var viewModel = ViewData["EditForm"];
                return View(viewModel);
            }
        }

        // GET: Persona/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await Services.PersonaService.GetPersonaById(id);
            if (!model.Success)
            {
                ViewData["Message"] = model.Message;
                return RedirectToAction("Index");
            }

            return View(model.Result);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                var result = await Services.PersonaService.EliminarPersona(id);
                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new ResultModel { Message = ex.Message, Success = false });
            }
        }

        // GET: Persona/CuentasBancarias/5
        public async Task<ActionResult> CuentasBancarias(int id)
        {
            var model = await Services.PersonaService.GetCuentaBancariasByPersonaId(id);

            return PartialView(model?.Result ?? new List<CuentaBancariaEntity>());
        }
    }
}
