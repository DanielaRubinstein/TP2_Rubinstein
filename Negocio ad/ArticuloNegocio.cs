using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio_ad
{
     public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos accesoDatos = new AccesoDatos();
            Articulo articulo;
            try
            {
                accesoDatos.SetearConsulta("Select art.IdArticulo, art.Nombre, art.Descripcion, M.Descripcion Marca, Pro.Nombre Proveedor, Cat.Descripcion Categoria, art.Imagen, art.Precio from ARTICULOS as art INNER JOIN Marcas as M on art.Marca = M.IdMarca INNER JOIN Proveedores as pro on art.Proveedor = pro.IdProveedor INNER JOIN ARTICULOS_X_CATEGORIAS as axc on art.IdArticulo = axc.IdArticulo INNER JOIN Categorias as cat on axc.IdCategoria = cat.IdCategoria where art.Estado = 1");
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    articulo = new Articulo();
                    articulo.IdArticulo = (int)accesoDatos.Lector["IdArticulo"];
                    articulo.Nombre = accesoDatos.Lector["Nombre"].ToString();
                    articulo.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
                    articulo.marca = new Marca();
                    articulo.marca.Descripcion = accesoDatos.Lector["Marca"].ToString();
                    articulo.categoria = new Categoria();
                    articulo.categoria.Descripcion = accesoDatos.Lector["Categoria"].ToString();
                    articulo.proveedor = new Proveedor();
                    articulo.proveedor.Descripcion = accesoDatos.Lector["Proveedor"].ToString();
                    articulo.Imagen = accesoDatos.Lector["Imagen"].ToString();
                    articulo.Precio = (decimal)accesoDatos.Lector["Precio"];
                    lista.Add(articulo);
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
