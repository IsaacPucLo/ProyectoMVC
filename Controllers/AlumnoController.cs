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
            return View(_context.Alumnos.FirstOrDefault());  
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