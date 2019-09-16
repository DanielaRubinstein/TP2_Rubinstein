using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }

        //public Marca() { }
        //public Marca(int idMarca, string desc)
        //{
        //    IdMarca = idMarca;
        //    Descripcion = desc;
        //}
        public Marca() { }

        public Marca(string marca)
        {
            Descripcion = marca;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
