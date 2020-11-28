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

        /// <summary>
        /// Limpia la consola mediante el metodo limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Pregunta antes de cerrar el form si estas seguro que desea cerrarlo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro de querer salir?", "Salir",
         MessageBoxButtons.YesNo) == DialogResult.No)
            {               
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Convierte el resultado a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
        }

        /// <summary>
        /// convierte el resultado a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
        }

        /// <summary>
        /// cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        /// <summary>
        /// limpia el resultado, combobox y texboxs del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// realiza la operacion pasada en el combo box, en caso de recibir el MinValue, devolvera error, si no, el resultado de la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// asigna valores vacios los texbox, comboOperador y el resultado
        /// </summary>
        private void Limpiar()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// realiza la operacion entre los numeros por medio del metodo estatico de la clase calculadora, operar.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {

            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);
            return Calculadora.Operar(numeroUno, numeroDos, operador);
        }
      
    }
}
