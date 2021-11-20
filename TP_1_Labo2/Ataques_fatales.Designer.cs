
namespace TP_1_Labo2
{
    partial class Ataques_fatales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid_Ataques = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Ataques)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid_Ataques
            // 
            this.DataGrid_Ataques.AllowUserToAddRows = false;
            this.DataGrid_Ataques.AllowUserToDeleteRows = false;
            this.DataGrid_Ataques.AllowUserToResizeColumns = false;
            this.DataGrid_Ataques.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid_Ataques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGrid_Ataques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Ataques.ColumnHeadersVisible = false;
            this.DataGrid_Ataques.Enabled = false;
            this.DataGrid_Ataques.GridColor = System.Drawing.SystemColors.Control;
            this.DataGrid_Ataques.Location = new System.Drawing.Point(35, 15);
            this.DataGrid_Ataques.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGrid_Ataques.MultiSelect = false;
            this.DataGrid_Ataques.Name = "DataGrid_Ataques";
            this.DataGrid_Ataques.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid_Ataques.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGrid_Ataques.RowHeadersVisible = false;
            this.DataGrid_Ataques.RowHeadersWidth = 51;
            this.DataGrid_Ataques.RowTemplate.Height = 50;
            this.DataGrid_Ataques.RowTemplate.ReadOnly = true;
            this.DataGrid_Ataques.ShowEditingIcon = false;
            this.DataGrid_Ataques.Size = new System.Drawing.Size(547, 510);
            this.DataGrid_Ataques.TabIndex = 1;
            this.DataGrid_Ataques.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGrid_Ataques_CellFormatting);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 484);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(609, 105);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(157, 58);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "En naranja se muestran las posiciones atacadas fatalmente";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(628, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 86);
            this.button2.TabIndex = 4;
            this.button2.Text = "Piezas que producen el bloqueo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ataques_fatales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 545);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataGrid_Ataques);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ataques_fatales";
            this.Text = "Ataques_fatales";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Ataques)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid_Ataques;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}