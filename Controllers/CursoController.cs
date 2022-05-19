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

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }

        [HttpPost]      //Se ejecuta cuando es llamada la vista por POST que en este caso es el formulario en Create.cshtml quien lo hace 
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;
            
            if (ModelState.IsValid) //Verifica que los requerimientos sean completados y lo toma valido
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;       //Definimos a que escuela se le agrega el curso

                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MensajeExtra = "Curso creado";  //Parametro mandado como validación a la vista

                return View("Index", curso);    //Si se logra crear manda la vista index con el parámetro del curso creado para que lo muestre
            }
            else{
                return View(curso);
            }
        }

        private EscuelaContext _context;

        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}