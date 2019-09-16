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
               // dgvPrincipal.Columns[4].Visible = false; //categoria
                dgvPrincipal.Columns[5].Visible = false; //proveedor
                dgvPrincipal.Columns[6].Visible = false; //imagen
               // dgvPrincipal.Columns[7].Visible = false; //precio
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

        private void BtnVer_Click(object sender, EventArgs e)
        {
            Articulo verDetalle;
            verDetalle = (Articulo)dgvPrincipal.CurrentRow.DataBoundItem;
            string ar = verDetalle.Imagen;
            frmDetalle detalleArticulo = new frmDetalle(verDetalle);
            detalleArticulo.ShowDialog();

            //Articulo articulo = new Articulo();
            //try
            //{
            //    articulo = (Articulo)dgvPrincipal.CurrentRow.DataBoundItem;
            //    string ar = articulo.Imagen;

            //    frmArticulo detalleArticulo = new frmArticulo((Articulo)dgvPrincipal.CurrentRow.DataBoundItem);
            //    detalleArticulo.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            frmArticulo formularioArticulo = new frmArticulo();
            formularioArticulo.ShowDialog();
            cargarGrilla();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            try
            {
                articulo = (Articulo)dgvPrincipal.CurrentRow.DataBoundItem;
                string art = articulo.Imagen;

                frmArticulo articuloModificar = new frmArticulo((Articulo)dgvPrincipal.CurrentRow.DataBoundItem);
                articuloModificar.ShowDialog();
                cargarGrilla();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();

            try
            {
                DialogResult resultado = MessageBox.Show("Esta seguro que desea eliminar?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(resultado == DialogResult.Yes)
                {
                    articulo = (Articulo)dgvPrincipal.CurrentRow.DataBoundItem;
                    articulo.Estado = false;
                    articuloNegocio.eliminarArticulo(articulo);
                    cargarGrilla();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void TbBuscar_KeyPress(object sender, EventArgs e)
        {
            if(tbBuscar.Text == "")
            {
                dgvPrincipal.DataSource = articuloListado;
            }
            else
            {
                List<Articulo> lista;
                lista = articuloListado.FindAll(AUXILIAR => AUXILIAR.Nombre.ToLower().Contains(tbBuscar.Text.ToLower()) || AUXILIAR.Marca.Descripcion.ToLower().Contains(tbBuscar.Text.ToLower()) ||AUXILIAR.Categoria.Descripcion.ToLower().Contains(tbBuscar.Text.ToLower()));
                dgvPrincipal.DataSource = lista;

            }

        }

    }
}
