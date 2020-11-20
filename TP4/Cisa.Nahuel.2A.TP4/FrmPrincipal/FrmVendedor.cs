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
using System.IO;
using System.Data.SqlClient;

namespace FrmPrincipal
{
    public partial class FrmVendedor : Form
    {

        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;
        private Gabinete gab;

        /// <summary>
        /// Constructor por defecto del frm, configura la conexion a la bbdd, el data adapter , data table y lo carga con la informacion.
        /// tambien instancia un gabinete el cual se usa para serializarlo a xml.
        /// </summary>
        public FrmVendedor()
        {
            InitializeComponent();

            this.cn = new SqlConnection(Properties.Settings.Default.conexion);

            this.ConfigurarDataAdapter();
            this.ConfigurarDataTable();
           
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.CargarData();

            gab = new Gabinete("Gabinete", "Sentey", "A50", 56, 4, 5);

        }
            
        /// <summary>
        /// crea una instancia de frmAdd para agregar un producto a la grilla y a la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAdd frm = new FrmAdd();

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.dt.NewRow();

                fila["producto"] = frm.ProductoDelForm.Product;
                fila["marca"] = frm.ProductoDelForm.Marca;
                fila["modelo"] = frm.ProductoDelForm.Modelo;
                fila["precio"] = frm.ProductoDelForm.Precio;
                fila["cantidad_de_stock"] = frm.ProductoDelForm.CantidadDeStock;

                this.dt.Rows.Add(fila);               
            }
        }

        /// <summary>
        /// cierra el frm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// pregunta si esta seguro que quiere salir, a su vez, actualiza la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVendedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro de querer salir?", "Salir",
         MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            this.ActualizarData();
        }

        /// <summary>
        /// configura todas las conexiones entre la base de datos y el data adapter
        /// </summary>
        /// <returns></returns>
        protected bool ConfigurarDataAdapter()
        {
            bool rta = false;

            try
            {
                SqlConnection cn = new SqlConnection(Properties.Settings.Default.conexion);

                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT id, producto, marca, modelo, precio, cantidad_de_stock FROM productos", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO productos (producto, marca, modelo, precio, cantidad_de_stock) VALUES ( @producto, @marca, @modelo, @precio, @cantidad_de_stock)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE productos SET producto=@producto, marca=@marca, modelo=@modelo, precio=@precio, cantidad_de_stock=@cantidad_de_stock WHERE id=@id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM productos WHERE id=@id", cn);

                this.da.InsertCommand.Parameters.Add("@producto", SqlDbType.VarChar, 50, "producto");
                this.da.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.InsertCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.InsertCommand.Parameters.Add("@cantidad_de_stock", SqlDbType.Int, 10, "cantidad_de_stock");

                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
                this.da.UpdateCommand.Parameters.Add("@producto", SqlDbType.VarChar, 50, "producto");
                this.da.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.UpdateCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.UpdateCommand.Parameters.Add("@cantidad_de_stock", SqlDbType.Int, 10, "cantidad_de_stock");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                rta = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return rta;
        }
        /// <summary>
        /// configura todas las columnas del data table.
        /// </summary>
        protected void ConfigurarDataTable()
        {
            try
            {

                this.dt = new DataTable("productos");

                this.dt.Columns.Add("id", typeof(int));
                this.dt.Columns.Add("producto", typeof(string));
                this.dt.Columns.Add("marca", typeof(string));
                this.dt.Columns.Add("modelo", typeof(string));
                this.dt.Columns.Add("precio", typeof(float));
                this.dt.Columns.Add("cantidad_de_stock", typeof(int));

                this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

                this.dt.Columns["id"].AutoIncrement = true;
                this.dt.Columns["id"].AutoIncrementSeed = 1;
                this.dt.Columns["id"].AutoIncrementStep = 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// hace el fill en el data adapter para cargar la grilla.
        /// </summary>
        protected void CargarData()
        {
            try
            {
                this.da.Fill(this.dt);

                this.dataGridView1.DataSource = this.dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// sincroniza el data table con el data adapter y la base de datos.
        /// </summary>
        protected void ActualizarData()
        {
            try
            {
                da.Update(this.dt);

                MessageBox.Show("Base de datos actualizada!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha sincronizado!!!\n" + ex.Message);
            }
        }
        /// <summary>
        /// serializa un gabinete hardcodeado y lo crea en el escritorio, lo deserializa y lo lee.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerializer_Click(object sender, EventArgs e)
        {
            Gabinete aux = null;
            

            if (this.gab.Xml())
            {
                MessageBox.Show("Gabinete serializado OK");
            }
            else
            {
                MessageBox.Show("Gabinete NO serializado");
            }

            if (((IDeserializa)this.gab).Xml(out aux))
            {
                MessageBox.Show("Gabinete deserializado OK");

                MessageBox.Show(aux.ToString());
            }
            else
            {
                MessageBox.Show("Gabinete NO deserializado");
            }
        }
    }
}
