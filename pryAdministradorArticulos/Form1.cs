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
            cboCampo.Items.Add("Categoría");                       
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Nombre");
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
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["Codigo"].Visible = false;
            //Define el formato moneda en la celda
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C2";
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            //Actualiza las grillas 
            CargarGrillas();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada= new List<Articulo>();
            string filtro=txtFiltro.Text;
            if(filtro.Length>=3 && filtro !="")
            {                
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper())
                || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            OcultarColumnas();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio= new ArticuloNegocio();
            try
            {
                if(cboCampo.SelectedItem.ToString()=="Marca" && lblCriterio.Text.Equals("Marcas"))
                {
                    string campo= cboCampo.SelectedItem.ToString();
                    string criterio=  "Contiene";
                    string filtro = cboCriterio.SelectedItem.ToString();
                    dgvArticulos.DataSource=null;
                    dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
                    OcultarColumnas();
                }
                else 
                {
                    if (ValidarCampos())
                    {
                        string campo = cboCampo.SelectedItem.ToString();
                        string criterio = cboCriterio.SelectedItem.ToString();
                        string filtro = txtFiltroAvanzado.Text;
                        dgvArticulos.DataSource = null;
                        dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
                        OcultarColumnas();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un elemento de la lista desplegable", "Error en Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //if(ValidarCampos())
                //{
                //    string campo = cboCampo.SelectedItem.ToString();
                //    string criterio = cboCriterio.SelectedItem.ToString();
                //    string filtro = txtFiltroAvanzado.Text;
                //    dgvArticulos.DataSource = null;
                //    dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
                //    OcultarColumnas();
                //}
                //else
                //{
                //    MessageBox.Show("Debe seleccionar un elemento de la lista desplegable","Error en Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool ValidarCampos()
        {
            bool res = false; //No hay nada seleccionado
            if (cboCampo.SelectedIndex >= 0 && cboCriterio.SelectedIndex>=0)
            {
                res= true;//Hay seleccionado
            }
            return res;
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selec = cboCampo.SelectedItem.ToString();
            if (selec== "Precio")
            {
                cboCriterio.DataSource = null;
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Igual a");
                txtFiltroAvanzado.Clear();
                lblCriterio.Text = "Criterio";
                lblFiltroAvanzado.Visible = true;
                txtFiltroAvanzado.Visible = true;
            }
            else if(selec== "Marca")
            {
                lblCriterio.Text = "Marcas";
                lblFiltroAvanzado.Visible = false;
                txtFiltroAvanzado.Visible = false;
                cboCriterio.Items.Clear();
                MarcaNegocio negocio= new MarcaNegocio();
                try
                {                    
                    cboCriterio.DataSource=negocio.listar();
                }
                catch (Exception)
                {

                    throw;
                }


            }
            else
            {
                cboCriterio.DataSource = null;
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
                lblCriterio.Text = "Criterio";
                lblFiltroAvanzado.Visible = true;
                txtFiltroAvanzado.Visible = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow!=null)
            {
                Articulo seleccionado;
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaArticulo altaArticulo = new frmAltaArticulo(seleccionado);
                altaArticulo.ShowDialog();
                //ActuAliza las grillas al cerrar el form
                CargarGrillas();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un artículo", "Modificar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if(dgvArticulos.CurrentRow!=null)
            {
                Articulo selec;
                selec = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                DialogResult respuesta;
                respuesta = MessageBox.Show("¿Desea eliminar el artículo código: "+selec.Codigo+"?", "Eliminar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta==DialogResult.Yes)
                {
                    negocio.eliminar(selec.Id);
                    CargarGrillas();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un artículo", "Eliminar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            //Si pulsa F2 Muestra el detalle
            if (e.KeyCode==Keys.F2)
            {
                bool detalle = true;
                Articulo selec;
                selec = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaArticulo frmAltaArticulo = new frmAltaArticulo(selec,detalle);
                frmAltaArticulo.ShowDialog();
            }
        }

        private void txtFiltroAvanzado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cboCampo.SelectedItem!=null && cboCampo.SelectedItem.ToString()=="Precio")
            {
                if(!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back &&e.KeyChar!= ',')
                {
                    e.Handled = true;
                }
            }
        }
        
    }
}
