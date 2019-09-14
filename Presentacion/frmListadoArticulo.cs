using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio_ad;
using Dominio;

namespace Presentacion
{
    public partial class frmListadoArticulo : Form
    {
        private List<Articulo> articuloListado;
        public frmListadoArticulo()
        {
            InitializeComponent();
        }



        private void cargarGrilla()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                articuloListado = articuloNegocio.listar();
                dgvPrincipal.DataSource = articuloListado;
                dgvPrincipal.Columns[2].Visible = false; //descripcion
                dgvPrincipal.Columns[4].Visible = false; //categoria
                dgvPrincipal.Columns[6].Visible = false; //imagen
                dgvPrincipal.Columns[7].Visible = false; //precio
                dgvPrincipal.Columns[8].Visible = false; //estado
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmListadoArticulo_Load(object sender, EventArgs e)

        {
            cargarGrilla();
        }



    }
}
