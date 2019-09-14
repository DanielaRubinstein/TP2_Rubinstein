using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
