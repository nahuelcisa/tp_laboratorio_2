
namespace FrmPrincipal
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVendedor = new System.Windows.Forms.Button();
            this.btnComprador = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVendedor
            // 
            this.btnVendedor.BackColor = System.Drawing.Color.Snow;
            this.btnVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVendedor.FlatAppearance.BorderColor = System.Drawing.Color.Chartreuse;
            this.btnVendedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnVendedor.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendedor.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnVendedor.Location = new System.Drawing.Point(12, 73);
            this.btnVendedor.Name = "btnVendedor";
            this.btnVendedor.Size = new System.Drawing.Size(295, 219);
            this.btnVendedor.TabIndex = 0;
            this.btnVendedor.Text = "Ingresar como Vendedor";
            this.btnVendedor.UseVisualStyleBackColor = false;
            this.btnVendedor.Click += new System.EventHandler(this.btnVendedor_Click);
            // 
            // btnComprador
            // 
            this.btnComprador.BackColor = System.Drawing.Color.Snow;
            this.btnComprador.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprador.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnComprador.Location = new System.Drawing.Point(336, 73);
            this.btnComprador.Name = "btnComprador";
            this.btnComprador.Size = new System.Drawing.Size(286, 219);
            this.btnComprador.TabIndex = 1;
            this.btnComprador.Text = "Ingresar como Comprador";
            this.btnComprador.UseVisualStyleBackColor = false;
            this.btnComprador.Click += new System.EventHandler(this.btnComprador_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Snow;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCerrar.Location = new System.Drawing.Point(259, 333);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 53);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(634, 398);
            this.ControlBox = false;
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnComprador);
            this.Controls.Add(this.btnVendedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVendedor;
        private System.Windows.Forms.Button btnComprador;
        private System.Windows.Forms.Button btnCerrar;
    }
}

