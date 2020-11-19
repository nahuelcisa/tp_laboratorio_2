using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmPrincipal
{
    public partial class FrmPrincipal : Form
    {
   
        public FrmPrincipal()
        {
            InitializeComponent();            
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro de querer salir?", "Salir",
         MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnVendedor_Click(object sender, EventArgs e)
        {
                       
            FrmVendedor frm = new FrmVendedor();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

        }

        private void btnComprador_Click(object sender, EventArgs e)
        {
            FrmComprador frm = new FrmComprador();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
