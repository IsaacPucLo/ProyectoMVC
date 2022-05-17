using Microsoft.AspNetCore.Mvc;

namespace ProyectoMVC.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index(){
            
            return View();  //Sino se le especifica que vista devuelve entonces devuelve el mismo Index
        }
    }
}