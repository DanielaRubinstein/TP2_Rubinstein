using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio_ad
{
    public class MarcaNegocio
    {
        //public List<Marca> listar()
        //{
        //    List<Marca> lista = new List<Marca>();
        //    AccesoDatos accesoDatos = new AccesoDatos();
        //    Marca marca;
        //    try
        //    {
        //        accesoDatos.SetearConsulta("Select ");
        //        accesoDatos.AbrirConexion();
        //        accesoDatos.ejecutarConsulta();

        //        while (accesoDatos.Lector.Read())
        //        {
        //            marca = new Marca();
        //            marca.IdMarca = (int)accesoDatos.Lector["IdMarca"];
        //            marca.Descripcion = accesoDatos.Lector["Descripcion"].ToString();
        //            lista.Add(marca);
        //        }
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        accesoDatos.cerrarConexion();
        //    }
        //}

    }
}
