using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;

namespace FrmPrincipal
{
    public partial class FrmComprador : Form
    {

        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;
        private Gabinete gabo;
        private Procesador micro;
        private PlacaDeVideo gpu;

        private Carrito<Producto> carro;
        public FrmComprador()
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

            carro = new Carrito<Producto>(3);

        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            int i = this.dataGridView1.SelectedRows[0].Index;
           
            DataRow fila = this.dt.Rows[i];

            string producto = fila["producto"].ToString();
            
            switch (producto)
            {
                case "Gabinete":

                    FrmGabinete frmgabo = new FrmGabinete();
                    
                    frmgabo.StartPosition = FormStartPosition.CenterScreen;

                    if (frmgabo.ShowDialog() == DialogResult.OK)
                    {
                                              
                        gabo = new Gabinete("Gabinete", fila["marca"].ToString(), fila["modelo"].ToString(),(float)fila["precio"] ,(int)fila["cantidad_de_stock"], frmgabo.GabineteDelForm);

                        try
                        {
                            carro += gabo;
                        }
                        catch (CarritoLlenoException ex)
                        {
                            MessageBox.Show(ex.InformarCarritoLleno());
                        }
                        
                    }
                    break;

                case "PlacaDeVideo":

                    FrmPlacaDeVideo frmgpu = new FrmPlacaDeVideo();

                    frmgpu.StartPosition = FormStartPosition.CenterScreen;

                    if(frmgpu.ShowDialog() == DialogResult.OK)
                    {
                        gpu = new PlacaDeVideo("Placa de video", fila["marca"].ToString(), fila["modelo"].ToString(), (float)fila["precio"], (int)fila["cantidad_de_stock"], frmgpu.GpuDelForm);

                        try
                        {
                            carro += gpu;
                        }
                        catch (CarritoLlenoException ex)
                        {
                            MessageBox.Show(ex.InformarCarritoLleno());
                        }                        
                    }
                    break;

                case "Procesador":

                    FrmProcesador frmcpu = new FrmProcesador();

                    frmcpu.StartPosition = FormStartPosition.CenterScreen;

                    if (frmcpu.ShowDialog() == DialogResult.OK)
                    {
                        micro = new Procesador("Procesador", fila["marca"].ToString(), fila["modelo"].ToString(), (float)fila["precio"], (int)fila["cantidad_de_stock"], frmcpu.CpuDelForm);

                        try
                        {
                            carro += micro;
                        }
                        catch (CarritoLlenoException ex)
                        {
                            MessageBox.Show(ex.InformarCarritoLleno());
                        }

                        
                    }

                    break;

                default:
                    break;
            }

            MessageBox.Show(carro.Productos.Count.ToString());
        }


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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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
    }
}
