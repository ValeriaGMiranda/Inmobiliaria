using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Controllers
{
    public class InquilinosController : Controller
    {
        private readonly RepositorioInquilinos Repo;

        public InquilinosController()
        {
             Repo = new RepositorioInquilinos();
        }
        
        // GET: Inquilinos
        public ActionResult Index()
        {
            var lista = Repo.ObtenerInquilinos();
            return View(lista);
        }

        // GET: Inquilinos/Details/5
        public ActionResult Details(int id)
        {
            var entidad  = Repo.ObtenerInquilino(id);
            return View(entidad);
        }

        // GET: Inquilinos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquilinos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilinos inquilino)
        {
            try
            {
                var repo =  new RepositorioInquilinos();
                repo.Insertar(inquilino);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Edit/5
        public ActionResult Edit(int id)
        {
            var entidad  = Repo.ObtenerInquilino(id);
            return View(entidad);
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inquilinos inquilino)
        {
            try
            {
                Repo.Modificar(inquilino);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Delete/5
        public ActionResult Delete(int id)
        {
            var entidad  = Repo.ObtenerInquilino(id);
            return View(entidad);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inquilinos inquilino)
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