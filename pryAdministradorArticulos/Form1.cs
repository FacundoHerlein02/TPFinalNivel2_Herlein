using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;
using System.Data.SqlTypes;

namespace pryAdministradorArticulos
{
    public partial class frmPrincipal : Form
    {
        private List<Articulo> listaArticulos;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarGrillas();
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoría");
            cboCampo.Items.Add("Código");
            cboCampo.Items.Add("Precio");

        }
        private void CargarGrillas()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = new List<Articulo>();
            try
            {                
                listaArticulos = negocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                //Carga la primera imagen de la lista
                cargarImagen(listaArticulos[0].UrlImagen);                
                OcultarColumnas();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                //Si anda carga la imagen
                pctArticulo.Load(imagen);
            }
            catch (Exception)
            {
                //Si no carga una imagen de error
                pctArticulo.Load("https://www.unitedfoodservice.au/Images/ProductImages/product-image-1.png");
            }
        }
        private void OcultarColumnas()
        {
            //Hace invisible las columnas
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            //Define el formato moneda en la celda
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C2";
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow!=null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo altaArticulo = new frmAltaArticulo();
            altaArticulo.ShowDialog();
        }
    }
}
