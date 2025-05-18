namespace PII_ControlEscolar.View
{
    partial class FrmEstudiantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblCtrlEst = new Label();
            scnEstudiantes = new SplitContainer();
            gBxAlta = new GroupBox();
            btnGuardar = new Button();
            lblAnotacion = new Label();
            lblFechaBaja = new Label();
            dtpFechaBaja = new DateTimePicker();
            cmbEstatus = new ComboBox();
            lblEst = new Label();
            lblFechaAlta = new Label();
            dtpFechaAlta = new DateTimePicker();
            pbxI = new PictureBox();
            txtNoControl = new TextBox();
            lblNoControl = new Label();
            nudSemestre = new NumericUpDown();
            lblSemestre = new Label();
            lblFechaNac = new Label();
            dtpFechaNac = new DateTimePicker();
            txtCURP = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtNombre = new TextBox();
            lblCurp = new Label();
            lblTel = new Label();
            lblCorreo = new Label();
            lblNom = new Label();
            gbxFiltros = new GroupBox();
            chckActivos = new CheckBox();
            btnActualizar = new Button();
            txtBusqueda = new TextBox();
            lblBusqueda = new Label();
            dtpFechaFin = new DateTimePicker();
            lblFechaFin = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaInicio = new Label();
            comboTipoFecha = new ComboBox();
            lblTipoFecha = new Label();
            lblTotalRegistros = new Label();
            dgvEstudiantes = new DataGridView();
            cmsEstudiantes = new ContextMenuStrip(components);
            editarEstudianteToolStripMenuItem = new ToolStripMenuItem();
            gbxHerramientas = new GroupBox();
            btnExc = new Button();
            lblRuta = new Label();
            btnCarga = new Button();
            btnCaptura = new Button();
            toolTipInfo = new ToolTip(components);
            ofdArchivo = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)scnEstudiantes).BeginInit();
            scnEstudiantes.Panel1.SuspendLayout();
            scnEstudiantes.Panel2.SuspendLayout();
            scnEstudiantes.SuspendLayout();
            gBxAlta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSemestre).BeginInit();
            gbxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
            cmsEstudiantes.SuspendLayout();
            gbxHerramientas.SuspendLayout();
            SuspendLayout();
            // 
            // lblCtrlEst
            // 
            lblCtrlEst.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCtrlEst.BackColor = Color.FromArgb(0, 192, 192);
            lblCtrlEst.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCtrlEst.ForeColor = SystemColors.ButtonFace;
            lblCtrlEst.Location = new Point(12, 4);
            lblCtrlEst.Name = "lblCtrlEst";
            lblCtrlEst.Size = new Size(988, 42);
            lblCtrlEst.TabIndex = 0;
            lblCtrlEst.Text = "Control de Estudiantes";
            lblCtrlEst.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scnEstudiantes
            // 
            scnEstudiantes.Location = new Point(12, 54);
            scnEstudiantes.Name = "scnEstudiantes";
            // 
            // scnEstudiantes.Panel1
            // 
            scnEstudiantes.Panel1.Controls.Add(gBxAlta);
            // 
            // scnEstudiantes.Panel2
            // 
            scnEstudiantes.Panel2.Controls.Add(gbxFiltros);
            scnEstudiantes.Panel2.Controls.Add(dgvEstudiantes);
            scnEstudiantes.Panel2.Controls.Add(gbxHerramientas);
            scnEstudiantes.Size = new Size(991, 496);
            scnEstudiantes.SplitterDistance = 330;
            scnEstudiantes.TabIndex = 1;
            // 
            // gBxAlta
            // 
            gBxAlta.Controls.Add(btnGuardar);
            gBxAlta.Controls.Add(lblAnotacion);
            gBxAlta.Controls.Add(lblFechaBaja);
            gBxAlta.Controls.Add(dtpFechaBaja);
            gBxAlta.Controls.Add(cmbEstatus);
            gBxAlta.Controls.Add(lblEst);
            gBxAlta.Controls.Add(lblFechaAlta);
            gBxAlta.Controls.Add(dtpFechaAlta);
            gBxAlta.Controls.Add(pbxI);
            gBxAlta.Controls.Add(txtNoControl);
            gBxAlta.Controls.Add(lblNoControl);
            gBxAlta.Controls.Add(nudSemestre);
            gBxAlta.Controls.Add(lblSemestre);
            gBxAlta.Controls.Add(lblFechaNac);
            gBxAlta.Controls.Add(dtpFechaNac);
            gBxAlta.Controls.Add(txtCURP);
            gBxAlta.Controls.Add(txtTelefono);
            gBxAlta.Controls.Add(txtCorreo);
            gBxAlta.Controls.Add(txtNombre);
            gBxAlta.Controls.Add(lblCurp);
            gBxAlta.Controls.Add(lblTel);
            gBxAlta.Controls.Add(lblCorreo);
            gBxAlta.Controls.Add(lblNom);
            gBxAlta.Location = new Point(0, 3);
            gBxAlta.Name = "gBxAlta";
            gBxAlta.Size = new Size(328, 490);
            gBxAlta.TabIndex = 0;
            gBxAlta.TabStop = false;
            gBxAlta.Text = "Alta o Edición";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(247, 461);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // lblAnotacion
            // 
            lblAnotacion.AutoSize = true;
            lblAnotacion.Location = new Point(6, 464);
            lblAnotacion.Name = "lblAnotacion";
            lblAnotacion.Size = new Size(113, 15);
            lblAnotacion.TabIndex = 21;
            lblAnotacion.Text = "* Datos Obligatorios";
            // 
            // lblFechaBaja
            // 
            lblFechaBaja.AutoSize = true;
            lblFechaBaja.Location = new Point(6, 380);
            lblFechaBaja.Name = "lblFechaBaja";
            lblFechaBaja.Size = new Size(63, 15);
            lblFechaBaja.TabIndex = 20;
            lblFechaBaja.Text = "Fecha Baja";
            // 
            // dtpFechaBaja
            // 
            dtpFechaBaja.Format = DateTimePickerFormat.Short;
            dtpFechaBaja.Location = new Point(6, 411);
            dtpFechaBaja.Name = "dtpFechaBaja";
            dtpFechaBaja.Size = new Size(316, 23);
            dtpFechaBaja.TabIndex = 19;
            // 
            // cmbEstatus
            // 
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Location = new Point(6, 354);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(316, 23);
            cmbEstatus.TabIndex = 18;
            // 
            // lblEst
            // 
            lblEst.AutoSize = true;
            lblEst.Location = new Point(6, 336);
            lblEst.Name = "lblEst";
            lblEst.Size = new Size(52, 15);
            lblEst.TabIndex = 17;
            lblEst.Text = "Estatus *";
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(6, 292);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(70, 15);
            lblFechaAlta.TabIndex = 16;
            lblFechaAlta.Text = "Fecha Alta *";
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Format = DateTimePickerFormat.Short;
            dtpFechaAlta.Location = new Point(6, 310);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(316, 23);
            dtpFechaAlta.TabIndex = 15;
            // 
            // pbxI
            // 
            pbxI.Image = PII_ControlEscolar.Properties.Resources._8725592_chat_info_icon__1_;
            pbxI.Location = new Point(306, 257);
            pbxI.Name = "pbxI";
            pbxI.Size = new Size(16, 16);
            pbxI.SizeMode = PictureBoxSizeMode.AutoSize;
            pbxI.TabIndex = 14;
            pbxI.TabStop = false;
            toolTipInfo.SetToolTip(pbxI, "T/M-Año de ingreso-Número de alumno\r\n ");
            pbxI.Click += pictureBox1_Click;
            // 
            // txtNoControl
            // 
            txtNoControl.Location = new Point(6, 257);
            txtNoControl.MaxLength = 20;
            txtNoControl.Name = "txtNoControl";
            txtNoControl.Size = new Size(294, 23);
            txtNoControl.TabIndex = 13;
            // 
            // lblNoControl
            // 
            lblNoControl.AutoSize = true;
            lblNoControl.Location = new Point(6, 239);
            lblNoControl.Name = "lblNoControl";
            lblNoControl.Size = new Size(118, 15);
            lblNoControl.TabIndex = 12;
            lblNoControl.Text = "Numero de Control *";
            // 
            // nudSemestre
            // 
            nudSemestre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudSemestre.Location = new Point(231, 213);
            nudSemestre.Maximum = new decimal(new int[] { 13, 0, 0, 0 });
            nudSemestre.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSemestre.Name = "nudSemestre";
            nudSemestre.Size = new Size(91, 23);
            nudSemestre.TabIndex = 11;
            nudSemestre.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSemestre
            // 
            lblSemestre.AutoSize = true;
            lblSemestre.Location = new Point(163, 195);
            lblSemestre.Name = "lblSemestre";
            lblSemestre.Size = new Size(63, 15);
            lblSemestre.TabIndex = 10;
            lblSemestre.Text = "Semestre *";
            lblSemestre.Click += lblSemestre_Click;
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Location = new Point(6, 195);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(127, 15);
            lblFechaNac.TabIndex = 9;
            lblFechaNac.Text = "Fecha de Nacimiento *";
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Format = DateTimePickerFormat.Short;
            dtpFechaNac.Location = new Point(6, 213);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(86, 23);
            dtpFechaNac.TabIndex = 8;
            // 
            // txtCURP
            // 
            txtCURP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCURP.Location = new Point(6, 169);
            txtCURP.MaxLength = 18;
            txtCURP.Name = "txtCURP";
            txtCURP.Size = new Size(316, 23);
            txtCURP.TabIndex = 7;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTelefono.Location = new Point(6, 125);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(316, 23);
            txtTelefono.TabIndex = 6;
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCorreo.Location = new Point(6, 81);
            txtCorreo.MaxLength = 100;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(316, 23);
            txtCorreo.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.Location = new Point(6, 37);
            txtNombre.MaxLength = 255;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(316, 23);
            txtNombre.TabIndex = 4;
            // 
            // lblCurp
            // 
            lblCurp.AutoSize = true;
            lblCurp.Location = new Point(6, 151);
            lblCurp.Name = "lblCurp";
            lblCurp.Size = new Size(45, 15);
            lblCurp.TabIndex = 3;
            lblCurp.Text = "CURP *";
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Location = new Point(6, 107);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(61, 15);
            lblTel.TabIndex = 2;
            lblTel.Text = "Teléfono *";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(6, 63);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(51, 15);
            lblCorreo.TabIndex = 1;
            lblCorreo.Text = "Correo *";
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(6, 19);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(59, 15);
            lblNom.TabIndex = 0;
            lblNom.Text = "Nombre *";
            // 
            // gbxFiltros
            // 
            gbxFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxFiltros.Controls.Add(chckActivos);
            gbxFiltros.Controls.Add(btnActualizar);
            gbxFiltros.Controls.Add(txtBusqueda);
            gbxFiltros.Controls.Add(lblBusqueda);
            gbxFiltros.Controls.Add(dtpFechaFin);
            gbxFiltros.Controls.Add(lblFechaFin);
            gbxFiltros.Controls.Add(dtpFechaInicio);
            gbxFiltros.Controls.Add(lblFechaInicio);
            gbxFiltros.Controls.Add(comboTipoFecha);
            gbxFiltros.Controls.Add(lblTipoFecha);
            gbxFiltros.Controls.Add(lblTotalRegistros);
            gbxFiltros.Location = new Point(3, 58);
            gbxFiltros.Name = "gbxFiltros";
            gbxFiltros.Size = new Size(651, 85);
            gbxFiltros.TabIndex = 3;
            gbxFiltros.TabStop = false;
            gbxFiltros.Text = "Filtros";
            // 
            // chckActivos
            // 
            chckActivos.AutoSize = true;
            chckActivos.Location = new Point(403, 53);
            chckActivos.Name = "chckActivos";
            chckActivos.Size = new Size(91, 19);
            chckActivos.TabIndex = 11;
            chckActivos.Text = "Solo Activos";
            chckActivos.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(503, 49);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(93, 23);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(219, 49);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(167, 23);
            txtBusqueda.TabIndex = 9;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.Location = new Point(93, 52);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(111, 15);
            lblBusqueda.TabIndex = 8;
            lblBusqueda.Text = "Busqueda por Texto";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(517, 13);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(79, 23);
            dtpFechaFin.TabIndex = 7;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(454, 19);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(57, 15);
            lblFechaFin.TabIndex = 6;
            lblFechaFin.Text = "Fecha Fin";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(345, 13);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(83, 23);
            dtpFechaInicio.TabIndex = 5;
            dtpFechaInicio.Value = new DateTime(1900, 1, 1, 21, 24, 0, 0);
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(258, 19);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(70, 15);
            lblFechaInicio.TabIndex = 4;
            lblFechaInicio.Text = "Fecha Inicio";
            // 
            // comboTipoFecha
            // 
            comboTipoFecha.FormattingEnabled = true;
            comboTipoFecha.Location = new Point(117, 16);
            comboTipoFecha.Name = "comboTipoFecha";
            comboTipoFecha.Size = new Size(121, 23);
            comboTipoFecha.TabIndex = 3;
            // 
            // lblTipoFecha
            // 
            lblTipoFecha.AutoSize = true;
            lblTipoFecha.Location = new Point(6, 19);
            lblTipoFecha.Name = "lblTipoFecha";
            lblTipoFecha.Size = new Size(81, 15);
            lblTipoFecha.TabIndex = 2;
            lblTipoFecha.Text = "Tipo de Fecha";
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Location = new Point(6, 52);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(55, 15);
            lblTotalRegistros.TabIndex = 1;
            lblTotalRegistros.Text = "Registros";
            // 
            // dgvEstudiantes
            // 
            dgvEstudiantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstudiantes.ContextMenuStrip = cmsEstudiantes;
            dgvEstudiantes.Location = new Point(0, 149);
            dgvEstudiantes.Name = "dgvEstudiantes";
            dgvEstudiantes.Size = new Size(651, 344);
            dgvEstudiantes.TabIndex = 0;
            // 
            // cmsEstudiantes
            // 
            cmsEstudiantes.Items.AddRange(new ToolStripItem[] { editarEstudianteToolStripMenuItem });
            cmsEstudiantes.Name = "cmsEstudiantes";
            cmsEstudiantes.Size = new Size(163, 26);
            cmsEstudiantes.Text = "Estudiantes";
            // 
            // editarEstudianteToolStripMenuItem
            // 
            editarEstudianteToolStripMenuItem.Name = "editarEstudianteToolStripMenuItem";
            editarEstudianteToolStripMenuItem.Size = new Size(162, 22);
            editarEstudianteToolStripMenuItem.Text = "Editar Estudiante";
            editarEstudianteToolStripMenuItem.Click += editarEstudianteToolStripMenuItem_Click;
            // 
            // gbxHerramientas
            // 
            gbxHerramientas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxHerramientas.Controls.Add(btnExc);
            gbxHerramientas.Controls.Add(lblRuta);
            gbxHerramientas.Controls.Add(btnCarga);
            gbxHerramientas.Controls.Add(btnCaptura);
            gbxHerramientas.Location = new Point(3, 3);
            gbxHerramientas.Name = "gbxHerramientas";
            gbxHerramientas.Size = new Size(651, 49);
            gbxHerramientas.TabIndex = 2;
            gbxHerramientas.TabStop = false;
            gbxHerramientas.Text = "Herramientas";
            // 
            // btnExc
            // 
            btnExc.Location = new Point(454, 20);
            btnExc.Name = "btnExc";
            btnExc.Size = new Size(111, 23);
            btnExc.TabIndex = 3;
            btnExc.Text = "Exportar Excel";
            btnExc.UseVisualStyleBackColor = true;
            btnExc.Click += btnExc_Click;
            // 
            // lblRuta
            // 
            lblRuta.AutoSize = true;
            lblRuta.Location = new Point(274, 23);
            lblRuta.Name = "lblRuta";
            lblRuta.Size = new Size(154, 15);
            lblRuta.TabIndex = 2;
            lblRuta.Text = "Ruta de Archivos a Importar";
            // 
            // btnCarga
            // 
            btnCarga.Location = new Point(141, 19);
            btnCarga.Name = "btnCarga";
            btnCarga.Size = new Size(97, 23);
            btnCarga.TabIndex = 1;
            btnCarga.Text = "Carga Masiva";
            btnCarga.UseVisualStyleBackColor = true;
            btnCarga.Click += btnCarga_Click;
            // 
            // btnCaptura
            // 
            btnCaptura.Location = new Point(6, 19);
            btnCaptura.Name = "btnCaptura";
            btnCaptura.Size = new Size(105, 23);
            btnCaptura.TabIndex = 0;
            btnCaptura.Text = "Mostrar Captura";
            btnCaptura.UseVisualStyleBackColor = true;
            btnCaptura.Click += btnCaptura_Click_1;
            // 
            // ofdArchivo
            // 
            ofdArchivo.FileName = "openFileDialog1";
            // 
            // FrmEstudiantes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 549);
            Controls.Add(scnEstudiantes);
            Controls.Add(lblCtrlEst);
            Name = "FrmEstudiantes";
            Text = "FrmEstudiantes";
            Load += FrmEstudiantes_Load_1;
            scnEstudiantes.Panel1.ResumeLayout(false);
            scnEstudiantes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scnEstudiantes).EndInit();
            scnEstudiantes.ResumeLayout(false);
            gBxAlta.ResumeLayout(false);
            gBxAlta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxI).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSemestre).EndInit();
            gbxFiltros.ResumeLayout(false);
            gbxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
            cmsEstudiantes.ResumeLayout(false);
            gbxHerramientas.ResumeLayout(false);
            gbxHerramientas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblCtrlEst;
        private SplitContainer scnEstudiantes;
        private TextBox txtCURP;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtNombre;
        private Label lblCurp;
        private Label lblTel;
        private Label lblCorreo;
        private Label lblNom;
        private Label lblSemestre;
        private Label lblFechaNac;
        private DateTimePicker dtpFechaNac;
        private NumericUpDown nudSemestre;
        private TextBox txtNoControl;
        private Label lblNoControl;
        private PictureBox pbxI;
        private ToolTip toolTipInfo;
        private Label lblFechaAlta;
        private DateTimePicker dtpFechaAlta;
        private Label lblFechaBaja;
        private DateTimePicker dtpFechaBaja;
        private ComboBox cmbEstatus;
        private Label lblEst;
        private Label lblAnotacion;
        public GroupBox gBxAlta;
        private Label lblTotalRegistros;
        private DataGridView dgvEstudiantes;
        private GroupBox gbxHerramientas;
        private GroupBox gbxFiltros;
        private Label lblRuta;
        private Button btnCarga;
        private Button btnCaptura;
        private ComboBox comboTipoFecha;
        private Label lblTipoFecha;
        private Button btnActualizar;
        private TextBox txtBusqueda;
        private Label lblBusqueda;
        private DateTimePicker dtpFechaFin;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaInicio;
        private OpenFileDialog ofdArchivo;
        private Button btnGuardar;
        private ContextMenuStrip cmsEstudiantes;
        private ToolStripMenuItem editarEstudianteToolStripMenuItem;
        private CheckBox chckActivos;
        private Button btnExc;
    }
}