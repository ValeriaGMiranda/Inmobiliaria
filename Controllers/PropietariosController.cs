using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Controllers
{
    public class PropietariosController : Controller
    {
        private readonly RepositorioPropietarios Repo;

        public PropietariosController()
        {
             Repo = new RepositorioPropietarios();
        }

        // GET: Propietarios
        public ActionResult Index()
        {
            var lista = Repo.ObtenerPropietarios();
            return View(lista);
        }

        // GET: Propietarios/Details/5
        public ActionResult Details(int id)
        {
            var entidad  = Repo.ObtenerPropietario(id);
            return View(entidad);
        }

        // GET: Propietarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propietarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Propietarios propietario)
        {
            try
            {
                var repo =  new RepositorioPropietarios();
                repo.Insertar(propietario);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Propietarios/Edit/5
        public ActionResult Edit(int id)
        {
            var entidad  = Repo.ObtenerPropietario(id);
            return View(entidad);
        }

        // POST: Propietarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Propietarios propietario)
        {
            try
            {
                Repo.Modificar(propietario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Propietarios/Delete/5
        public ActionResult Delete(int id)
        {
            var entidad  = Repo.ObtenerPropietario(id);
            return View(entidad);
        }

        // POST: Propietarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Propietarios propietario)
        {
            try
            {
                Repo.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}