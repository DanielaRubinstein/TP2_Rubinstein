using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public Proveedor proveedor { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }

        //public override string ToString()
        //{
        //    return IdArticulo + "," + Nombre;
        //}

        //public Articulo()
        //{
        //    this.marca = new Marca();
        //    this.categoria = new Categoria();
        //}

    }
}
