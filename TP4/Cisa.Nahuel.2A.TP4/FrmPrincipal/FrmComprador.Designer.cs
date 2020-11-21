
namespace FrmPrincipal
{
    partial class FrmComprador
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(12, 12);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(644, 292);
            this.dgvGrilla.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar un producto";
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Snow;
            this.btnSelect.Location = new System.Drawing.Point(196, 337);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(113, 30);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.Color.Snow;
            this.btnComprar.Location = new System.Drawing.Point(852, 419);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(112, 50);
            this.btnComprar.TabIndex = 5;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = false;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(458, 359);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(506, 54);
            this.listBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(737, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ticket";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(725, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 204);
            this.textBox1.TabIndex = 4;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Snow;
            this.btnCerrar.Location = new System.Drawing.Point(693, 419);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(153, 50);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar.";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmComprador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(976, 472);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGrilla);
            this.Name = "FrmComprador";
            this.Text = "FrmComprador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmComprador_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmComprador_FormClosed_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCerrar;
    }
}