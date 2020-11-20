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
    public partial class FrmAdd : Form
    {

        private Producto producto;

        /// <summary>
        /// propiedad que devuelve el producto que se crea en el form para agregarlo.
        /// </summary>
        public Producto ProductoDelForm
        {
            get { return producto; }
        }

        public FrmAdd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor parametrizado, carga el texbox con lo que le llegue del producto.
        /// </summary>
        /// <param name="p"></param>
        public FrmAdd(Producto p) : this()
        {
            this.producto = p;
            this.txtProducto.Text = this.producto.Product;
            this.txtMarca.Text = this.producto.Marca;
            this.txtModelo.Text = this.producto.Modelo;
            this.txtPrecio.Text = this.producto.Precio.ToString();
            this.txtCantidad.Text = this.producto.CantidadDeStock.ToString();
        }
        /// <summary>
        /// instancia el objeto producto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Aceptar_Click(object sender, EventArgs e)
        {
            this.producto = new Producto(this.txtProducto.Text, this.txtMarca.Text, this.txtModelo.Text, int.Parse(this.txtPrecio.Text), int.Parse(this.txtCantidad.Text));

            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// cierra el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
