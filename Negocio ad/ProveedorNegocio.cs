using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio_ad
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos accesoDatos = new AccesoDatos();
            Proveedor proveedor;

            try
            {
                accesoDatos.SetearConsulta("select IdProveedor, Nombre from proveedores");
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    proveedor = new Proveedor();
                    proveedor.IdProveedor = (int)accesoDatos.Lector["IdProveedor"];
                    proveedor.Descripcion = accesoDatos.Lector["Nombre"].ToString();
                    lista.Add(proveedor);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

        }

    }
}
