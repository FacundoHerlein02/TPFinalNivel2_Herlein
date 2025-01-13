using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace pryAdministradorArticulos
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo Articulo = null;       
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.Articulo = articulo;
            Text = "Modificar Artículo";            
        }
        public frmAltaArticulo(Articulo art,bool detalle)
        {
            if(detalle==true)
            {
                InitializeComponent ();
                this.Articulo = art;
                Text = "Detalle Artículo";
                txtCodigo.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                cboCategoria.Enabled = false;
                cboMarca.Enabled = false;
                txtUrlImagen.ReadOnly = true;
                txtPrecio.ReadOnly = true;
                btnAceptar.Visible = false;                
                btnCancelar.Text = "Cerrar";
                btnCancelar.Location = new Point((this.ClientSize.Width - btnCancelar.Width) / 2,347); // Centrar verticalmente
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            ArticuloNegocio negocioArticulo = new ArticuloNegocio();            
            try
            {
                if(Articulo ==null) //si es null genera una instancia
                    Articulo = new Articulo();                
                Articulo.Codigo = txtCodigo.Text;//Sino usa la instancia de parametro
                Articulo.Nombre = txtNombre.Text;
                Articulo.Descripcion = txtDescripcion.Text;
                Articulo.Marca = (Marca)cboMarca.SelectedItem;
                Articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                Articulo.UrlImagen = txtUrlImagen.Text;
                if (!String.IsNullOrEmpty(txtPrecio.Text))
                {
                    Articulo.Precio = float.Parse(txtPrecio.Text);
                }
                else
                {
                    //Pone el precio en 0 si no cargas nada
                    Articulo.Precio= 0;
                }
                //Si el id es 0 esta agregando
                if(Articulo.Id==0)
                {
                    //Agrega el Artiuclo
                    negocioArticulo.Agregar(Articulo);
                    MessageBox.Show("Agregado correctamente","Agregar artículo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    //Modifica el Articulo
                    negocioArticulo.modificar(Articulo);
                    MessageBox.Show("Modificado correctamente", "Modificar artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        private void CargarImagen(string url)
        {
            try
            {
                //Si anda carga la imagen
                pctImagen.Load(url);
            }
            catch (Exception)
            {
                //Si no carga una imagen de error
                pctImagen.Load("https://www.unitedfoodservice.au/Images/ProductImages/product-image-1.png");
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocioM= new MarcaNegocio();
            CategoriaNegocio negocioC= new CategoriaNegocio();  
            try
            {                
                cboMarca.DataSource = negocioM.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = negocioC.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";                
                if(Articulo!=null)
                {
                    //Carga los datos del Articulo
                    txtCodigo.Text = Articulo.Codigo;
                    txtNombre.Text = Articulo.Nombre;
                    txtDescripcion.Text = Articulo.Descripcion;
                    cboMarca.SelectedValue = Articulo.Marca.Id;
                    cboCategoria.SelectedValue = Articulo.Categoria.Id;
                    txtUrlImagen.Text = Articulo.UrlImagen;
                    CargarImagen(Articulo.UrlImagen);
                    txtPrecio.Text = Articulo.Precio.ToString("0.00");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && e.KeyChar!= ',' && e.KeyChar!=(char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            //Intenta cargar la imagen
            CargarImagen(txtUrlImagen.Text);
        }
    }
}
