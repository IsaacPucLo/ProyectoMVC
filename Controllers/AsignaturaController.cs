using System;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index(){

            var asignatura = new Asignatura{
                UniqueId = Guid.NewGuid().ToString(),
                Nombre = "Programación"

            };
            

            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;
            
            return View(asignatura);  //Se manda el objeto escuela como parámetro a la vista, para poder hacer uso de la información de escuela en la vista, en este caso imprimir la información
        }
    }
}