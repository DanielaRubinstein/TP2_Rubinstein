using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio_ad;
using System.Data.SqlClient;

namespace Presentacion
{
    public partial class frmDetalle : Form
    {
        private Articulo articulo = null;
        public frmDetalle()
        {
            InitializeComponent();
        }

        public frmDetalle(Articulo art)
        {
            InitializeComponent();
            articulo = art;
        }


        private void frmDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                if (articulo != null)
                {
                    tbNombre.Text = articulo.Nombre;
                    tbDescripcion.Text = articulo.Descripcion;
                    tbMarca.Text = articulo.Marca.Descripcion;
                    tbCategoria.Text = articulo.Categoria.Descripcion;
                    tbProveedor.Text = articulo.Proveedor.Descripcion;
                    tbPrecio.Text = articulo.Precio.ToString();
                    pbImagen.ImageLocation = articulo.Imagen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }





    }
}
