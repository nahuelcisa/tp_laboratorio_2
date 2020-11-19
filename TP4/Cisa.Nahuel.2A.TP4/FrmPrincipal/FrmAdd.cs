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


        public Producto ProductoDelForm
        {
            get { return producto; }
        }

        public FrmAdd()
        {
            InitializeComponent();
        }

        public FrmAdd(Producto p) : this()
        {
            this.producto = p;
            this.txtProducto.Text = this.producto.Product;
            this.txtMarca.Text = this.producto.Marca;
            this.txtModelo.Text = this.producto.Modelo;
            this.txtPrecio.Text = this.producto.Precio.ToString();
            this.txtCantidad.Text = this.producto.CantidadDeStock.ToString();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            this.producto = new Producto(this.txtProducto.Text, this.txtMarca.Text, this.txtModelo.Text, int.Parse(this.txtPrecio.Text), int.Parse(this.txtCantidad.Text));

            this.DialogResult = DialogResult.OK;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
