using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio_ad
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos accesoDatos = new AccesoDatos();
            Categoria categoria;

            try
            {
                accesoDatos.SetearConsulta("select IdCategoria, Descripcion from Categorias");
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    categoria = new Categoria();
                    categoria.IdCategoria = (int)accesoDatos.Lector["IdCategoria"];
                    categoria.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
                    lista.Add(categoria);
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
