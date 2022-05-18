using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        
        public IActionResult Index()
        {

            var alumno = new Alumno
            {
                UniqueId = Guid.NewGuid().ToString(),
                Nombre = "Isaac Puc"
            };

            ViewBag.Fecha = DateTime.Now;

            return View(alumno);  
        }
        public IActionResult MultiAlumno()
        {

            var listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAlumno",listaAlumnos);  //Se especifica que va a lanzar la vista con el nombre entre comillas
        }
    
         private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Isaac", "Karol", "Jerry", "Lupita", "Guadalupe", "Nina", "Giselle" };
            string[] apellido1 = { "Puc", "López", "Rojas", "Endes", "Osorno", "Lira", "Herrera" };
            string[] nombre2 = { "Tatiana", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}", UniqueId = Guid.NewGuid().ToString() };

            return listaAlumnos.OrderBy((al) => al.UniqueId).ToList();
        }
    }
}