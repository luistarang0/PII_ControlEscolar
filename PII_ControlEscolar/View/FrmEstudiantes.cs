using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlEscolarCore.Controller;
using ControlEscolarCore.Model;
using PII_ControlEscolar.Utilities;
using ControlEscolarCore.Business;

namespace PII_ControlEscolar.View
{
    public partial class FrmEstudiantes : Form
    {
        public FrmEstudiantes(Form parent)
        {
            InitializeComponent();
            Formas.InicializaForma(this, parent);
            gBxAlta.Visible = true; // Asegúrate de que el GroupBox sea visible
            InicializaVentanasEstudiantes();
            CargarEstudiantes();
        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {
            InicializaVentanasEstudiantes();
        }

        public void InicializaVentanasEstudiantes()
        {

            PoblaComboTipoFecha();
            PoblaComboEstatus();
            //Oculta la barra vertical de campos
            scnEstudiantes.Panel1Collapsed = true;
            dtpFechaAlta.Value = DateTime.Now;
        }

        #region codigo vicioso
        //private void InicializaForma(Form parent)
        //{
        //    //Inicializamos la forma

        //    //Propiedades basicas
        //    this.MdiParent = parent; //Asignar el padre al MDI
        //    this.FormBorderStyle = FormBorderStyle.Sizable; //Permite redimensionar
        //    this.MaximizeBox = true; //Permite Maximizar
        //    this.MinimizeBox = true; //Permite Minimizar
        //    this.WindowState = FormWindowState.Normal; //Estado inicial de la ventana

        //    //Propiedades de control
        //    this.ControlBox = true; //Mostrar botones de control (Minimizar, maximizar)
        //    this.ShowIcon = true; // Mostrar icono en la barra de titulo
        //    this.ShowInTaskbar = false; //No mostrar en la barra de tareas

        //    //Propiedades de tamaño 
        //    this.AutoScaleMode = AutoScaleMode.Font; // Modo de escalado 
        //    this.ClientSize = new Size(860, 600); // Tamaño inicial 
        //    this.MinimumSize = new Size(400, 300); // Tamaño minimo permitido 
        //    this.MaximumSize = new Size(3440, 1440); // Tamaño máximo permitido 

        //    //Propiedades de inicio 
        //    this.StartPosition = FormStartPosition.CenterScreen; // Posición inicial 

        //    //Propiedades de comportamiento 
        //    this.AutoScroll = true; // Permitir scroll si el contenido es mayor que la ventana 
        //    this.KeyPreview = true; // Permitir que el formulario reciba eventos de teclado

        //}

        #endregion

        private void PoblaComboEstatus()
        {
            //Crear un diccionario de valores
            Dictionary<int, string> list_estatus = new Dictionary<int, string>
    {
        { 1, "Activo" },
        { 0, "Baja" },
        { 2, "Baja Temporal" }
    };
            //Asignar el diccionario al combo
            cmbEstatus.DataSource = new BindingSource(list_estatus, null);
            cmbEstatus.DisplayMember = "Value";
            cmbEstatus.ValueMember = "Key";

            cmbEstatus.SelectedValue = 1;
        }

        private void PoblaComboTipoFecha()
        {
            //Crear un diccionario de valores
            Dictionary<int, string> list_tipofechas = new Dictionary<int, string>
    {
        { 1, "Nacimiento" },
        { 2, "Alta" },
        { 3, "Baja" }
    };
            //Asignar el diccionario al combo
            comboTipoFecha.DataSource = new BindingSource(list_tipofechas, null);
            comboTipoFecha.DisplayMember = "Value";
            comboTipoFecha.ValueMember = "Key";

            cmbEstatus.SelectedValue = 2;
        }


        private void btnCarga_Click(object sender, EventArgs e)
        {
            ofdArchivo.Title = "Selecciona el archivo de Excel";
            ofdArchivo.Filter = "Archivos de Excel (.xls;.xlsx)|.xls;.xlsx"; //Filtro de archivos
            ofdArchivo.FilterIndex = 1; //El primer filtro es el que se muestra por default
            ofdArchivo.RestoreDirectory = true; //Recuerda la ultima carpeta abierta

            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdArchivo.FileName;
                string extension = Path.GetExtension(filePath).ToLower();

                if (extension == ".xls" || extension == ".xlsx")
                {
                    //Cargar el archivo
                    MessageBox.Show("El archivo valido " + filePath, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El archivo seleccionado no es un archivo de Excel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void lblSemestre_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CargarEstudiantes()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                // Crear una instancia de EstudiantesController
                EstudiantesController estudiantesController = new EstudiantesController();

                // Obtener la lista de estudiantes
                List<Estudiante> estudiantes = estudiantesController.ObtenerEstudiantes(
                    soloActivos: true,
                    tipoFecha: comboTipoFecha.SelectedValue != null ? (int)comboTipoFecha.SelectedValue : 0,
                    fechaInicio: dtpFechaInicio.Enabled ? dtpFechaInicio.Value : (DateTime?)null,
                    fechaFin: dtpFechaFin.Enabled ? dtpFechaFin.Value : (DateTime?)null
                 );

                //LIMPIAR EL DATAGRIDVIEW
                dgvEstudiantes.DataSource = null;

                if (estudiantes.Count == 0)
                {
                    lblTotalRegistros.Text = "Total: 0 registros";

                    if (!string.IsNullOrEmpty(txtBusqueda.Text))
                    {
                        MessageBox.Show("No se encontraron estudiantes con los criterios de búsqueda especificados", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Matrícula", typeof(string));
                dt.Columns.Add("Nombre Completo", typeof(string));
                dt.Columns.Add("Semestre", typeof(string));
                dt.Columns.Add("Correo", typeof(string));
                dt.Columns.Add("Teléfono", typeof(string));
                dt.Columns.Add("CURP", typeof(string));
                dt.Columns.Add("Fecha Nacimiento", typeof(DateTime));
                dt.Columns.Add("Fecha Alta", typeof(DateTime));
                dt.Columns.Add("Estatus", typeof(string));

                foreach (Estudiante estudiante in estudiantes)
                {
                    dt.Rows.Add(
                        estudiante.Id,
                        estudiante.Matricula,
                        estudiante.DatosPersonales.NombreCompleto,
                        estudiante.Semestre,
                        estudiante.DatosPersonales.Correo,
                        estudiante.DatosPersonales.Telefono,
                        estudiante.DatosPersonales.Curp,
                        estudiante.DatosPersonales.FechaNacimiento,
                        estudiante.FechaAlta,
                        estudiante.DescripcionEstatus
                    );
                }

                //Asignar el origen de datos al DataGridView
                dgvEstudiantes.DataSource = dt;

                //Configurar la aparencia del DataGridView
                ConfigurarDataGridView();

                //Actualizar el total de registros
                lblTotalRegistros.Text = $"Total: {estudiantes.Count} registros";
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cargar los estudiantes... Contacte al administrador", "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Regresar el cursor a su estado normal
                Cursor = Cursors.Default;
            }
        }


        private bool DatosVacios()
        {
            if (txtNombre.Text == ""
                || txtCorreo.Text == "" || txtCURP.Text == "" || txtTelefono.Text == "" || txtNoControl.Text == "")
            {
                return true;
            }
            return false;
        }

        private bool DatosValidos()
        {
            if (!EstudiantesNegocio.EsFormatoValido(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("Correo inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EstudiantesNegocio.EsCURPValido(txtCURP.Text.Trim()))
            {
                MessageBox.Show("CURP inválida.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EstudiantesNegocio.EsNoControlValido(txtNoControl.Text.Trim()))
            {
                MessageBox.Show("Número de control inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ConfigurarDataGridView()
        {
            //Ajustes generales
            dgvEstudiantes.AllowUserToAddRows = false;
            dgvEstudiantes.AllowUserToDeleteRows = false;
            dgvEstudiantes.ReadOnly = true;

            // Ajustar el ancho de las columnas
            dgvEstudiantes.Columns["Matrícula"].Width = 100;
            dgvEstudiantes.Columns["Nombre Completo"].Width = 200;
            dgvEstudiantes.Columns["Semestre"].Width = 80;
            dgvEstudiantes.Columns["Correo"].Width = 180;
            dgvEstudiantes.Columns["Teléfono"].Width = 120;
            dgvEstudiantes.Columns["CURP"].Width = 150;
            dgvEstudiantes.Columns["Fecha Nacimiento"].Width = 120;
            dgvEstudiantes.Columns["Fecha Alta"].Width = 120;
            dgvEstudiantes.Columns["Estatus"].Width = 100;

            // Ocultar columna ID si es necesario
            dgvEstudiantes.Columns["ID"].Visible = false;

            // Formato para las fechas
            dgvEstudiantes.Columns["Fecha Nacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvEstudiantes.Columns["Fecha Alta"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Alineación
            dgvEstudiantes.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEstudiantes.Columns["Matrícula"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstudiantes.Columns["Semestre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstudiantes.Columns["Estatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Color alternado de filas
            dgvEstudiantes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Selección de fila completa
            dgvEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Estilo de cabeceras
            dgvEstudiantes.EnableHeadersVisualStyles = false;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Font = new Font(dgvEstudiantes.Font, FontStyle.Bold);
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ordenar al hacer clic en el encabezado
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEstudiantes.ColumnHeadersHeight = 35;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarEstudiantes();
        }

        private void btnCaptura_Click_1(object sender, EventArgs e)
        {
            if (scnEstudiantes.Panel1Collapsed)
            {
                scnEstudiantes.Panel1Collapsed = false;
                btnCaptura.Text = "Ocultar captura";

            }
            else
            {
                scnEstudiantes.Panel1Collapsed = true;
                btnCaptura.Text = "Mostrar captura";
            }
        }

        private void GuardarEstudiante()
        {
            try
            {
                // Validaciones a nivel de interfaz
                if (DatosVacios())
                {
                    MessageBox.Show("Por favor, lleno todos los campos.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DatosValidos())
                {
                    return;
                }

                // Crear el objeto Persona con los datos del formulario
                Persona persona = new Persona(
                    txtNombre.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCURP.Text.Trim()
                );

                // Asignar la fecha de nacimiento
                persona.FechaNacimiento = dtpFechaNac.Value;

                // Crear el objeto Estudiante con los datos del formulario
                Estudiante estudiante = new Estudiante
                {
                    Matricula = txtNoControl.Text.Trim(),
                    Semestre = nudSemestre.Text.Trim(),
                    FechaAlta = dtpFechaAlta.Value,
                    Estatus = 1, // Activo por defecto
                    DatosPersonales = persona
                };

                // Crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                // Llamar al método para registrar el estudiante utilizando el modelo
                var (idEstudiante, mensaje) = estudiantesController.RegistrarEstudiante(estudiante);

                // Verificar el resultado
                if (idEstudiante > 0)
                {
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos(); // Método para limpiar el formulario después de guardar

                    // Actualizar la lista de estudiantes si está presente en la misma vista
                    CargarEstudiantes();
                }
                else
                {
                    // Mostrar mensaje de error devuelto por el controlador
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Enfocar el campo apropiado basado en el código de error
                    switch (idEstudiante)
                    {
                        case -2: // Error de CURP duplicado
                            txtCURP.Focus();
                            txtCURP.SelectAll();
                            break;
                        case -3: // Error de Matrícula duplicada
                            txtNoControl.Focus();
                            txtNoControl.SelectAll();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar el registro del estudiante. Por favor, intente nuevamente o contacte al administrador del sistema.",
    "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (btnGuardar.Text == "Actualizar")
            {
                ActualizarEstudiante();
            }
            else
            {
                GuardarEstudiante();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtCURP.Text = "";
            txtNoControl.Text = "";
            nudSemestre.Value = 1; // Restablecer el semestre a 1
            dtpFechaNac.Value = DateTime.Now; // Restablecer la fecha de nacimiento a la fecha actual
            dtpFechaAlta.Value = DateTime.Now; // Restablecer la fecha de alta a la fecha actual
            cmbEstatus.SelectedValue = 1; // Restablecer el estatus a Activo
            dtpFechaInicio.Value = DateTime.Now; // Restablecer la fecha de inicio a la fecha actual
            dtpFechaFin.Value = DateTime.Now; // Restablecer la fecha de fin a la fecha actual
        }

        /// <summary>
        /// Obtiene los detalles del estudiante seleccionado y los muestra en el formulario.
        /// </summary>
        /// <param name="idEstudiante">ID del estudiante a obtener</param>
        private void ObtenerDetalleEstudiante(int idEstudiante)
        {
            try
            {
                // Llamar al controlador para obtener el estudiante
                EstudiantesController controller_estudiante = new EstudiantesController();
                Estudiante? estudiante = controller_estudiante.ObtenerDetalleEstudiante(idEstudiante);

                if (estudiante != null)
                {
                    // Poblar los controles con la información del estudiante
                    CargarDatosEstudiante(estudiante);

                    // Cambiar a modo de edición
                    ModoEdicion(true);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del estudiante.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los detalles del estudiante: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los datos del estudiante en los controles del formulario
        /// </summary>
        /// <param name="estudiante">Objeto Estudiante con los datos a mostrar</param>
        private void CargarDatosEstudiante(Estudiante estudiante)
        {
            // Datos personales
            txtNombre.Text = estudiante.DatosPersonales.NombreCompleto;
            txtCorreo.Text = estudiante.DatosPersonales.Correo;
            txtTelefono.Text = estudiante.DatosPersonales.Telefono;
            txtCURP.Text = estudiante.DatosPersonales.Curp;

            if (estudiante.DatosPersonales.FechaNacimiento.HasValue)
                dtpFechaNac.Value = estudiante.DatosPersonales.FechaNacimiento.Value;
            else
                dtpFechaNac.Value = DateTime.Now;

            // Datos del estudiante
            txtNoControl.Text = estudiante.Matricula;

            // Buscar el semestre en el control
            // En lugar de buscar en una lista de items, simplemente asignamos el valor numérico
            if (int.TryParse(estudiante.Semestre, out int semestreNumerico))
            {
                // Asegúrate de que el valor esté dentro del rango del control
                if (semestreNumerico >= nudSemestre.Minimum && semestreNumerico <= nudSemestre.Maximum)
                {
                    nudSemestre.Value = semestreNumerico;
                }
            }

            // Fechas
            dtpFechaAlta.Value = estudiante.FechaAlta;

            if (estudiante.FechaBaja.HasValue)
            {
                dtpFechaBaja.Value = estudiante.FechaBaja.Value;
                dtpFechaBaja.Enabled = true;
            }
            else
            {
                dtpFechaBaja.Value = DateTime.Now;
                dtpFechaBaja.Enabled = false;
            }

            // Estatus
            cmbEstatus.SelectedValue = estudiante.Estatus;

            // Guardar el ID en una propiedad o tag para usarlo al actualizar
            this.Tag = estudiante.Id;
        }

        /// <summary>
        /// Cambia el modo de operación entre nuevo registro y edición
        /// </summary>
        /// <param name="edicion">True para modo edición, False para modo nuevo registro</param>
        private void ModoEdicion(bool edicion)
        {
            // Cambiar título y configurar botones según el modo
            gBxAlta.Text = edicion ? "Editar Estudiante" : "Nuevo Estudiante";
            btnGuardar.Text = edicion ? "Actualizar" : "Guardar";

            // Si es modo edición, desactivar campos que no deberían modificarse
            txtNoControl.ReadOnly = edicion;

            // Activar el panel izquierdo para mostrar los detalles
            if (scnEstudiantes.Panel1Collapsed)
            {
                scnEstudiantes.Panel1Collapsed = false;
                btnCaptura.Text = "Ocultar captura rápida";
            }
        }

        private void FrmEstudiantes_Load_1(object sender, EventArgs e)
        {

        }

        private void editarEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada en el grid
                if (dgvEstudiantes.SelectedRows.Count > 0)
                {
                    // Obtener el ID del estudiante de la fila seleccionada
                    int idEstudiante = Convert.ToInt32(dgvEstudiantes.SelectedRows[0].Cells["id"].Value);

                    // Llamar a la función para obtener y mostrar los detalles
                    ObtenerDetalleEstudiante(idEstudiante);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un estudiante para editar.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al preparar la edición del estudiante: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza los datos de un estudiante existente
        /// </summary>
        private void ActualizarEstudiante()
        {
            try
            {
                // Validaciones a nivel de interfaz
                if (DatosVacios())
                {
                    MessageBox.Show("Por favor, llene todos los campos.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DatosValidos())
                {
                    return;
                }

                // Obtener el ID del estudiante almacenado en el Tag
                if (this.Tag == null || !(this.Tag is int))
                {
                    MessageBox.Show("No se ha seleccionado un estudiante para actualizar.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEstudiante = (int)this.Tag;

                // Crear el objeto Persona con los datos del formulario
                Persona persona = new Persona
                {
                    Id = 0, // Se actualizará con el valor correcto en el controller
                    NombreCompleto = txtNombre.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Curp = txtCURP.Text.Trim(),
                    FechaNacimiento = dtpFechaNac.Value,
                    Estatus = true // Asumimos que la persona está activa
                };

                // Crear el objeto Estudiante con los datos del formulario
                Estudiante estudiante = new Estudiante
                {
                    Id = idEstudiante,
                    IdPersona = 0, // Se actualizará con el valor correcto en el controller
                    Matricula = txtNoControl.Text.Trim(),
                    Semestre = nudSemestre.Text.Trim(),
                    FechaAlta = dtpFechaAlta.Value,
                    Estatus = cmbEstatus.SelectedValue != null ? (int)cmbEstatus.SelectedValue : 1, // 0=Baja, 1=Activo, 2=Baja Temporal
                    DatosPersonales = persona
                };

                // Asignar fecha de baja si corresponde
                if (estudiante.Estatus == 0) // Si el estatus es "Baja"
                {
                    estudiante.FechaBaja = dtpFechaBaja.Value;
                }
                else if (dtpFechaBaja.Enabled && cmbEstatus.SelectedIndex == 2) // Si es "Baja Temporal" y hay fecha
                {
                    estudiante.FechaBaja = dtpFechaBaja.Value;
                }
                else
                {
                    estudiante.FechaBaja = null;
                }

                // Crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                // Llamar al método para actualizar el estudiante utilizando el modelo
                var (resultado, mensaje) = estudiantesController.ActualizarEstudiante(estudiante);

                // Verificar el resultado
                if (resultado)
                {
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar formulario y restablecer modo
                    LimpiarCampos();
                    ModoEdicion(false);

                    // Actualizar la lista de estudiantes
                    CargarEstudiantes();
                }
                else
                {
                    // Mostrar mensaje de error devuelto por el controlador
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // El detalle del error ya se guardará en el log por el controlador
                MessageBox.Show("No se pudo completar la actualización del estudiante. Por favor, intente nuevamente o contacte al administrador del sistema.",
                    "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportarExcel()
        {
            try
            {
                // Crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                // Obtener los filtros actuales de la interfaz
                bool soloActivos = chckActivos.Checked;
                int tipoFecha = comboTipoFecha.SelectedValue != null ? (int)comboTipoFecha.SelectedValue : 0;
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                // Mostrar diálogo para guardar archivo
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar archivo de Excel";
                    saveFileDialog.FileName = $"Estudiantes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Mostrar cursor de espera
                        Cursor.Current = Cursors.WaitCursor;

                        // Exportar usando el método del controlador
                        bool resultado = estudiantesController.ExportarEstudiantesExcel(
                            saveFileDialog.FileName,
                            soloActivos,
                            tipoFecha,
                            fechaInicio,
                            fechaFin
                        );

                        // Restaurar cursor normal
                        Cursor.Current = Cursors.Default;

                        if (resultado)
                        {
                            MessageBox.Show("Archivo Excel exportado correctamente", "Exito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Preguntar si desea abrir el archivo
                            DialogResult abrirArchivo = MessageBox.Show(
                                "¿Desea abrir el archivo Excel generado?",
                                "Abrir archivo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (abrirArchivo == DialogResult.Yes)
                            {
                                // Usar ProcessStartInfo para abrir el archivo con la aplicación asociada
                                var startInfo = new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = saveFileDialog.FileName,
                                    UseShellExecute = true
                                };
                                System.Diagnostics.Process.Start(startInfo);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron estudiantes para exportar", "Información",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExc_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }
    }



}
