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

namespace Presentacion
{
    public partial class frmArticulo : Form
    {
        private Articulo articulo = null;
        bool modificado = false;
        string imgLocation = "";
        public frmArticulo()
        {
            InitializeComponent();
        }

        public frmArticulo(Articulo art)
        {
            InitializeComponent();
            articulo = art;
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            try
            {
                cbMarca.DataSource = marcaNegocio.listar();
                cbMarca.ValueMember = "IdMarca";
                cbMarca.DisplayMember = "Descripcion";
                cbMarca.SelectedIndex = -1;

                cbCategoria.DataSource = categoriaNegocio.listar();
                cbCategoria.ValueMember = "IdCategoria";
                cbCategoria.DisplayMember = "Descripcion";
                cbCategoria.SelectedIndex = -1;

                cbProveedor.DataSource = proveedorNegocio.listar();
                cbProveedor.ValueMember = "IdProveedor";
                cbProveedor.DisplayMember = "Descripcion";
                cbProveedor.SelectedIndex = -1;

                if (articulo != null)
                {
                    tbNombre.Text = articulo.Nombre;
                    tbDescripcion.Text = articulo.Descripcion;
                    cbMarca.Text = articulo.Marca.Descripcion;
                    cbCategoria.Text = articulo.Categoria.Descripcion;
                    cbProveedor.Text = articulo.Proveedor.Descripcion;
                    tbPrecio.Text = articulo.Precio.ToString();
                    pbImagen.ImageLocation = articulo.Imagen;
                    if (articulo.Marca != null)
                    {
                        cbMarca.SelectedValue = articulo.Marca.IdMarca;
                    }
                    //if(articulo.categoria!=null)
                    //{
                    //    cbCategoria.SelectedValue = articulo.categoria.IdCategoria;
                    //}
                    //if (articulo.proveedor != null)
                    //{
                    //    cbProveedor.SelectedValue = articulo.proveedor.IdProveedor;
                    //}
                    modificado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                //validaciones
                if (tbNombre.Text.Trim() == "" || tbDescripcion.Text.Trim() == "" || cbMarca.Text.Trim() == "")
                {
                    MessageBox.Show("Estos datos son obligatorios");
                    return;
                }
                else
                {
                    if (articulo == null)
                    {
                        articulo = new Articulo();
                        articulo.Nombre = tbNombre.Text;
                        articulo.Descripcion = tbDescripcion.Text;
                        articulo.Marca = (Marca)cbMarca.SelectedItem;
                        articulo.Categoria = (Categoria)cbCategoria.SelectedItem;
                        articulo.Proveedor = (Proveedor)cbProveedor.SelectedItem;
                        articulo.Precio = decimal.Parse(tbPrecio.Text);
                        articulo.Imagen = imgLocation.ToString();
                    }
                    if (articulo.IdArticulo !=0 && modificado == true)
                    {
                        articulo.Nombre = tbNombre.Text;
                        articulo.Descripcion = tbDescripcion.Text;
                        articulo.Marca = (Marca)cbMarca.SelectedItem;
                        articulo.Categoria = (Categoria)cbCategoria.SelectedItem;
                        articulo.Proveedor = (Proveedor)cbProveedor.SelectedItem;
                        articulo.Precio = decimal.Parse(tbPrecio.Text);
                        articulo.Imagen = imgLocation.ToString();
                        articulo.Estado = true;

                        articuloNegocio.modificarArticulo(articulo);
                        MessageBox.Show("Modificado correctamente");
                    }
                    else
                    {
                        articuloNegocio.agregarArticulo(articulo);
                        MessageBox.Show("Agregado correctamente");
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            Close();
        }

        private void BtnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pbImagen.ImageLocation = imgLocation;
            }
        }
    }
}
