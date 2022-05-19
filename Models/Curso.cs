using System;
using System.Collections.Generic;


namespace ProyectoMVC.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Dirección { get; set; }

        public string EscuelaId { get; set; }   //El motor autamaticamente infiere que EscuelaId 
                                                //proviene del modelo Escuela y de su atributo Id 
                                                //ya que es un nombre por convención
        public Escuela Escuela { get; set; }
    }
}