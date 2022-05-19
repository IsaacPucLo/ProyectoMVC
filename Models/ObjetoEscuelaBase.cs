using System;

namespace ProyectoMVC.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }
        public virtual string Nombre { get; set; }  //virtual deja que las clases hijas reescriban este atributo

        public ObjetoEscuelaBase()
        {
            //UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}