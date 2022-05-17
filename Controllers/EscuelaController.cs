using System;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index(){

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "TecNM Campus Progreso";
            escuela.Ciudad = "Progreso";
            escuela.Pais = "México";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Dirección = "Boulevard 7ma";

            ViewBag.CosaDinamica = "La monja";
            
            return View(escuela);  //Se manda el objeto escuela como parámetro a la vista, para poder hacer uso de la información de escuela en la vista, en este caso imprimir la información
        }
    }
}