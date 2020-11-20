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
    public partial class FrmPlacaDeVideo : Form
    {

        private PlacaDeVideo gpu;
        /// <summary>
        /// propiedad de lectura que devuelve la cantidad de ventiladores que tiene el PlacaDeVideo del form, usando la propiedad de la clase PlacaDeVideo.
        /// </summary>
        public int GpuDelForm
        {
            get { return gpu.Longitud; }
        }

        public FrmPlacaDeVideo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// instancia una nuevo PlacaDeVideo, usando la data de la tabla, pero agregandole la longitud que el usuario quiera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {

                gpu = new PlacaDeVideo("", "", "", 0, 0, int.Parse(this.comboBox1.Text));
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                throw new ComboVacioException();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
