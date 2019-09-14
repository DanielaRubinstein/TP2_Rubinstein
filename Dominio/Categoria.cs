using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }

        //public Categoria() { }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
