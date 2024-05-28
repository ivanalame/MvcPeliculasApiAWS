using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using MvcPeliculasApiAWS.Models;
using MvcPeliculasApiAWS.Service;

namespace MvcPeliculasApiAWS.Controllers
{
    public class PeliculasController : Controller
    {
        private ServiceApiPeliculas service;

        public PeliculasController(ServiceApiPeliculas service)
        {
            this.service = service;
        }
        public async Task <IActionResult> Index()
        {
            List<Pelicula>peliculas = await this.service.GetPeliculasAsync();
            return View(peliculas);
        }

        public IActionResult PeliculasActor()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult>PeliculasActor(string actor)
        {
            List<Pelicula> peliculas = await this.service.GetPeliculasActoresAsync(actor);
            return View(peliculas);
        }
        public async Task<IActionResult>Details (int id)
        {
            Pelicula pelicula = await this.service.FindPeliculaAsync(id);
            return View(pelicula);
        }
        public  IActionResult CreatePelicula()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePelicula(Pelicula pel)
        {
            await this.service.CreatePelicula(pel);
            return RedirectToAction("Index");
        }

        public async Task <IActionResult>UpdatePelicula(int id)
        {
            Pelicula pel = await this.service.FindPeliculaAsync(id);
            return View(pel);
        }
        [HttpPost]
        public async Task<IActionResult>UpdatePelicula(Pelicula pel)
        {
            await this.service.UpdatePelicula(pel);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>DeletePelicula(int id)
        {
            await this.service.DeletePelicula(id);
            return RedirectToAction("Index");
        }
    }
}
