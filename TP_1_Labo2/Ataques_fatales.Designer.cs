
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid_Ataques = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_Ataques)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid_Ataques
            // 
            this.DataGrid_Ataques.AllowUserToAddRows = false;
            this.DataGrid_Ataques.AllowUserToDeleteRows = false;
            this.DataGrid_Ataques.AllowUserToResizeColumns = false;
            this.DataGrid_Ataques.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid_Ataques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGrid_Ataques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_Ataques.ColumnHeadersVisible = false;
            this.DataGrid_Ataques.Enabled = false;
            this.DataGrid_Ataques.GridColor = System.Drawing.SystemColors.Control;
            this.DataGrid_Ataques.Location = new System.Drawing.Point(26, 12);
            this.DataGrid_Ataques.MultiSelect = false;
            this.DataGrid_Ataques.Name = "DataGrid_Ataques";
            this.DataGrid_Ataques.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid_Ataques.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DataGrid_Ataques.RowHeadersVisible = false;
            this.DataGrid_Ataques.RowTemplate.Height = 50;
            this.DataGrid_Ataques.RowTemplate.ReadOnly = true;
            this.DataGrid_Ataques.ShowEditingIcon = false;
            this.DataGrid_Ataques.Size = new System.Drawing.Size(410, 414);
            this.DataGrid_Ataques.TabIndex = 1;
            this.DataGrid_Ataques.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGrid_Ataques_CellFormatting);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(457, 87);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(119, 42);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "En naranja se muestran los ataques fatales";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Ataques_fatales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 443);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataGrid_Ataques);
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
    }
}