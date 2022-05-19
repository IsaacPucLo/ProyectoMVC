using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        
        public IActionResult Index()
        {
            return View(_context.Asignaturas.FirstOrDefault());  
        }
        public IActionResult MultiAsignatura()
        {
            return View("MultiAsignatura",_context.Asignaturas); 
        }

        private EscuelaContext _context;

        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}