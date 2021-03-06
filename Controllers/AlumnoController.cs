using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        
        public IActionResult Index(string id)   //Usar el nombre "id" para el parámetro, ya que así lo dicta la convención
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var alumno = from alum in _context.Alumnos
                            where alum.Id == id
                            select alum;

                return View(alumno.SingleOrDefault());  
            }
            else{
                return View("MultiAlumno",_context.Alumnos); 
            }
        }
        
        public IActionResult MultiAlumno()
        {
            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAlumno",_context.Alumnos);
        }

        private EscuelaContext _context;

        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}