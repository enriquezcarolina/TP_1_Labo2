
namespace TP_1_Labo2
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.cant_solucionesUpDown = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_costo = new System.Windows.Forms.Button();
            this.poda_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cant_solucionesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AccessibleName = "";
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(210, 228);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Buscar soluciones";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cant_solucionesUpDown
            // 
            this.cant_solucionesUpDown.Location = new System.Drawing.Point(377, 135);
            this.cant_solucionesUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.cant_solucionesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cant_solucionesUpDown.Name = "cant_solucionesUpDown";
            this.cant_solucionesUpDown.Size = new System.Drawing.Size(54, 20);
            this.cant_solucionesUpDown.TabIndex = 1;
            this.cant_solucionesUpDown.Tag = "";
            this.cant_solucionesUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(306, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Cantidad de soluciones:";
            // 
            // button_costo
            // 
            this.button_costo.Location = new System.Drawing.Point(501, 275);
            this.button_costo.Name = "button_costo";
            this.button_costo.Size = new System.Drawing.Size(87, 34);
            this.button_costo.TabIndex = 3;
            this.button_costo.Text = "Costo";
            this.button_costo.UseVisualStyleBackColor = true;
            this.button_costo.Click += new System.EventHandler(this.button_costo_Click);
            // 
            // poda_btn
            // 
            this.poda_btn.Location = new System.Drawing.Point(464, 315);
            this.poda_btn.Name = "poda_btn";
            this.poda_btn.Size = new System.Drawing.Size(124, 39);
            this.poda_btn.TabIndex = 4;
            this.poda_btn.Text = "Criterios de poda";
            this.poda_btn.UseVisualStyleBackColor = true;
            this.poda_btn.Click += new System.EventHandler(this.poda_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.poda_btn);
            this.Controls.Add(this.button_costo);
            this.Controls.Add(this.cant_solucionesUpDown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cant_solucionesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.NumericUpDown cant_solucionesUpDown;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_costo;
        private System.Windows.Forms.Button poda_btn;
    }
}

