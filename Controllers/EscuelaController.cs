using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        private EscuelaContext _context;
        public IActionResult Index()
        {
            ViewBag.CosaDinamica = "La monja";

            var escuela = _context.Escuelas.FirstOrDefault();

            return View(escuela);  //Se manda el objeto escuela como parámetro a la vista, para poder hacer uso de la información de escuela en la vista, en este caso imprimir la información
        }

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}