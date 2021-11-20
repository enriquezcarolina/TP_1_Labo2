
namespace TP_1_Labo2
{
    partial class form_datagrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Anterior_btn = new System.Windows.Forms.Button();
            this.Ataques_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AllowUserToResizeColumns = false;
            this.DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.ColumnHeadersVisible = false;
            this.DataGridView.Enabled = false;
            this.DataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.DataGridView.Location = new System.Drawing.Point(25, 11);
            this.DataGridView.MultiSelect = false;
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.RowTemplate.Height = 50;
            this.DataGridView.RowTemplate.ReadOnly = true;
            this.DataGridView.ShowEditingIcon = false;
            this.DataGridView.Size = new System.Drawing.Size(410, 414);
            this.DataGridView.TabIndex = 0;
            this.DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableroDataGridView_CellContentClick);
            this.DataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(554, 382);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(97, 43);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Siguiente";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(481, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 2;
            // 
            // Anterior_btn
            // 
            this.Anterior_btn.Location = new System.Drawing.Point(452, 382);
            this.Anterior_btn.Name = "Anterior_btn";
            this.Anterior_btn.Size = new System.Drawing.Size(96, 42);
            this.Anterior_btn.TabIndex = 3;
            this.Anterior_btn.Text = "Anterior";
            this.Anterior_btn.UseVisualStyleBackColor = true;
            this.Anterior_btn.Click += new System.EventHandler(this.Anterior_btn_Click);
            // 
            // Ataques_btn
            // 
            this.Ataques_btn.Location = new System.Drawing.Point(503, 126);
            this.Ataques_btn.Name = "Ataques_btn";
            this.Ataques_btn.Size = new System.Drawing.Size(108, 31);
            this.Ataques_btn.TabIndex = 4;
            this.Ataques_btn.Text = "Ataques fatales";
            this.Ataques_btn.UseVisualStyleBackColor = true;
            this.Ataques_btn.Click += new System.EventHandler(this.Ataques_btn_Click);
            // 
            // form_datagrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 437);
            this.Controls.Add(this.Ataques_btn);
            this.Controls.Add(this.Anterior_btn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.DataGridView);
            this.Name = "form_datagrid";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_datagrid_FormClosing);
            this.Load += new System.EventHandler(this.form_datagrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Anterior_btn;
        private System.Windows.Forms.Button Ataques_btn;
    }
}