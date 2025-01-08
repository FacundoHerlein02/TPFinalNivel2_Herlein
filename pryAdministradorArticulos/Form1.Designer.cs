namespace pryAdministradorArticulos
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.grbArticulos = new System.Windows.Forms.GroupBox();
            this.pctArticulo = new System.Windows.Forms.PictureBox();
            this.lblFiltroAvanzado = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblcampo = new System.Windows.Forms.Label();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.grbArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(6, 19);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(733, 287);
            this.dgvArticulos.TabIndex = 0;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(93, 447);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(354, 447);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(688, 447);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(169, 12);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(545, 20);
            this.txtFiltro.TabIndex = 4;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(91, 13);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(46, 16);
            this.lblFiltro.TabIndex = 5;
            this.lblFiltro.Text = "Filtro:";
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(809, 336);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(114, 23);
            this.btnFiltro.TabIndex = 6;
            this.btnFiltro.Text = "Filtro Avanzado";
            this.btnFiltro.UseVisualStyleBackColor = true;
            // 
            // grbArticulos
            // 
            this.grbArticulos.Controls.Add(this.pctArticulo);
            this.grbArticulos.Controls.Add(this.lblFiltroAvanzado);
            this.grbArticulos.Controls.Add(this.lblCriterio);
            this.grbArticulos.Controls.Add(this.lblcampo);
            this.grbArticulos.Controls.Add(this.txtFiltroAvanzado);
            this.grbArticulos.Controls.Add(this.cboCriterio);
            this.grbArticulos.Controls.Add(this.cboCampo);
            this.grbArticulos.Controls.Add(this.dgvArticulos);
            this.grbArticulos.Controls.Add(this.btnFiltro);
            this.grbArticulos.Location = new System.Drawing.Point(12, 50);
            this.grbArticulos.Name = "grbArticulos";
            this.grbArticulos.Size = new System.Drawing.Size(973, 382);
            this.grbArticulos.TabIndex = 7;
            this.grbArticulos.TabStop = false;
            this.grbArticulos.Text = "Lista Artículos";
            // 
            // pctArticulo
            // 
            this.pctArticulo.Location = new System.Drawing.Point(745, 19);
            this.pctArticulo.Name = "pctArticulo";
            this.pctArticulo.Size = new System.Drawing.Size(222, 287);
            this.pctArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctArticulo.TabIndex = 13;
            this.pctArticulo.TabStop = false;
            // 
            // lblFiltroAvanzado
            // 
            this.lblFiltroAvanzado.AutoSize = true;
            this.lblFiltroAvanzado.Location = new System.Drawing.Point(572, 341);
            this.lblFiltroAvanzado.Name = "lblFiltroAvanzado";
            this.lblFiltroAvanzado.Size = new System.Drawing.Size(83, 13);
            this.lblFiltroAvanzado.TabIndex = 12;
            this.lblFiltroAvanzado.Text = "Filtro Avanzado:";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(238, 343);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(42, 13);
            this.lblCriterio.TabIndex = 11;
            this.lblCriterio.Text = "Criterio:";
            // 
            // lblcampo
            // 
            this.lblcampo.AutoSize = true;
            this.lblcampo.Location = new System.Drawing.Point(24, 332);
            this.lblcampo.Name = "lblcampo";
            this.lblcampo.Size = new System.Drawing.Size(43, 13);
            this.lblcampo.TabIndex = 10;
            this.lblcampo.Text = "Campo:";
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(672, 339);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroAvanzado.TabIndex = 9;
            // 
            // cboCriterio
            // 
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(303, 336);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(121, 21);
            this.cboCriterio.TabIndex = 8;
            // 
            // cboCampo
            // 
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(85, 334);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(121, 21);
            this.cboCampo.TabIndex = 7;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 498);
            this.Controls.Add(this.grbArticulos);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Artículos";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.grbArticulos.ResumeLayout(false);
            this.grbArticulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.GroupBox grbArticulos;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.Label lblFiltroAvanzado;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblcampo;
        private System.Windows.Forms.PictureBox pctArticulo;
    }
}

