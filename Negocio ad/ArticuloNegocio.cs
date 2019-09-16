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
                accesoDatos.SetearConsulta("Select art.IdArticulo, art.Nombre, art.Descripcion, M.Descripcion Marca, Pro.Nombre Proveedor, Cat.Descripcion Categoria, art.Imagen, art.Precio from ARTICULOS as art INNER JOIN Marcas as M on art.Marca = M.IdMarca INNER JOIN Proveedores as pro on art.Proveedor = pro.IdProveedor INNER JOIN Categorias as cat on art.Categoria=cat.IdCategoria where art.Estado = 1");
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    articulo = new Articulo();
                    articulo.IdArticulo = (int)accesoDatos.Lector["IdArticulo"];
                    articulo.Nombre = accesoDatos.Lector["Nombre"].ToString();
                    articulo.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
                    articulo.Marca = new Marca();
                    articulo.Marca.Descripcion = accesoDatos.Lector["Marca"].ToString();
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Descripcion = accesoDatos.Lector["Categoria"].ToString();
                    articulo.Proveedor = new Proveedor();
                    articulo.Proveedor.Descripcion = accesoDatos.Lector["Proveedor"].ToString();
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

        public void modificarArticulo(Articulo articuloModificado)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.SetearConsulta("update ARTICULOS set Nombre=@Nombre,Descripcion=@Descripcion,Marca=@Marca,Categoria=@Categoria,Proveedor=@Proveedor,Imagen=@Imagen,Precio=@Precio where IdArticulo=" + articuloModificado.IdArticulo);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre",articuloModificado.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", articuloModificado.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@Marca", articuloModificado.Marca.IdMarca); //combobox marca
                accesoDatos.Comando.Parameters.AddWithValue("@Categoria", articuloModificado.Categoria.IdCategoria); //combobox categoria
                accesoDatos.Comando.Parameters.AddWithValue("@Proveedor", articuloModificado.Proveedor.IdProveedor); //combobox proveedor
                accesoDatos.Comando.Parameters.AddWithValue("@Imagen", articuloModificado.Imagen);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", articuloModificado.Precio);
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarAccion();
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

        public void agregarArticulo(Articulo articuloNuevo)
        {
            AccesoDatos accesoDatos = null;
            try
            {
                accesoDatos = new AccesoDatos();
                accesoDatos.SetearConsulta("insert into ARTICULOS (Nombre,Descripcion,Marca,Categoria,Proveedor,Imagen,Precio,Estado) values (@Nombre,@Descripcion,@Marca,@Categoria,@Proveedor,@Imagen,@Precio,1)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", articuloNuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", articuloNuevo.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@Marca", articuloNuevo.Marca.IdMarca);
                accesoDatos.Comando.Parameters.AddWithValue("@Categoria", articuloNuevo.Categoria.IdCategoria);
                accesoDatos.Comando.Parameters.AddWithValue("@Proveedor", articuloNuevo.Proveedor.IdProveedor);
                accesoDatos.Comando.Parameters.AddWithValue("@Imagen", articuloNuevo.Imagen);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", articuloNuevo.Precio);
                accesoDatos.Comando.Parameters.AddWithValue("@Estado", articuloNuevo.Estado);

                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (accesoDatos != null)
                    accesoDatos.cerrarConexion();
            }

        }

        public void eliminarArticulo(Articulo ArticuloEliminar)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.SetearConsulta("update ARTICULOS set Estado=@Estado where IdArticulo="+ArticuloEliminar.IdArticulo);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Estado", ArticuloEliminar.Estado);
                accesoDatos.AbrirConexion();
                accesoDatos.ejecutarAccion();
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
