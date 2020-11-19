using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmPrincipal
{
    public partial class FrmGabinete : Form
    {

        private Gabinete gabinete;

        public int GabineteDelForm
        {
            get { return gabinete.CantidadDeVentiladores; }
        }

        public FrmGabinete()
        {
            InitializeComponent();
        }

        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != "")
            {
                gabinete = new Gabinete("", "", "", 0, 0, int.Parse(this.comboBox1.Text));
            }
            else
            {
                throw new ComboVacioException();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
