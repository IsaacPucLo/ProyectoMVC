using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProyectoMVC.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "TecNM Campus Progreso";
            escuela.Ciudad = "Progreso";
            escuela.Pais = "México";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Dirección = "Boulevard 7ma";
            
            modelBuilder.Entity<Escuela>().HasData(escuela);

            modelBuilder.Entity<Asignatura>().HasData( 
                new Asignatura {
                Nombre = "Matemáticas",
                Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                Nombre = "Educación Física",
                Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                Nombre = "Castellano",
                Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                Nombre = "Ciencias Naturales",
                Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                Nombre = "Programacion",
                Id = Guid.NewGuid ().ToString ()
                }
            );

            modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar().ToArray() ); 
                                                            //HasData SIEMPRE requiere que lo que 
                                                            //le mande sea un array, por lo tanto 
                                                            //tenemos que hacerle cast al resultado 
                                                            //del metodo, ya que este nos devuelve 
                                                            //una Lista
        }

        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Isaac", "Karol", "Jerry", "Lupita", "Guadalupe", "Nina", "Giselle" };
            string[] apellido1 = { "Puc", "López", "Rojas", "Endes", "Osorno", "Lira", "Herrera" };
            string[] nombre2 = { "Tatiana", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}", Id = Guid.NewGuid().ToString() };

            return listaAlumnos.OrderBy((al) => al.Id).ToList();
        }

    }
}