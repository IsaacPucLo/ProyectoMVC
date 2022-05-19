using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class CursoController : Controller
    {
        
        public IActionResult Index(string id)   //Usar el nombre "id" para el parámetro, ya que así lo dicta la convención
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var curso = from curs in _context.Cursos
                            where curs.Id == id
                            select curs;

                return View(curso.SingleOrDefault());  
            }
            else{
                return View("MultiCurso",_context.Cursos); 
            }
        }
        
        public IActionResult MultiCurso()
        {
            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiCurso",_context.Cursos);
        }

        private EscuelaContext _context;

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}