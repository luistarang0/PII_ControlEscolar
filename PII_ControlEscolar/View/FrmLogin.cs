using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlEscolarCore.Business;
using PII_ControlEscolar.Utilities;
using ControlEscolarCore.Utilities;
using NLog;

namespace PII_ControlEscolar.View
{
    public partial class FrmLogin : Form
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.View.FrmLogin");
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            _logger.Info("Usuario accediendo a iniciar sesion");
            _logger.Warn("Espacio en disco bajo");
            try
            {
                //Aqui provocamos una primera excepcion
                try
                {
                    int divisor = 0;
                    int resultado = 10 / divisor; //Esto provocará una excepción DivideByZeroException
                }
                catch (DivideByZeroException ex)
                {
                    //Capturamos la excepción y la envolvemos en una nueva
                    throw new ApplicationException("Error al realizar el calculo en la aplicacion", ex);
                }
            }
            catch (Exception ex)
            {
                //Aqui puedes manejar la excepcion que contiene el inner exception
                _logger.Error(ex, "Se produjo un error en la operacion");
                //O registrar especificamente la excepcion interna
                if (ex.InnerException!=null)
                {
                    _logger.Fatal(ex, $"Error crítico con detalle interno: {ex.InnerException.Message}");
                }

                //Aplicar en Utilities el metodo muestra error para ahorra codigo
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            //{
            //    MessageBox.Show("El campo de usuario no puede estar vacio.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            //if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            //{
            //    MessageBox.Show("El campo de contraseña no puede estar vacio.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (!UsuarioNegocio.EsCorreoValido(txtUsuario.Text))
            //{
            //    MessageBox.Show("El nombre de usuario no tiene un formato correcto", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //MessageBox.Show("Listo para iniciar sesión", "EXITO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Hide();
            //MDIControlEscolar mdi = new MDIControlEscolar();
            //mdi.Show();

            this.DialogResult = DialogResult.OK;
            this.Close();

            #region ocultar
            //Cualquier cosa
            #endregion
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
