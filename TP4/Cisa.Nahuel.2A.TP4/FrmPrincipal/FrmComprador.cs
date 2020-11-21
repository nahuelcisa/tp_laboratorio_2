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
using System.IO;
using System.Threading;

namespace FrmPrincipal
{
    public partial class FrmComprador : Form
    {
        #region atributos

        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;
        private Gabinete gabo;
        private Procesador micro;
        private PlacaDeVideo gpu;
        private Thread t;
        private Carrito<Producto> carro;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor por default del frm, inicializa la conexion con la base de datos, configura el data adapter
        /// configura el data table, lo carga, instancia el carrito y tambien instancia el hilo secundario
        /// </summary>
        public FrmComprador()
        {
            InitializeComponent();

            this.cn = new SqlConnection(Properties.Settings.Default.conexion);

            this.ConfigurarDataAdapter();
            this.ConfigurarDataTable();


            this.ConfigurarGrilla();

            this.CargarData();

            carro = new Carrito<Producto>(3);

            this.carro.PrecioSuperado += carro_EventoPrecio;

            this.t = new Thread(new ThreadStart(this.MensajeThread));
        }

        #endregion

        #region botones

        /// <summary>
        /// Selecciona el producto el cual se agrega en el carrito, al estar lleno el carrito lanza la excepcion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;

            DataRow fila = this.dt.Rows[i];

            string producto = fila["producto"].ToString();

            try {
                if ((int)fila["cantidad_de_stock"] > 0)
                {
                    switch (producto)
                    {
                        case "Gabinete":

                            FrmGabinete frmgabo = new FrmGabinete();

                            frmgabo.StartPosition = FormStartPosition.CenterScreen;

                            if (frmgabo.ShowDialog() == DialogResult.OK)
                            {

                                gabo = new Gabinete("Gabinete", fila["marca"].ToString(), fila["modelo"].ToString(), (float)fila["precio"], (int)fila["cantidad_de_stock"] - 1, frmgabo.GabineteDelForm);

                                try
                                {
                                    carro += gabo;
                                    this.listBox1.Items.Add(gabo.ToString());
                                    int stock = int.Parse(fila["cantidad_de_stock"].ToString());
                                    stock--;
                                    fila["cantidad_de_stock"] = stock;

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

                            if (frmgpu.ShowDialog() == DialogResult.OK)
                            {
                                gpu = new PlacaDeVideo("Placa de video", fila["marca"].ToString(), fila["modelo"].ToString(), (float)fila["precio"], (int)fila["cantidad_de_stock"] - 1, frmgpu.GpuDelForm);

                                try
                                {
                                    carro += gpu;
                                    this.listBox1.Items.Add(gpu.ToString());
                                    int stock = int.Parse(fila["cantidad_de_stock"].ToString());
                                    stock--;
                                    fila["cantidad_de_stock"] = stock;
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
                                micro = new Procesador("Procesador", fila["marca"].ToString(), fila["modelo"].ToString(), (float)fila["precio"], (int)fila["cantidad_de_stock"] - 1, frmcpu.CpuDelForm);

                                try
                                {
                                    carro += micro;
                                    this.listBox1.Items.Add(micro.ToString());
                                    int stock = int.Parse(fila["cantidad_de_stock"].ToString());
                                    stock--;
                                    fila["cantidad_de_stock"] = stock;
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
                }
                else
                {
                    throw new SinStockException();
                }
            }catch(SinStockException exc)           
            {
                MessageBox.Show(exc.Message);
            }                        
        }

        /// <summary>
        /// te vacia el carrito, imprime el ticket que se cuarda en documentos y tambien se muestra en , actualiza la cantidad de stock actual, y vacia el listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                if (carro.Productos.Count == 0) {
                    throw new Exception("El carro no puede estar vacio.");
                }
                bool todoOK = Ticketeadora<Producto>.ImprimirTicket(this.carro);

                if (todoOK)
                {
                    

                    this.da.Update(this.dt);
                    
                    MessageBox.Show("La venta se realizo correctamente, visualizara su ticket arriba.");
                    string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\tickets.log";
                    string texto;
                    StreamReader f = new StreamReader(path);

                    texto = f.ReadToEnd();

                    f.Close();

                    this.textBox1.Text = texto;
                   
                    this.listBox1.Items.Clear();


                    carro.Productos.Clear();
                    
                    

                }

            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region metodos


        /// <summary>
        /// inicializa el hilo secundario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmComprador_FormClosing(object sender, FormClosingEventArgs e)
        {          
            this.t.Start();           
        }
        /// <summary>
        /// mata el hilo secundario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmComprador_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (this.t.IsAlive)
            {
                Thread.Sleep(50);
                this.t.Abort();

            }
        }

        /// <summary>
        /// configura todo el data adapter
        /// </summary>
        /// <returns>true si lo pudo configurar, false si no</returns>
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
        /// configura todo el data table.
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// tira el fill en la grilla par allenarla y cargarla con los datos.
        /// </summary>
        protected void CargarData()
        {
            try
            {
                this.da.Fill(this.dt);

                this.dgvGrilla.DataSource = this.dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// es el manejador del evento precio, el cual se lanza una vez pasado el precio de 500.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void carro_EventoPrecio(object sender, EventArgs e)
        {
            MessageBox.Show("Pasaste el precio minimo, podes pagar en cuotas!!");
        }
        /// <summary>
        /// es el mensaje que se larga en le hilo secundario al cerrar el form.
        /// </summary>
        private void MensajeThread()
        {
            MessageBox.Show("Gracias por comprar en nuestra tienda!!!");
        }

        private void ConfigurarGrilla()
        {
            // Coloco color de fondo para las filas
            this.dgvGrilla.RowsDefaultCellStyle.BackColor = Color.Wheat;

            // Alterno colores
            this.dgvGrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.BurlyWood;

            // Pongo color de fondo a la grilla
            this.dgvGrilla.BackgroundColor = Color.Beige;

            // Defino fuente para el encabezado y alineación del encabezado
            this.dgvGrilla.ColumnHeadersDefaultCellStyle.Font = new Font(dgvGrilla.Font, FontStyle.Bold);
            this.dgvGrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Defino el color de las lineas de separación
            this.dgvGrilla.GridColor = Color.HotPink;

            // La grilla será de sólo lectura
            this.dgvGrilla.ReadOnly = false;

            // No permito la multiselección
            this.dgvGrilla.MultiSelect = false;

            // Selecciono toda la fila a la vez
            this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Hago que las columnas ocupen todo el ancho del 'DataGrid'
            this.dgvGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Indico el color de la fila seleccionada
            this.dgvGrilla.RowsDefaultCellStyle.SelectionBackColor = Color.DarkOliveGreen;
            this.dgvGrilla.RowsDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            // No permito modificar desde la grilla
            this.dgvGrilla.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Saco los encabezados de las filas
            this.dgvGrilla.RowHeadersVisible = false;

            this.dgvGrilla.AllowUserToAddRows = false;

        }

            #endregion
    }
}
