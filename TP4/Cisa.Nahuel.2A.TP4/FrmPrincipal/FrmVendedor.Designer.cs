
namespace FrmPrincipal
{
    partial class FrmVendedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.Cerrar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSerializer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(28, 12);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(685, 339);
            this.dgvGrilla.TabIndex = 0;
            // 
            // Cerrar
            // 
            this.Cerrar.BackColor = System.Drawing.Color.Snow;
            this.Cerrar.Location = new System.Drawing.Point(741, 425);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(78, 39);
            this.Cerrar.TabIndex = 6;
            this.Cerrar.Text = "Salir";
            this.Cerrar.UseVisualStyleBackColor = false;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Snow;
            this.btnAdd.Location = new System.Drawing.Point(28, 373);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(657, 66);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Agregar producto";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSerializer
            // 
            this.btnSerializer.BackColor = System.Drawing.Color.Snow;
            this.btnSerializer.Location = new System.Drawing.Point(736, 64);
            this.btnSerializer.Name = "btnSerializer";
            this.btnSerializer.Size = new System.Drawing.Size(82, 44);
            this.btnSerializer.TabIndex = 7;
            this.btnSerializer.Text = "Serializar Gabinete";
            this.btnSerializer.UseVisualStyleBackColor = false;
            this.btnSerializer.Click += new System.EventHandler(this.btnSerializer_Click);
            // 
            // FrmVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(831, 476);
            this.Controls.Add(this.btnSerializer);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvGrilla);
            this.Name = "FrmVendedor";
            this.Text = "FrmVendedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVendedor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSerializer;
    }
}