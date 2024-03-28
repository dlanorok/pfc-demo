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
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace PFC.Demo.ClientApp.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public async Task<ActionResult> Index()
        {
            var model = new List<PersonaModel>();
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
            var model = new PersonaViewModel();
            await LoadCatalogos(model);
            return View("Edit", model);
        }

        // POST: Persona/Create
        [HttpPost]
        public async Task<ActionResult> Create(PersonaViewModel model)
        {
            try
            { 
                if (!ModelState.IsValid)
                {
                    throw new ValidationException("Hubo un error al guardar los datos!");
                }

                var data = model.ConvertTo<PersonaUpdateModel>();
                var result = await Services.PersonaService.CrearPersona(data);
                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
                await LoadCatalogos(model);
                return View("Edit", model);
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
            await LoadCatalogos(model.Result);
            return View(model.Result);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, PersonaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ValidationException("Hubo un error de validacion");
                }

                var data   = model.ConvertTo<PersonaUpdateModel>();
                var result = await Services.PersonaService.ActualizarPersona(id, data);
                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                await LoadCatalogos(model);
                return View(model);
            }
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
            var model = await Services.PersonaService.GetPersonaById(id);

            return PartialView(model?.Result ?? new PersonaViewModel());
        }

        private async Task LoadCatalogos(PersonaModel model)
        {
            var result = new
            {
                Paises = new List<PaisModel>(),
                Provincias = new List<ProvinciaModel>(),
                Ciudades = new List<CiudadModel>()
            };

            var paises = await CatalogoService.GetAllPaises();
            if (paises.Success)
            {
                result.Paises.AddRange(paises.Result);
            }

            var selectedPais = result.Paises.FirstOrDefault(x => x.Nombre.Equals(model.Pais?.Trim(), StringComparison.OrdinalIgnoreCase));

            if (selectedPais != null)
            {
                var provincias = await CatalogoService.GetProvinciasByPaisId(selectedPais.Id);
                if (provincias.Success)
                {
                    result.Provincias.AddRange(provincias.Result);


                    var selectedProvincia = result.Provincias.FirstOrDefault(x => x.Nombre.Equals(model.Provincia?.Trim(), StringComparison.OrdinalIgnoreCase));

                    if (selectedProvincia != null)
                    {
                        var ciudades = await CatalogoService.GetCiudadesByProvinciaId(selectedProvincia?.Id);
                        if (ciudades.Success)
                        {
                            result.Ciudades.AddRange(ciudades.Result);
                        }
                    }
                }
            }

            ViewData["paises"] = result.Paises;
            ViewData["provincias"] = result.Provincias;
            ViewData["ciudades"] = result.Ciudades;
        }
    }
}