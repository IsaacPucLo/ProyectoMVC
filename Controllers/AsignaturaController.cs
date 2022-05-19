using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;

namespace ProyectoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        [Route("Asignatura/Index")]                     //Podemos hacer este enrutamiento que funcionará
        [Route("Asignatura/Index/{asignaturaId}")]      //para ejecutar nuestas vistas al momento de ejecutarlas en el buscador

        //public IActionResult Index(string id)   Usar el nombre "id" para el parámetro, ya que así lo dicta la convención
        public IActionResult Index(string asignaturaId) //Se me permite no usar la conveción porque yo defino una nueva arriba con [Route]
        {
            if (!string.IsNullOrWhiteSpace(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas
                            where asig.Id == asignaturaId
                            select asig;

                return View(asignatura.SingleOrDefault());  
            }
            else{
                return View("MultiAsignatura",_context.Asignaturas); 
            }
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