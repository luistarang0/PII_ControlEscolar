using PII_ControlEscolar.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PII_ControlEscolar.View
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios(Form parent)
        {
            InitializeComponent();
            Formas.InicializaForma(this, parent);
        }
    }
}
