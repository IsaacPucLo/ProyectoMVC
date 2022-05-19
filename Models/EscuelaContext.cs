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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "TecNM Campus Progreso";
            escuela.Ciudad = "Progreso";
            escuela.Pais = "México";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Dirección = "Boulevard 7ma";

            //Cargar cursos de la escuela
            var cursos = CargarCursos(escuela); //Se crearon los cursos pero aun no se mandan al esquema de datos

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            //SEMBRAMOS LOS DATOS EN LA BD
            modelBuilder.Entity<Escuela>().HasData(escuela); 
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray()); //debido a que le paso una lista y has data funciona con array debo hacer el casteo
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());

        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta= new List<Asignatura> ();

            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura>(){
                            new Asignatura
                        {
                            Id = Guid.NewGuid().ToString(),
                            CursoId = curso.Id,
                            Nombre = "Matemáticas"
                        },
                        new Asignatura
                        {
                            Id = Guid.NewGuid().ToString(),
                            CursoId = curso.Id,
                            Nombre = "Educación Física"
                        },
                        new Asignatura
                        {
                            Id = Guid.NewGuid().ToString(),
                            CursoId = curso.Id,
                            Nombre = "Castellano"
                        },
                        new Asignatura
                        {
                            Id = Guid.NewGuid().ToString(),
                            CursoId = curso.Id,
                            Nombre = "Ciencias Naturales"
                        },
                        new Asignatura
                        {
                            Id = Guid.NewGuid().ToString(),
                            CursoId = curso.Id,
                            Nombre = "Programacion"
                        }
                };
                listaCompleta.AddRange(tmpList);
            }
            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                        new Curso() {
                                    Id = Guid.NewGuid().ToString(),
                                    EscuelaId = escuela.Id,
                                    Nombre = "101",
                                    Jornada = TiposJornada.Mañana },
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Tarde},
            };
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
        {
            string[] nombre1 = { "Isaac", "Karol", "Jerry", "Lupita", "Guadalupe", "Nina", "Giselle" };
            string[] apellido1 = { "Puc", "López", "Rojas", "Endes", "Osorno", "Lira", "Herrera" };
            string[] nombre2 = { "Tatiana", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}", 
                                                   CursoId = curso.Id,
                                                   Id = Guid.NewGuid().ToString() 
                                                  };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }
    }
}