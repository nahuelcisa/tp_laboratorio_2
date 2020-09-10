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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double num = Operar(this.textBox1.Text, this.textBox2.Text, this.cmbOperador.Text);
            if(num == double.MinValue)
            {
                this.lblResultado.Text = "Error.";
            }
            else
            {
                this.lblResultado.Text = Convert.ToString(num);
            }
        }

        private void Limpiar()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }


        private static double Operar(string numero1, string numero2, string operador)
        {

            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);
            return Calculadora.Operar(numeroUno, numeroDos, operador);
        }


    }
}
