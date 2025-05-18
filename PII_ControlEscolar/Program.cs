using PII_ControlEscolar.View;
using NLog;
using PII_ControlEscolar.Utilities;
using ControlEscolarCore.Utilities;
using OfficeOpenXml;

namespace ControlEscolar
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        private static Logger? _logger;
        [STAThread]
        static void Main()
        {

            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            // Inicializar NLog
            _logger = LoggingManager.GetLogger("ControlEscolar.Program");
            _logger.Info("Iniciando aplicación");


            FrmLogin login_form = new FrmLogin();
            if (login_form.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MDIControlEscolar());
            }
            //Application.Run(new View.FrmLogin());
        }
    }
}   