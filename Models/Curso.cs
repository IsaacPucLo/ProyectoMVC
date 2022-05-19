using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoMVC.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "El nombre del curso es requerido")]  //Usando data anotations el atributo nombre será siempre requerído
        [StringLength(5)]
        public override string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        
        [Display(Prompt = "Dirección correspondencia", Name="Adress")]
        [Required(ErrorMessage = "Se requiere incluir una direccion")]
        [MinLength(2, ErrorMessage = "La longitud minima de la dirección es 2")]
        public string Dirección { get; set; }

        public string EscuelaId { get; set; }   //El motor autamaticamente infiere que EscuelaId 
                                                //proviene del modelo Escuela y de su atributo Id 
                                                //ya que es un nombre por convención
        public Escuela Escuela { get; set; }
    }
}